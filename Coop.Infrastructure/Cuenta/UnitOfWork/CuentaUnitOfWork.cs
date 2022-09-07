
using Coop.Domain.Cliente.Models;
using Coop.Domain.Cliente.Repository;
using Coop.Domain.Cuenta.Models;
using Coop.Domain.Cuenta.Repository;
using Coop.Domain.Cuenta.UnitOfWork;

namespace Coop.Infrastructure.Cuenta.UnitOfWork
{
    public class CuentaUnitOfWork: ICuentaUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        private ICuentaRepository CuentaRepository;
        private IClienteRepository ClienteRepository;
        public CuentaUnitOfWork(
             CoopContext Context
            , ICuentaRepository CuentaRepository
            , IClienteRepository ClienteRepository
            )
        {
            this.Context = Context;
            this.CuentaRepository = CuentaRepository;
            this.ClienteRepository = ClienteRepository;
        }


        public async Task<List<CuentaModel>> CrearGrupoCuenta(List<CuentaRequestModel> clienteRequests)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {

                List<CuentaModel> cuentas = new List<CuentaModel>();
                CuentaModel? cuenta = null;

                clienteRequests.ForEach(client =>
                {
     
                     cuenta = new CuentaModel()
                        {
                            TipoCuenta = client.TipoCuenta,
                            SaldoInicial = client.SaldoInicial,
                            CuentaEstado = client.CuentaEstado,
                            ClienteId = client.PersonId,
                     };

                     cuentas.Add(cuenta);
                     
                });

              
                
                    await CuentaRepository.InsertarGrupoCuenta(cuentas);
                    CuentaRepository.Save();
                 

                transaction.Commit();
                return cuentas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }


        public async Task<CuentaModel> ActualizarCuenta(CuentaRequestModel clienteRequests, Guid cuenta_id)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {
                CuentaModel? cuenta = await this.CuentaRepository.ObtenerCluentaPorID(cuenta_id);
                if(cuenta != null){
                    cuenta.TipoCuenta = clienteRequests.TipoCuenta;
                    cuenta.SaldoInicial = clienteRequests.SaldoInicial;
                    cuenta.CuentaEstado = clienteRequests.CuentaEstado;

                    CuentaRepository.ActualizarCuenta(cuenta);
                    CuentaRepository.Save();
                }
 

          
                transaction.Commit();
                return cuenta;
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
