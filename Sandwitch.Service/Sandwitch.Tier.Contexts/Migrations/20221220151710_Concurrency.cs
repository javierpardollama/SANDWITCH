using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sandwitch.Tier.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class Concurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Provincia",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Poblacion",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Historico",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Bandera",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "ArenalPoblacion",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Arenal",
                type: "BLOB",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Poblacion");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Bandera");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "ArenalPoblacion");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Arenal");
        }
    }
}
