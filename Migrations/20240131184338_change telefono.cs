using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prio.Migrations
{
    /// <inheritdoc />
    public partial class changetelefono : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(
				name: "Teléfono",
				table: "Clientes",
				newName: "Telefono");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.RenameColumn(
				name: "Teléfono",
				table: "Clientes",
				newName: "Telefono");

		}
	}
}
