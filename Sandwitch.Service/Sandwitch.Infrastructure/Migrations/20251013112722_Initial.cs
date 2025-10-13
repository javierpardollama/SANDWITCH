using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sandwitch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arenal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arenal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bandera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bandera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poblacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: false),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
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
                name: "Historico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BanderaId = table.Column<int>(type: "INTEGER", nullable: false),
                    VientoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArenalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Velocidad = table.Column<double>(type: "REAL", nullable: false),
                    Temperatura = table.Column<double>(type: "REAL", nullable: false),
                    BajaMarAlba = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    BajaMarOcaso = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    AltaMarAlba = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    AltaMarOcaso = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Historico_Viento_VientoId",
                        column: x => x.VientoId,
                        principalTable: "Viento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArenalPoblacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArenalId = table.Column<int>(type: "INTEGER", nullable: false),
                    PoblacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Version = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
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
                name: "IX_Historico_VientoId",
                table: "Historico",
                column: "VientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Poblacion_ProvinciaId",
                table: "Poblacion",
                column: "ProvinciaId");
        }

        /// <inheritdoc />
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
                name: "Viento");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
