using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigrationUserReportFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportCodeUserFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntegrationCode1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IntegrationCode2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntegrationCode3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessRead = table.Column<bool>(type: "bit", nullable: false),
                    AccessAdd = table.Column<bool>(type: "bit", nullable: false),
                    AccessUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AccessDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCodeUserFilter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportCodeUserFilter");
        }
    }
}
