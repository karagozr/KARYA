using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class hanelapp_oto_fatura_migartion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama1",
                table: "OtoFatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama2",
                table: "OtoFatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OzelAd",
                table: "OtoFatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefGuid",
                table: "OtoFatura",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama1",
                table: "OtoFatura");

            migrationBuilder.DropColumn(
                name: "Aciklama2",
                table: "OtoFatura");

            migrationBuilder.DropColumn(
                name: "OzelAd",
                table: "OtoFatura");

            migrationBuilder.DropColumn(
                name: "RefGuid",
                table: "OtoFatura");
        }
    }
}
