
using Coop.Domain.Cliente.Models;
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Cuenta.Models
{
    public class CuentaModel
    {
        public Guid NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool CuentaEstado { get; set; }

        public Guid ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }
        public List<MovimientoModel> Movimientos { get; set; }
    }
}
