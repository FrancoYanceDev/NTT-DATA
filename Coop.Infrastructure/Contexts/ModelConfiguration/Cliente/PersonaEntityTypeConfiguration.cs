
using Coop.Domain.Cliente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coop.Infrastructure.Contexts.ModelConfiguration.Cliente
{
    public class PersonaEntityTypeConfiguration : IEntityTypeConfiguration<PersonaModel>
    {
        public void Configure(EntityTypeBuilder<PersonaModel> builder)
        {
            builder
                 .ToTable("Personas")
                 .HasKey(c => c.PersonaId);


            builder
                .Property(col => col.Identificacion)
                .HasColumnName("Identificacion")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder
                .Property(col => col.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(col => col.Genero)
                .HasColumnName("Genero")
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(col => col.Edad)
                .HasColumnName("Edad")
                .HasColumnType("tinyint")
                .IsRequired();

            builder
                .Property(col => col.Direccion)
                .HasColumnName("Direccion")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(col => col.Telefono)
                .HasColumnName("Telefono")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

        }
    }
}
