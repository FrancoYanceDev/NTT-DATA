 
namespace Coop.Domain.Movimiento.Models
{
    public class MovimeintoREquestModel
    {
        public Guid NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool CuentaEstado { get; set; }
        public decimal Valor { get; set; }

        public string MovimientoTipo { get; set; }
    }
}
