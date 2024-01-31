using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prio.Migrations
{
    /// <inheritdoc />
    public partial class Tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrioridadID",
                table: "Prioridades",
                newName: "PrioridadId");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Clientes",
                newName: "ClienteId");

            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    SistemaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.SistemaId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    SistemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrioridadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Solicitante = table.Column<string>(type: "TEXT", nullable: false),
                    Asunto = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sistema");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.RenameColumn(
                name: "PrioridadId",
                table: "Prioridades",
                newName: "PrioridadID");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "ClienteID");
        }
    }
}
