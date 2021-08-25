using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldStohHaraketUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHaraket_Stok_StokId1",
                table: "StokHaraket");

            migrationBuilder.DropIndex(
                name: "IX_StokHaraket_StokId1",
                table: "StokHaraket");

            migrationBuilder.DropColumn(
                name: "StokId1",
                table: "StokHaraket");

            migrationBuilder.AlterColumn<int>(
                name: "StokId",
                table: "StokHaraket",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_StokHaraket_StokId",
                table: "StokHaraket",
                column: "StokId");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHaraket_Stok_StokId",
                table: "StokHaraket",
                column: "StokId",
                principalTable: "Stok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StokHaraket_Stok_StokId",
                table: "StokHaraket");

            migrationBuilder.DropIndex(
                name: "IX_StokHaraket_StokId",
                table: "StokHaraket");

            migrationBuilder.AlterColumn<string>(
                name: "StokId",
                table: "StokHaraket",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StokId1",
                table: "StokHaraket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StokHaraket_StokId1",
                table: "StokHaraket",
                column: "StokId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StokHaraket_Stok_StokId1",
                table: "StokHaraket",
                column: "StokId1",
                principalTable: "Stok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
