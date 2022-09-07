
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Movimiento.Domain
{
    public interface IMovimientoStrategy
    { 
        public MovimientoModel RegistrarMovimiento(MovimientoModel Movimiento);
    }
}
