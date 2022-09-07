
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Movimiento.Reports
{
    public interface IMovimientoReporteGenerator
    {
        Task<List<MovimientoReporteResponseModel>> Generate(
                  (int, int, int) FechaInicio
                , (int, int, int) FechaFin
                , Guid ClienteId
            );
    }
}
