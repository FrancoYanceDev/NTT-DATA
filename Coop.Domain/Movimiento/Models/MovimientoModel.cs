
using Coop.Domain.Cliente.Models;
using Coop.Domain.Cuenta.Models;

namespace Coop.Domain.Movimiento.Models
{
    public class MovimientoModel
    {
        public Guid MovimientoId { get; set; }
        public DateTime Fecha { get; set; } 
        public string MovimientoTipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        public Guid NumeroCuenta { get; set; }
        public CuentaModel Cuenta { get; set; }

    }
}
