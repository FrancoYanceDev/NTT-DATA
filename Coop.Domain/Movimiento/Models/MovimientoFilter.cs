 

namespace Coop.Domain.Movimiento.Models
{
    public class MovimientoFilter
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public Guid ClienteId { get; set; }
    }
}
