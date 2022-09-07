

using Coop.Domain.Cliente.Models;

namespace Coop.Domain.Cliente.Repository
{
    public interface IClienteRepository : IDisposable
    {
        Task<List<ClienteModel>> ObtenerClientes();
        Task<ClienteModel?> ObtenerClientePorID(Guid ClienteId);
        Task InsertarCliente(ClienteModel cliente);
        Task<ClienteModel?> EliminarCliente(Guid ClienteId);
        ClienteModel ActualizarCliente(ClienteModel cliente);
        void Save();
    }
}
