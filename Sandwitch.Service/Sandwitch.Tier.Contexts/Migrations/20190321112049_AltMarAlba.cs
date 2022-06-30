using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class AltMarAlba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BajaMar",
                table: "Historico",
                newName: "BajaMarOcaso");

            migrationBuilder.RenameColumn(
                name: "AltaMar",
                table: "Historico",
                newName: "BajaMarAlba");

            migrationBuilder.AddColumn<DateTime>(
                name: "AltaMarAlba",
                table: "Historico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AltaMarOcaso",
                table: "Historico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltaMarAlba",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "AltaMarOcaso",
                table: "Historico");

            migrationBuilder.RenameColumn(
                name: "BajaMarOcaso",
                table: "Historico",
                newName: "BajaMar");

            migrationBuilder.RenameColumn(
                name: "BajaMarAlba",
                table: "Historico",
                newName: "AltaMar");
        }
    }
}
