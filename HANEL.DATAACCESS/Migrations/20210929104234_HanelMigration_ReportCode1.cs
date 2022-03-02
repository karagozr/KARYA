using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigration_ReportCode1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ReportCode");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReportCode",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "ReportCode",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntegrationCode",
                table: "ReportCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "ReportCode");

            migrationBuilder.DropColumn(
                name: "IntegrationCode",
                table: "ReportCode");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ReportCode",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ReportCode",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
