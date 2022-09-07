
using Coop.Domain.Cliente.Models;

namespace Coop.Domain.Cliente.Repository
{
    public interface IPersonaRepository : IDisposable
    {
        Task<List<PersonaModel>> ObtenerPersonas();
        Task<PersonaModel?> ObtenerPersonaPorID(int PersonaId);
        Task InsertarPersona(PersonaModel Persona);
        Task EliminarPersona(int PersonaId);
        void ActualizarPersona(PersonaModel Persona);
        void Save();
    }
}
