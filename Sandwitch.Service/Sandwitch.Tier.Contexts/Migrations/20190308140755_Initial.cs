using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Sandwitch.Tier.Contexts.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arenal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arenal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    BanderaId = table.Column<int>(nullable: false),
                    ArenalId = table.Column<int>(nullable: false),
                    Temperatura = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historico_Arenal_ArenalId",
                        column: x => x.ArenalId,
                        principalTable: "Arenal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_Bandera_BanderaId",
                        column: x => x.BanderaId,
                        principalTable: "Bandera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poblacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProvinciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poblacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poblacion_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArenalPoblacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    ArenalId = table.Column<int>(nullable: false),
                    PoblacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenalPoblacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArenalPoblacion_Arenal_ArenalId",
                        column: x => x.ArenalId,
                        principalTable: "Arenal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArenalPoblacion_Poblacion_PoblacionId",
                        column: x => x.PoblacionId,
                        principalTable: "Poblacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArenalPoblacion_ArenalId",
                table: "ArenalPoblacion",
                column: "ArenalId");

            migrationBuilder.CreateIndex(
                name: "IX_ArenalPoblacion_PoblacionId",
                table: "ArenalPoblacion",
                column: "PoblacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_ArenalId",
                table: "Historico",
                column: "ArenalId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_BanderaId",
                table: "Historico",
                column: "BanderaId");

            migrationBuilder.CreateIndex(
                name: "IX_Poblacion_ProvinciaId",
                table: "Poblacion",
                column: "ProvinciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenalPoblacion");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "Poblacion");

            migrationBuilder.DropTable(
                name: "Arenal");

            migrationBuilder.DropTable(
                name: "Bandera");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
