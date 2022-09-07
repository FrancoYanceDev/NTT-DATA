
using Coop.Domain.Cliente.Models;
using Coop.Domain.Cuenta.Models;
using Coop.Domain.Movimiento.Models;
using Coop.Infrastructure.Contexts.ModelConfiguration.Cliente;
using Coop.Infrastructure.Contexts.ModelConfiguration.Cuenta;
using Coop.Infrastructure.Contexts.ModelConfiguration.Movimiento;
using Microsoft.EntityFrameworkCore;

namespace Coop.Infrastructure
{
    public class CoopContext : DbContext
    {
        public DbSet<PersonaModel> Personas { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<MovimientoModel> Movimientos { get; set; }
        public DbSet<CuentaModel> Cuentas { get; set; }

        public CoopContext(DbContextOptions<CoopContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PersonaEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<PersonaModel>());

            new ClienteEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<ClienteModel>()); 

            new CuentaEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<CuentaModel>());

            new MovimientoEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<MovimientoModel>());
        }
    }
}
