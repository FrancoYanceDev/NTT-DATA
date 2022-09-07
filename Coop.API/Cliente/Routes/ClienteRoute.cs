using Coop.Domain.Cliente.Models;
using Coop.Domain.Cliente.Repository;
using Coop.Domain.Cliente.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Coop.API.Cliente.Routes
{
    public static class ClienteRoute
    {
        public static IEndpointRouteBuilder ClienteRoutes(this IEndpointRouteBuilder routes)
        {
            routes.MapGet(
                   "/clientes"
                 , async (
                      HttpContext context
                     , [FromServices] IClienteRepository ClienteRepository
                    ) =>
                 {
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(await ClienteRepository.ObtenerClientes());
                 }
                );
            routes.MapGet(
                   "/clientes/{cliente_id}"
                 , async (
                      HttpContext context
                     , Guid cliente_id
                     , [FromServices] IClienteRepository ClienteRepository
                    ) =>
                 {
                     context.Response.StatusCode = 200;
                     await context.Response.WriteAsJsonAsync(await ClienteRepository.ObtenerClientePorID(cliente_id));
                 }
                );

            routes.MapPost(
                   "/clientes"
                 , async (
                      HttpContext context
                     ,[FromServices] ICrearClienteUnitOfWork CrearClienteUnitOfWork
                     ,[FromBody] ClienteRequestModel clienteRequest
                    ) =>
                 {
                     ClienteModel? clienteResponse = await CrearClienteUnitOfWork.CrearCliente(clienteRequest);
                     if(clienteResponse == null)
                        context.Response.StatusCode = 400;


                     if (clienteResponse != null)
                     {
                         context.Response.StatusCode = 200;
                         await context.Response.WriteAsJsonAsync(clienteResponse);
                     }

                 }
                );


            routes.MapPut(
                   "/clientes/{cliente_id}"
                 , async (
                      HttpContext context
                      , Guid cliente_id
                     , [FromServices] ICrearClienteUnitOfWork CrearClienteUnitOfWork
                     , [FromBody] ClienteRequestModel clienteRequest
                    ) =>
                 {
                     ClienteModel? clienteResponse = await CrearClienteUnitOfWork.ActualizarCliente(clienteRequest, cliente_id);
                     if (clienteResponse == null)
                         context.Response.StatusCode = 400;

                     if (clienteResponse != null)
                     {
                         context.Response.StatusCode = 200;
                         await context.Response.WriteAsJsonAsync(clienteResponse);
                     }
                          
                 }
                );

            routes.MapDelete(
                   "/clientes/{cliente_id}"
                 , async (
                      HttpContext context
                     , Guid cliente_id
                     , [FromServices] IClienteRepository ClienteRepository
                    ) =>
                 {
                     ClienteModel? clienteResponse =  await ClienteRepository.EliminarCliente(cliente_id);
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
