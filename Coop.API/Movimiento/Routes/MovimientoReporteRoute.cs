using Coop.Domain.Base.Services;
using Coop.Domain.Movimiento.Models;
using Coop.Domain.Movimiento.Reports; 
using Microsoft.AspNetCore.Mvc;

namespace Coop.API.Movimiento.Routes
{
    public static class MovimientoReporteRoute
    {
        public static IEndpointRouteBuilder MovimientoReporteRoutes(this IEndpointRouteBuilder routes)
        {
            routes.MapGet(
                   "/Movimientos/Reporte"
                 , async (
                     HttpContext context
                     , [FromBody] MovimientoFilter movimiento
                     , [FromServices] IMovimientoReporteGenerator MovimientoReporteGenerator
                     , [FromServices] IDateValidatorService DateValidatorService
                    ) =>
                 {
                     bool FechasSonValidas = DateValidatorService.ValidateFormat(movimiento.FechaInicio)
                     && DateValidatorService.ValidateFormat(movimiento.FechaFin);

                     if (FechasSonValidas)
                     {
                         var FechaInicio = DateValidatorService.Desglosar(movimiento.FechaInicio);
                         var FechaFin = DateValidatorService.Desglosar(movimiento.FechaFin);

                         context.Response.StatusCode = 200;
                         await context.Response.WriteAsJsonAsync(
                             await MovimientoReporteGenerator.Generate(FechaInicio, FechaFin, movimiento.ClienteId)
                             );
                     }

                     if (!FechasSonValidas)
                     {
                         context.Response.StatusCode = 400;
                         await context.Response.WriteAsync("El formato de fecha no es válido. por favor use DD/MM/YYYY");
                     }
                 }
                );
            return routes;
        }
     }
}
