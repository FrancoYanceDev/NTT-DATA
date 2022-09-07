
using Coop.Domain.Cuenta.Models;
using Coop.Domain.Cuenta.Repository;
using Microsoft.EntityFrameworkCore;

namespace Coop.Infrastructure.Cuenta.Repository
{
    public class CuentaRepository : ICuentaRepository, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        public CuentaRepository(CoopContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<CuentaModel>> ObtenerCuentas()
        {
            return await Context.Cuentas.ToListAsync();
        }
        public async Task<CuentaModel?> ObtenerCluentaPorID(Guid CuentaId)
        {
            return await Context.Cuentas.FindAsync(CuentaId);
        }
        public async Task InsertarCuenta(CuentaModel Cuenta)
        {
            await Context.Cuentas.AddAsync(Cuenta);
        }

        public async Task<List<CuentaModel>> InsertarGrupoCuenta(List<CuentaModel> Cuentas)
        {
            await Context.Cuentas.AddRangeAsync(Cuentas);
            return Cuentas;
        }

        public void ActualizarCuenta(CuentaModel Cuenta)
        {
            Context.Entry(Cuenta).State = EntityState.Modified;
        }


        public async Task<CuentaModel> EliminarCuenta(Guid CuentaId)
        {
            CuentaModel? Cuenta = await this.ObtenerCluentaPorID(CuentaId);
            if (Cuenta != null)
                Context.Cuentas.Remove(Cuenta);

            this.Save();
            return Cuenta;
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
