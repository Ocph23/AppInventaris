using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppInventaris.Migrations
{
    /// <inheritdoc />
    public partial class penilaian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Penilaian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PenilaiId = table.Column<string>(type: "text", nullable: true),
                    PimpinanId = table.Column<string>(type: "text", nullable: true),
                    StatusPenilaian = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penilaian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penilaian_AspNetUsers_PenilaiId",
                        column: x => x.PenilaiId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Penilaian_AspNetUsers_PimpinanId",
                        column: x => x.PimpinanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatatanPenilaian",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tanggal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: false),
                    PemberiCatatanId = table.Column<string>(type: "text", nullable: false),
                    PenilaianId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatatanPenilaian", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatatanPenilaian_AspNetUsers_PemberiCatatanId",
                        column: x => x.PemberiCatatanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatatanPenilaian_Penilaian_PenilaianId",
                        column: x => x.PenilaianId,
                        principalTable: "Penilaian",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PenilaianItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BarangId = table.Column<int>(type: "integer", nullable: false),
                    StatusPenilaian = table.Column<int>(type: "integer", nullable: false),
                    Catatan = table.Column<string>(type: "text", nullable: true),
                    PenilaianId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenilaianItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PenilaianItem_ItemBarang_BarangId",
                        column: x => x.BarangId,
                        principalTable: "ItemBarang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PenilaianItem_Penilaian_PenilaianId",
                        column: x => x.PenilaianId,
                        principalTable: "Penilaian",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatatanPenilaian_PemberiCatatanId",
                table: "CatatanPenilaian",
                column: "PemberiCatatanId");

            migrationBuilder.CreateIndex(
                name: "IX_CatatanPenilaian_PenilaianId",
                table: "CatatanPenilaian",
                column: "PenilaianId");

            migrationBuilder.CreateIndex(
                name: "IX_Penilaian_PenilaiId",
                table: "Penilaian",
                column: "PenilaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Penilaian_PimpinanId",
                table: "Penilaian",
                column: "PimpinanId");

            migrationBuilder.CreateIndex(
                name: "IX_PenilaianItem_BarangId",
                table: "PenilaianItem",
                column: "BarangId");

            migrationBuilder.CreateIndex(
                name: "IX_PenilaianItem_PenilaianId",
                table: "PenilaianItem",
                column: "PenilaianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatatanPenilaian");

            migrationBuilder.DropTable(
                name: "PenilaianItem");

            migrationBuilder.DropTable(
                name: "Penilaian");
        }
    }
}
