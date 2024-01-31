using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prio.Migrations
{
    /// <inheritdoc />
    public partial class changedescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(
				name: "Descripción",
				table: "Prioridades",
				newName: "Descripcion");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(
				name: "Descripción",
				table: "Prioridades",
				newName: "Descripcion");
		}
    }
}
