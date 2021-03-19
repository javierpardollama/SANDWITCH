using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class Indexation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Provincia_Name",
                table: "Provincia",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Poblacion_Name",
                table: "Poblacion",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Bandera_Name",
                table: "Bandera",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Arenal_Name",
                table: "Arenal",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Provincia_Name",
                table: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Poblacion_Name",
                table: "Poblacion");

            migrationBuilder.DropIndex(
                name: "IX_Bandera_Name",
                table: "Bandera");

            migrationBuilder.DropIndex(
                name: "IX_Arenal_Name",
                table: "Arenal");
        }
    }
}
