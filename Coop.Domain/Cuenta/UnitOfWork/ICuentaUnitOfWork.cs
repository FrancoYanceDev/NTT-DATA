
using Coop.Domain.Cuenta.Models;

namespace Coop.Domain.Cuenta.UnitOfWork
{
    public interface ICuentaUnitOfWork : IDisposable
    { 
        Task<List<CuentaModel>> CrearGrupoCuenta(List<CuentaRequestModel> clienteRequests);
        Task<CuentaModel> ActualizarCuenta(CuentaRequestModel clienteRequests, Guid cuenta_id);
    }
}
