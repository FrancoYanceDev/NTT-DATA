

using Coop.Domain.Movimiento.Models;
using Coop.Domain.Movimiento.Repository;
using Microsoft.EntityFrameworkCore;

namespace Coop.Infrastructure.Movimiento.Repository
{
    public class MovimientoRepository : IMovimientoRepository, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        public MovimientoRepository(CoopContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<MovimientoModel>> ObtenerMovimientos()
        {
            List<MovimientoModel> newList =
             await Context.Movimientos
             .Include(c => c.Cuenta)
              .Include(c => c.Cuenta.Cliente)
             .ToListAsync();
                               
            return newList
                     .Select(mov =>
                     {
                         return new MovimientoModel
                         {
                             MovimientoId = mov.MovimientoId,
                             Fecha = mov.Fecha,
                             MovimientoTipo = mov.MovimientoTipo,
                             Valor = mov.Valor,
                             Saldo = mov.Saldo,
                             NumeroCuenta = mov.Cuenta.NumeroCuenta,
                             Cuenta = new Domain.Cuenta.Models.CuentaModel()
                             {
                                 NumeroCuenta = mov.Cuenta.NumeroCuenta,
                                 TipoCuenta = mov.Cuenta.TipoCuenta,
                                 SaldoInicial = mov.Cuenta.SaldoInicial,
                                 CuentaEstado = mov.Cuenta.CuentaEstado,
                                 ClienteId = mov.Cuenta.Cliente.ClienteId,
                                 Cliente = new Domain.Cliente.Models.ClienteModel()
                                 {
                                     ClienteId = mov.Cuenta.Cliente.ClienteId,
                                     ClienteEstado = mov.Cuenta.Cliente.ClienteEstado,
                                     PersonaId = mov.Cuenta.Cliente.PersonaId,
                                     Nombre = mov.Cuenta.Cliente.Nombre,
                                     Genero = mov.Cuenta.Cliente.Genero,
                                     Edad = mov.Cuenta.Cliente.Edad,
                                     Identificacion = mov.Cuenta.Cliente.Identificacion,
                                     Direccion = mov.Cuenta.Cliente.Direccion,
                                     Telefono = mov.Cuenta.Cliente.Telefono
                                 }
                             },
                         };
                     }).ToList(); 
        }


        public async Task<MovimientoModel?> ObtenerMovimientoPorID(Guid MovimientoId)
        {
            return await Context.Movimientos.FindAsync(MovimientoId);
        }

        public async Task InsertarMovimiento(MovimientoModel Movimiento)
        {
            await Context.Movimientos.AddAsync(Movimiento);
        }

        public async Task<List<MovimientoModel>> InsertarGroupMovimiento(List<MovimientoModel> Movimientos)
        {
            await Context.Movimientos.AddRangeAsync(Movimientos);
            return Movimientos;
        }
        public void ActualizarMovimiento(MovimientoModel Movimiento)
        {
            Context.Entry(Movimiento).State = EntityState.Modified;
        }


        public async Task<MovimientoModel> EliminarMovimiento(Guid MovimientoId)
        {
            MovimientoModel? Movimiento = await this.ObtenerMovimientoPorID(MovimientoId);
            if (Movimiento != null)
                Context.Movimientos.Remove(Movimiento);

            this.Save();
            return Movimiento;
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
