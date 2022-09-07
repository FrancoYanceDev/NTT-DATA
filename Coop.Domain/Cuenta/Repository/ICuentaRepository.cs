

using Coop.Domain.Cuenta.Models;

namespace Coop.Domain.Cuenta.Repository
{
    public interface ICuentaRepository: IDisposable
    {
        Task<List<CuentaModel>> ObtenerCuentas();
        Task<CuentaModel?> ObtenerCluentaPorID(Guid CuentaId);
        Task InsertarCuenta(CuentaModel Cuenta);
        Task<List<CuentaModel>> InsertarGrupoCuenta(List<CuentaModel> Cuentas);
        Task<CuentaModel> EliminarCuenta(Guid CuentaId);
        void ActualizarCuenta(CuentaModel Cuenta);
        void Save();
    }
}
