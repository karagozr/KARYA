using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigration_ReportCode3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntegrationCode",
                table: "ReportCode",
                newName: "IntegrationCode3");

            migrationBuilder.AddColumn<string>(
                name: "IntegrationCode1",
                table: "ReportCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntegrationCode2",
                table: "ReportCode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpanded",
                table: "ReportCode",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntegrationCode1",
                table: "ReportCode");

            migrationBuilder.DropColumn(
                name: "IntegrationCode2",
                table: "ReportCode");

            migrationBuilder.DropColumn(
                name: "IsExpanded",
                table: "ReportCode");

            migrationBuilder.RenameColumn(
                name: "IntegrationCode3",
                table: "ReportCode",
                newName: "IntegrationCode");
        }
    }
}
