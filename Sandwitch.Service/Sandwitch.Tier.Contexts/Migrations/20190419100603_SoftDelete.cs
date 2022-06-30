using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Provincia",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Poblacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Historico",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Bandera",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ArenalPoblacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Arenal",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Poblacion");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Bandera");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ArenalPoblacion");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Arenal");
        }
    }
}
