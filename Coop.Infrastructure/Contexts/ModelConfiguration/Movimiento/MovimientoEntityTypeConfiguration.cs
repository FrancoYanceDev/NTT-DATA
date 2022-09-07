

using Coop.Domain.Movimiento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coop.Infrastructure.Contexts.ModelConfiguration.Movimiento
{
    public class MovimientoEntityTypeConfiguration : IEntityTypeConfiguration<MovimientoModel>
    {
        public void Configure(EntityTypeBuilder<MovimientoModel> builder)
        {
            builder
                 .ToTable("Movimientos")
                 .HasKey(c => c.MovimientoId);
            builder
                .Property(col => col.MovimientoId)
                .HasColumnName("MovimientoId")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder
                .Property(col => col.Fecha)
                .HasColumnName("Fecha")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(col => col.MovimientoTipo)
                .HasColumnName("MovimientoTipo")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder
                .Property(col => col.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(9,2)")
                .IsRequired();

            builder
                .Property(col => col.Saldo)
                .HasColumnName("Saldo")
                .HasColumnType("decimal(9,2)")
                .IsRequired();


            builder
                .HasOne(col => col.Cuenta)
                .WithMany(col => col.Movimientos)
                .HasForeignKey(p => p.NumeroCuenta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Cuenta_Movimientos");

        }
    }
}
