

using Coop.Domain.Cliente.Models;
using Coop.Domain.Cliente.Repository;
using Microsoft.EntityFrameworkCore;

namespace Coop.Infrastructure.Cliente.Respository
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        public ClienteRepository(CoopContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<ClienteModel>> ObtenerClientes()
        {
            return await Context.Clientes.ToListAsync();
        }

        public async Task<ClienteModel?> ObtenerClientePorID(Guid ClienteId)
        {
            return await Context.Clientes
                        .Where(client => client.ClienteId == ClienteId)
                        .FirstOrDefaultAsync();
        }

        public async Task InsertarCliente(ClienteModel cliente)
        {
            await Context.Clientes.AddAsync(cliente);
        }

 
        public ClienteModel ActualizarCliente(ClienteModel cliente)
        {
            Context.Clientes.Update(cliente);
            return cliente;
        }
        public async Task<ClienteModel?> EliminarCliente(Guid ClienteId)
        {
            ClienteModel? cliente = await this.ObtenerClientePorID(ClienteId);
            if(cliente != null)
                Context.Clientes.Remove(cliente);

            this.Save();
            return cliente;
        }



        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
