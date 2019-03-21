using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class AltMar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AltaMar",
                table: "Historico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BajaMar",
                table: "Historico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltaMar",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "BajaMar",
                table: "Historico");
        }
    }
}
