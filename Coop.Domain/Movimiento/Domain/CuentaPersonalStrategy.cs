

using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Movimiento.Domain
{
    public class CuentaPersonalStrategy : IMovimientoStrategy
    { 
        public MovimientoModel RegistrarMovimiento(MovimientoModel Movimiento)
        {

            if (Movimiento.Valor == 0)
            {
                new Exception("No puede realizar una transacción con valor $0.00");
            }
            if (Movimiento.Saldo == 0 && Movimiento.MovimientoTipo == "Dédito")
            {
                new Exception("Saldo no disponible");
            }

            if (Movimiento.Valor < 0)
            {
                Movimiento.MovimientoTipo = "Dédito";
            }

            if (Movimiento.Valor > 0)
            {
                Movimiento.MovimientoTipo = "Crédito";
            }

            Movimiento.Saldo += Movimiento.Valor;
            return Movimiento;
        }
    }
}
