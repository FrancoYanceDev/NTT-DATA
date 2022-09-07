using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coop.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Edad = table.Column<byte>(type: "tinyint", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Contrasena = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ClienteEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PersonaId);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId");
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    NumeroCuenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TipoCuenta = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SaldoInicial = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    CuentaEstado = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.NumeroCuenta);
                    table.ForeignKey(
                        name: "FK_Cliente_Cuentas",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    MovimientoTipo = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    NumeroCuenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_Cuenta_Movimientos",
                        column: x => x.NumeroCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "NumeroCuenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_NumeroCuenta",
                table: "Movimientos",
                column: "NumeroCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
