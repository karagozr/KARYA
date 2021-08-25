using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigrationFaturaServis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sira = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelgeTipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BelgeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GelisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenTckn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenVkn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenIl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenIlce = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenEPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GonderenFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanTckn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanVkn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlanPosta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToplamVergi = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaturaKalem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    Sira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaKalem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaKalem_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaVergiKalem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matrah = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VergiTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaVergiKalem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaVergiKalem_Fatura_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Fatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalem_FaturaId",
                table: "FaturaKalem",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaVergiKalem_FaturaId",
                table: "FaturaVergiKalem",
                column: "FaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaKalem");

            migrationBuilder.DropTable(
                name: "FaturaVergiKalem");

            migrationBuilder.DropTable(
                name: "Fatura");
        }
    }
}
