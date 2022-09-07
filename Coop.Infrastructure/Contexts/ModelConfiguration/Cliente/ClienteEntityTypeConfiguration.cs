
using Coop.Domain.Cliente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coop.Infrastructure.Contexts.ModelConfiguration.Cliente
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder
                 .ToTable("Clientes");

            builder
                .Property(col => col.ClienteId)
                .HasColumnName("ClienteId")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder
                .Property(col => col.Contrasena)
                .HasColumnName("Contrasena")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            builder
               .Property(col => col.ClienteEstado)
               .HasColumnName("ClienteEstado")
               .HasColumnType("bit")
               .IsRequired();

        }
    }
}
