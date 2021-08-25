using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldStokHaraketCariEklendiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "StokHaraket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StokHaraket_CariId",
                table: "StokHaraket",
                column: "CariId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHaraket_Cari_CariId",
                table: "StokHaraket",
                column: "CariId",
                principalTable: "Cari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHaraket_Cari_CariId",
                table: "StokHaraket");

            migrationBuilder.DropIndex(
                name: "IX_StokHaraket_CariId",
                table: "StokHaraket");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "StokHaraket");
        }
    }
}
