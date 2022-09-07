

using Coop.Domain.Cuenta.Models;
using Coop.Domain.Movimiento.Models;

namespace Coop.Domain.Cliente.Models
{
    public class ClienteModel: PersonaModel
    {

        public Guid ClienteId { get; set; }
        public string Contrasena { get; set; } 
        public bool ClienteEstado { get; set; }

        public List<CuentaModel> Cuentas { get; set; }
        
    }
}
