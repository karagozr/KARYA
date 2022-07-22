using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class hanelapp_oto_fatura_migartion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaturaTarihi",
                table: "OtoFatura",
                newName: "CariKodu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CariKodu",
                table: "OtoFatura",
                newName: "FaturaTarihi");
        }
    }
}
