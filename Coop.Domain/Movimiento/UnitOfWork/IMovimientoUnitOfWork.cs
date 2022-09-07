
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Movimiento.UnitOfWork
{
    public interface IMovimientoUnitOfWork: IDisposable
    {
        Task<MovimientoModel> CrearMovimiento(MovimeintoREquestModel clienteRequests);
        Task<MovimientoModel> ActualizarMovimiento(MovimeintoREquestModel clienteRequests, Guid MovimientoId);
    }
}
