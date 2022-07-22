using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class hanelapp_oto_fatura_detay_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtoFaturaDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtoFaturaId = table.Column<int>(type: "int", nullable: false),
                    HashKalem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StokKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MuhasebeKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kdv = table.Column<double>(type: "float", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    ProjeKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KalemAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaturaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtoFaturaDetay", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtoFaturaDetay");
        }
    }
}
