using Coop.Domain.Cliente.Models;
using Coop.Domain.Cuenta.Models;
using Coop.Domain.Cuenta.Repository;
using Coop.Domain.Cuenta.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coop.API.Cuenta.Routes
{
    public static class CuentaRoute
    {
        public static IEndpointRouteBuilder CuentaRoutes(this IEndpointRouteBuilder routes)
        {
            routes.MapGet(
               "/cuentas"
             , async (
                  HttpContext context
                 , [FromServices] ICuentaRepository CuentaRepository
                ) =>
             {
                 context.Response.StatusCode = 200;
                 await context.Response.WriteAsJsonAsync(await CuentaRepository.ObtenerCuentas());
             }
            );

            routes.MapGet(
               "/cuentas/{cuenta_id}"
             , async (
                  HttpContext context
                 , Guid cuenta_id
                 , [FromServices] ICuentaRepository CuentaRepository
                ) =>
             {
                 context.Response.StatusCode = 200;
                 await context.Response.WriteAsJsonAsync(await CuentaRepository.ObtenerCluentaPorID(cuenta_id));
             }
            );

            routes.MapPost(
                   "/cuentas"
                 , async (
                      HttpContext context 
                     , [FromServices] ICuentaUnitOfWork CuentaUnitOfWork
                     , [FromBody] CuentaRequestModel CuentaRequest
                    ) =>
                 {
                     List<CuentaRequestModel> CuentasRequest = new List<CuentaRequestModel>();
                     CuentasRequest.Add(CuentaRequest);


                     List<CuentaModel> clienteResponse = await CuentaUnitOfWork.CrearGrupoCuenta(CuentasRequest);
                      
                     
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsJsonAsync(clienteResponse);
                     

                 }
              );

            routes.MapPost(
                   "/cuentas/group"
                 , async (
                      HttpContext context
                     , [FromServices] ICuentaUnitOfWork CuentaUnitOfWork
                     , [FromBody] List<CuentaRequestModel> CuentaRequests
                    ) =>
                 {
                    List<CuentaModel> clienteResponse = await CuentaUnitOfWork.CrearGrupoCuenta(CuentaRequests);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsJsonAsync(clienteResponse);
                      

                 }
              );


            routes.MapPut(
                   "/cuentas/{cuenta_id}"
                 , async (
                      HttpContext context
                       , Guid cuenta_id
                     , [FromServices] ICuentaUnitOfWork CuentaUnitOfWork
                     , [FromBody] CuentaRequestModel CuentaRequest
                    ) =>
                 { 


                     CuentaModel clienteResponse = await CuentaUnitOfWork.ActualizarCuenta(CuentaRequest, cuenta_id);
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(clienteResponse);


                 }
              );


            routes.MapDelete(
                   "/cuentas/{cuenta_id}"
                 , async (
                      HttpContext context
                     , Guid cuenta_id
                     , [FromServices] ICuentaRepository CuentaRepository
                    ) =>
                 {
                     CuentaModel? clienteResponse = await CuentaRepository.EliminarCuenta(cuenta_id);
                     if (clienteResponse == null)
                         context.Response.StatusCode = 400;

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
