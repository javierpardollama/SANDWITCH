using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class ImageUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Provincia",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Poblacion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Bandera",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Poblacion");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Bandera");
        }
    }
}
