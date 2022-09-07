
using Coop.Domain.Movimiento.Models;
using Coop.Domain.Movimiento.Reports;
using Coop.Domain.Movimiento.Repository;

namespace Coop.Infrastructure.Movimiento.Reports
{
    public class MovimientoReporteClienteGenerator : IMovimientoReporteGenerator
    {
        IMovimientoRepository MovimientoRepository;
        public MovimientoReporteClienteGenerator(
            IMovimientoRepository MovimientoRepository
            )
        {
            this.MovimientoRepository = MovimientoRepository;
        }
        public async Task<List<MovimientoReporteResponseModel>> Generate(
            (int, int, int) FechaInicio
            , (int, int, int) FechaFin
            , Guid ClienteId
            )
        {
            List<MovimientoModel> movimientos =
                await this.MovimientoRepository.ObtenerMovimientos();

            DateTime FechaInicioFormateada = new DateTime(FechaInicio.Item3, FechaInicio.Item2, FechaInicio.Item1);
            DateTime FechaFinFormateada = new DateTime(FechaFin.Item3, FechaFin.Item2, FechaFin.Item1);

            return movimientos
                    .Where(mov => (
                           FechaInicioFormateada  >= mov.Fecha.Date
                        && FechaFinFormateada <= mov.Fecha.Date
                        )
                    && mov.Cuenta.Cliente.ClienteId == ClienteId)
                    .Select(mov =>
                    {
                        return new MovimientoReporteResponseModel() {
                            Fecha = mov.Fecha,
                            Cliente = mov.Cuenta.Cliente.Nombre,
                            NumeroCuenta = mov.Cuenta.NumeroCuenta,
                            TipoCuenta = mov.Cuenta.TipoCuenta,
                            SaldoInicial = mov.Cuenta.SaldoInicial,
                            Estado = mov.Cuenta.CuentaEstado,
                            Movimiento = mov.Valor,
                            SaldoDsiponible = mov.Saldo,
                        };
                    })
                    .ToList();
        }
    }
}
