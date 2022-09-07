
namespace Coop.Domain.Cliente.Models
{ 
    public class PersonaModel
    {
        public Guid PersonaId { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Genero { get; set; } = String.Empty;
        public byte Edad { get; set; } = 0;
        public string Identificacion { get; set; } = "";
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
