﻿// <auto-generated />
using System;
using Coop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coop.Infrastructure.Migrations
{
    [DbContext(typeof(CoopContext))]
    partial class CoopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Coop.Domain.Cliente.Models.PersonaModel", b =>
                {
                    b.Property<Guid>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Direccion");

                    b.Property<byte>("Edad")
                        .HasColumnType("tinyint")
                        .HasColumnName("Edad");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Genero");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Identificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Telefono");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas", (string)null);
                });

            modelBuilder.Entity("Coop.Domain.Cuenta.Models.CuentaModel", b =>
                {
                    b.Property<Guid>("NumeroCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NumeroCuenta")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CuentaEstado")
                        .HasColumnType("bit")
                        .HasColumnName("CuentaEstado");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(9,2)")
                        .HasColumnName("SaldoInicial");

                    b.Property<string>("TipoCuenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TipoCuenta");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuentas", (string)null);
                });

            modelBuilder.Entity("Coop.Domain.Movimiento.Models.MovimientoModel", b =>
                {
                    b.Property<Guid>("MovimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MovimientoId")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("Fecha");

                    b.Property<string>("MovimientoTipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("MovimientoTipo");

                    b.Property<Guid>("NumeroCuenta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(9,2)")
                        .HasColumnName("Saldo");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(9,2)")
                        .HasColumnName("Valor");

                    b.HasKey("MovimientoId");

                    b.HasIndex("NumeroCuenta");

                    b.ToTable("Movimientos", (string)null);
                });

            modelBuilder.Entity("Coop.Domain.Cliente.Models.ClienteModel", b =>
                {
                    b.HasBaseType("Coop.Domain.Cliente.Models.PersonaModel");

                    b.Property<bool>("ClienteEstado")
                        .HasColumnType("bit")
                        .HasColumnName("ClienteEstado");

                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClienteId")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Contrasena");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Coop.Domain.Cuenta.Models.CuentaModel", b =>
                {
                    b.HasOne("Coop.Domain.Cliente.Models.ClienteModel", "Cliente")
                        .WithMany("Cuentas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Cuentas");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Coop.Domain.Movimiento.Models.MovimientoModel", b =>
                {
                    b.HasOne("Coop.Domain.Cuenta.Models.CuentaModel", "Cuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("NumeroCuenta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Cuenta_Movimientos");

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("Coop.Domain.Cliente.Models.ClienteModel", b =>
                {
                    b.HasOne("Coop.Domain.Cliente.Models.PersonaModel", null)
                        .WithOne()
                        .HasForeignKey("Coop.Domain.Cliente.Models.ClienteModel", "PersonaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Coop.Domain.Cuenta.Models.CuentaModel", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("Coop.Domain.Cliente.Models.ClienteModel", b =>
                {
                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
