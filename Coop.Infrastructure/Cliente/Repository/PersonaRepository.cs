
using Coop.Domain.Cliente.Models;
using Coop.Domain.Cliente.Repository;
using Microsoft.EntityFrameworkCore;

namespace Coop.Infrastructure.Cliente.Respository
{
    public class PersonaRepository : IPersonaRepository, IDisposable
    {
        private bool disposed = false;
        private CoopContext Context;
        public PersonaRepository(CoopContext Context)
        {
            this.Context = Context;
        }

        public async Task<List<PersonaModel>> ObtenerPersonas()
        {
            return await Context.Personas.ToListAsync();
        }

        public async Task<PersonaModel?> ObtenerPersonaPorID(int PersonaId)
        {
            return await Context.Personas.FindAsync(PersonaId);
        }

        public async Task InsertarPersona(PersonaModel Persona)
        {
            await Context.Personas.AddAsync(Persona);
        }


        public void ActualizarPersona(PersonaModel Persona)
        {
            Context.Entry(Persona).State = EntityState.Modified;
        }
        public async Task EliminarPersona(int PersonaId)
        {
            PersonaModel? Persona = await this.ObtenerPersonaPorID(PersonaId);
            if (Persona != null)
                Context.Personas.Remove(Persona);
        }

 

 

  


        public void Save()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
