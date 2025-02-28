using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sandwitch.Tier.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class DeletedIndexation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Viento_Name",
                table: "Viento");

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

            migrationBuilder.CreateIndex(
                name: "IX_Viento_Name_Deleted",
                table: "Viento",
                columns: new[] { "Name", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_Name_Deleted",
                table: "Provincia",
                columns: new[] { "Name", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Poblacion_Name_Deleted",
                table: "Poblacion",
                columns: new[] { "Name", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Bandera_Name_Deleted",
                table: "Bandera",
                columns: new[] { "Name", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Arenal_Name_Deleted",
                table: "Arenal",
                columns: new[] { "Name", "Deleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Viento_Name_Deleted",
                table: "Viento");

            migrationBuilder.DropIndex(
                name: "IX_Provincia_Name_Deleted",
                table: "Provincia");

            migrationBuilder.DropIndex(
                name: "IX_Poblacion_Name_Deleted",
                table: "Poblacion");

            migrationBuilder.DropIndex(
                name: "IX_Bandera_Name_Deleted",
                table: "Bandera");

            migrationBuilder.DropIndex(
                name: "IX_Arenal_Name_Deleted",
                table: "Arenal");

            migrationBuilder.CreateIndex(
                name: "IX_Viento_Name",
                table: "Viento",
                column: "Name");

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
    }
}
