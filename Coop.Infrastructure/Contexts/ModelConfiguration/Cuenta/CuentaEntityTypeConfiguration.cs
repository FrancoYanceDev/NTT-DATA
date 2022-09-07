
using Coop.Domain.Cuenta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coop.Infrastructure.Contexts.ModelConfiguration.Cuenta
{
    public class CuentaEntityTypeConfiguration : IEntityTypeConfiguration<CuentaModel>
    {
        public void Configure(EntityTypeBuilder<CuentaModel> builder)
        {
            builder
                 .ToTable("Cuentas")
                 .HasKey(c => c.NumeroCuenta);

            builder
                .Property(col => col.NumeroCuenta)
                .HasColumnName("NumeroCuenta")
                .HasDefaultValueSql("NEWID()")
                .IsRequired();

            builder
                .Property(col => col.TipoCuenta)
                .HasColumnName("TipoCuenta")
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder
                .Property(col => col.SaldoInicial)
                .HasColumnName("SaldoInicial")
                .HasColumnType("decimal(9,2)")
                .IsRequired();

            builder
                .Property(col => col.CuentaEstado)
                .HasColumnName("CuentaEstado")
                .HasColumnType("bit")
                .IsRequired();


            builder
                .HasOne(col => col.Cliente)
                .WithMany(col => col.Cuentas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Cliente_Cuentas");
        }
    }
}
