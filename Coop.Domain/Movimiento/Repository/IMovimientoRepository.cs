
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Movimiento.Repository
{
    public interface IMovimientoRepository : IDisposable
    {
        Task<List<MovimientoModel>> ObtenerMovimientos();
        Task<MovimientoModel?> ObtenerMovimientoPorID(Guid MovimientoId);
        Task InsertarMovimiento(MovimientoModel Movimiento);
        Task<List<MovimientoModel>> InsertarGroupMovimiento(List<MovimientoModel> Movimientos);
        Task<MovimientoModel> EliminarMovimiento(Guid MovimientoId);
        void ActualizarMovimiento(MovimientoModel Movimiento);
        void Save();
    }
}
