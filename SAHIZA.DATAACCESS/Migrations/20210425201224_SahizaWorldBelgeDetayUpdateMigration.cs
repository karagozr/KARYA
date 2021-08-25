using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldBelgeDetayUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Not",
                table: "BelgeDetay",
                newName: "Not1");

            migrationBuilder.RenameColumn(
                name: "Double",
                table: "BelgeDetay",
                newName: "DecimalNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Not1",
                table: "BelgeDetay",
                newName: "Not");

            migrationBuilder.RenameColumn(
                name: "DecimalNumber",
                table: "BelgeDetay",
                newName: "Double");
        }
    }
}
