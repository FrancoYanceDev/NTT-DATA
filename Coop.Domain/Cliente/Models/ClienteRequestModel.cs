 
namespace Coop.Domain.Cliente.Models
{
    public class ClienteRequestModel
    {
        public string Nombres { get; set; } = string.Empty;
        public string Direccion { get; set;} = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public bool Estado { get; set; }
    }
}
