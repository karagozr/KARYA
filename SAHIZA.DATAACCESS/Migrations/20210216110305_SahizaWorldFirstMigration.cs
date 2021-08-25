using System;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.EntityFrameworkCore.Migrations;
using SAHIZA.MODEL.Module;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StokAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StokDurum = table.Column<short>(type: "smallint", maxLength: 200, nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GrupKod1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GrupKod2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RaporKod1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RaporKod2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StokHaraket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StokHaraketTur = table.Column<short>(type: "smallint", nullable: false),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    KdvOrani = table.Column<double>(type: "float", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tutar = table.Column<double>(type: "float", nullable: false),
                    StokId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHaraket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokHaraket_Stok_StokId1",
                        column: x => x.StokId1,
                        principalTable: "Stok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StokHaraket_StokId1",
                table: "StokHaraket",
                column: "StokId1");

            migrationBuilder.Sql($"{AppModuleMigrationHelper.CreateInstallationQuery("SAHIZA_WORLD_SYS", new SahizaModules())}  USE SAHIZA_WORLD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StokHaraket");

            migrationBuilder.DropTable(
                name: "Stok");
        }
    }
}
