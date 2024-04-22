using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sandwitch.Tier.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class Viento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Velocidad",
                table: "Historico",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "VientoId",
                table: "Historico",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Viento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_VientoId",
                table: "Historico",
                column: "VientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viento_Name",
                table: "Viento",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Historico_Viento_VientoId",
                table: "Historico",
                column: "VientoId",
                principalTable: "Viento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historico_Viento_VientoId",
                table: "Historico");

            migrationBuilder.DropTable(
                name: "Viento");

            migrationBuilder.DropIndex(
                name: "IX_Historico_VientoId",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "Velocidad",
                table: "Historico");

            migrationBuilder.DropColumn(
                name: "VientoId",
                table: "Historico");
        }
    }
}
