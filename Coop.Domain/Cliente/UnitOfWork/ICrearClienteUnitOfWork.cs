

using Coop.Domain.Cliente.Models;

namespace Coop.Domain.Cliente.UnitOfWork
{
    public interface ICrearClienteUnitOfWork : IDisposable
    {
        Task<ClienteModel?> CrearCliente(ClienteRequestModel clienteRequest);
        Task<ClienteModel?> ActualizarCliente(ClienteRequestModel clienteRequest, Guid cliente_id);

    }
}
