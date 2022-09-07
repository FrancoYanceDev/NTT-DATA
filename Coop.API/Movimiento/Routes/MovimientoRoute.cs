using Coop.Domain.Base.Services;
using Coop.Domain.Movimiento.Models;
using Coop.Domain.Movimiento.Repository;
using Coop.Domain.Movimiento.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coop.API.Movimiento.Routes
{
    public static class MovimientoRoute
    {
        public static IEndpointRouteBuilder MovimientoRoutes(this IEndpointRouteBuilder routes)
        {
            routes.MapGet(
                   "/Movimientos"
                 , async (
                     HttpContext context
                     , [FromServices] IMovimientoRepository MovimientoRepository
                    ) =>
                     {
                         context.Response.StatusCode = 200;
                         await context.Response.WriteAsJsonAsync(await MovimientoRepository.ObtenerMovimientos());
                     }
                );
            routes.MapGet(
                   "/Movimientos/{MovimientoId}"
                 , async (
                     HttpContext context
                     , Guid MovimientoId
                     , [FromServices] IMovimientoRepository MovimientoRepository
                    ) =>
                 {
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(await MovimientoRepository.ObtenerMovimientoPorID(MovimientoId));
                 }
                );


            routes.MapPost(
                   "/Movimientos"
                 , async (
                      HttpContext context
                     , [FromServices] IMovimientoUnitOfWork MovimientoUnitOfWork
                     , [FromBody] MovimeintoREquestModel movimiento
                    ) =>
                 {
                     MovimientoModel clienteResponse = await MovimientoUnitOfWork.CrearMovimiento(movimiento);
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(clienteResponse);


                 }
              );

            routes.MapPut(
                   "/Movimientos/{MovimientoId}"
                 , async (
                      HttpContext context
                      , Guid MovimientoId
                     , [FromServices] IMovimientoUnitOfWork MovimientoUnitOfWork
                     , [FromBody] MovimeintoREquestModel movimiento
                    ) =>
                 {
                     MovimientoModel clienteResponse = await MovimientoUnitOfWork.ActualizarMovimiento(movimiento, MovimientoId);
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(clienteResponse);


                 }
              );




            routes.MapDelete(
                   "/Movimientos/{MovimientoId}"
                 , async (
                      HttpContext context
                     , Guid MovimientoId
                     , [FromServices] IMovimientoRepository MovimientoRepository
                    ) =>
                 {
                     MovimientoModel? clienteResponse = await MovimientoRepository.EliminarMovimiento(MovimientoId);
                     if (clienteResponse == null)
                         context.Response.StatusCode = 401;

                     if (clienteResponse != null)
                     {
                         context.Response.StatusCode = 200;
                         await context.Response.WriteAsJsonAsync(clienteResponse);
                     }
                 }
                );

            return routes;
        }
    }
}
