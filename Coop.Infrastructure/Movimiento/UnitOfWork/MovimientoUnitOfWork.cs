

using Coop.Domain.Cuenta.Models;
using Coop.Domain.Cuenta.Repository;
using Coop.Domain.Movimiento.Domain;
using Coop.Domain.Movimiento.Models;
using Coop.Domain.Movimiento.Repository;
using Coop.Domain.Movimiento.UnitOfWork;

namespace Coop.Infrastructure.Movimiento.UnitOfWork
{
    public class MovimientoUnitOfWork: IMovimientoUnitOfWork, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        private IMovimientoRepository MovimientoRepository;
        private ICuentaRepository CuentaRepository;
        private IMovimientoStrategy MovimientoStrategy;

        public MovimientoUnitOfWork(
             CoopContext Context
            , IMovimientoRepository MovimientoRepository
            , IMovimientoStrategy MovimientoStrategy
            , ICuentaRepository CuentaRepository
            )
        {
            this.Context = Context;
            this.MovimientoRepository = MovimientoRepository;
            this.MovimientoStrategy = MovimientoStrategy;
            this.CuentaRepository = CuentaRepository;
        }

        public async Task<MovimientoModel> CrearMovimiento(MovimeintoREquestModel clienteRequests)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {
                DateTime currentDate = DateTime.Now; 
                MovimientoModel movimiento = null;
                CuentaModel? cuenta = await this.CuentaRepository.ObtenerCluentaPorID(clienteRequests.NumeroCuenta);
                if(cuenta != null)
                {
                    movimiento = new MovimientoModel()
                    {
                        Fecha = currentDate,
                        NumeroCuenta = clienteRequests.NumeroCuenta,
                        Valor = clienteRequests.Valor,
                        Saldo = cuenta.SaldoInicial
                    };

                    movimiento = this.MovimientoStrategy.RegistrarMovimiento(movimiento);
                    await MovimientoRepository.InsertarMovimiento(movimiento);
                    MovimientoRepository.Save();

                    //cuenta.SaldoInicial = movimiento.Saldo;
                    //this.CuentaRepository.ActualizarCuenta(cuenta);
                    //CuentaRepository.Save();
                }



                movimiento.Cuenta = null;

                transaction.Commit();
                return movimiento;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
                return null;
            }
        }

        public async Task<MovimientoModel> ActualizarMovimiento(MovimeintoREquestModel clienteRequests, Guid MovimientoId)
        {
            var transaction = Context.Database.BeginTransaction();

            try
            {
                DateTime currentDate = DateTime.Now;
                MovimientoModel movimiento = null;
                CuentaModel? cuenta = await this.CuentaRepository.ObtenerCluentaPorID(clienteRequests.NumeroCuenta);
                if (cuenta != null)
                {
                    movimiento = new MovimientoModel()
                    {
                        MovimientoId = MovimientoId,
                        Fecha = currentDate,
                        NumeroCuenta = clienteRequests.NumeroCuenta,
                        Valor = clienteRequests.Valor,
                        Saldo = cuenta.SaldoInicial
                    };

                    movimiento = this.MovimientoStrategy.RegistrarMovimiento(movimiento);
                    MovimientoRepository.ActualizarMovimiento(movimiento);
                    MovimientoRepository.Save();

                    //cuenta.SaldoInicial = movimiento.Saldo;
                    //this.CuentaRepository.ActualizarCuenta(cuenta);
                    //CuentaRepository.Save();
                }



                movimiento.Cuenta = null;

                transaction.Commit();
                return movimiento;
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
