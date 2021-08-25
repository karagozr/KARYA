using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldServisUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisIslemTur = table.Column<short>(type: "smallint", nullable: false),
                    ServisDurum = table.Column<short>(type: "smallint", nullable: false),
                    StokHaraketId = table.Column<int>(type: "int", nullable: true),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    UrunBilgisi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: true),
                    MusteriBilgisi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MusteriAdres = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Not1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Not2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tel1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servis_Cari_CariId",
                        column: x => x.CariId,
                        principalTable: "Cari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servis_Stok_StokId",
                        column: x => x.StokId,
                        principalTable: "Stok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servis_StokHaraket_StokHaraketId",
                        column: x => x.StokHaraketId,
                        principalTable: "StokHaraket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServisMalzeme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServisId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: true),
                    MalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    VergiOrani = table.Column<double>(type: "float", nullable: false),
                    Tutar = table.Column<double>(type: "float", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisMalzeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServisMalzeme_Servis_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisMalzeme_Stok_StokId",
                        column: x => x.StokId,
                        principalTable: "Stok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servis_CariId",
                table: "Servis",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_StokHaraketId",
                table: "Servis",
                column: "StokHaraketId");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_StokId",
                table: "Servis",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisMalzeme_ServisId",
                table: "ServisMalzeme",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisMalzeme_StokId",
                table: "ServisMalzeme",
                column: "StokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServisMalzeme");

            migrationBuilder.DropTable(
                name: "Servis");
        }
    }
}
