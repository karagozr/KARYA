using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldMigrationCari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariKodu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CariAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CariTip = table.Column<short>(type: "smallint", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Aciklama1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Aciklama2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Il = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ilce = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Eposta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tel1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tel2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrupKod1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GrupKod2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RaporKod1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RaporKod2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cari", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cari");
        }
    }
}
