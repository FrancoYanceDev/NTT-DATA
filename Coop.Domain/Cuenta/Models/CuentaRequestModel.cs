 
namespace Coop.Domain.Cuenta.Models
{
    public class CuentaRequestModel
    {
        public Guid PersonId { get; set; }
        public Guid NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool CuentaEstado { get; set; }
        public string NombreCliente { get; set; }
    }
}
