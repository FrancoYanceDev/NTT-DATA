

using Coop.Domain.Cliente.Models;
using Coop.Domain.Cliente.Repository;
using Coop.Domain.Cliente.UnitOfWork;

namespace Coop.Infrastructure.Cliente.UnitOfWork
{
    public class CrearClienteUnitOfWork: ICrearClienteUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context; 
        private IClienteRepository ClienteRepository;
        public CrearClienteUnitOfWork(
             CoopContext Context 
            , IClienteRepository ClienteRepository
            )
        {
            this.Context = Context; 
            this.ClienteRepository = ClienteRepository;
        }
        public async Task<ClienteModel?> CrearCliente(ClienteRequestModel clienteRequest)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {
 

                ClienteModel cliente = new ClienteModel()
                {
                    Nombre = clienteRequest.Nombres,
                    Direccion = clienteRequest.Direccion,
                    Telefono = clienteRequest.Telefono,
                    PersonaId = Guid.NewGuid(),
                    Contrasena = clienteRequest.Contrasena,
                    ClienteEstado = clienteRequest.Estado,
                };
                await ClienteRepository.InsertarCliente(cliente);
                ClienteRepository.Save();

                transaction.Commit();
                return cliente;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }

        public async Task<ClienteModel?> ActualizarCliente(ClienteRequestModel clienteRequest, Guid cliente_id)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {
                ClienteModel? Cliente = await this.ClienteRepository.ObtenerClientePorID(cliente_id);
                if (Cliente != null)
                {
                    Cliente.Nombre = clienteRequest.Nombres;
                    Cliente.Direccion = clienteRequest.Direccion;
                    Cliente.Telefono = clienteRequest.Telefono;
                    Cliente.Contrasena = clienteRequest.Contrasena;
                    Cliente.ClienteEstado = clienteRequest.Estado;


                    ClienteRepository.ActualizarCliente(Cliente);
                    ClienteRepository.Save();
                }

                transaction.Commit();
                return Cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
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
