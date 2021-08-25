using System;
using HANEL.MODEL.Module;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetType = table.Column<short>(type: "smallint", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SiteCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BudgetMainCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BudgetSubCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BudgetYear = table.Column<short>(type: "smallint", nullable: false),
                    BudgetTaxMultiplier = table.Column<double>(type: "float", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetExchangeRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainCurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetExchangeRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PivotReportTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PivotReportTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(type: "int", nullable: false),
                    PeriodDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BudgetYear = table.Column<short>(type: "smallint", nullable: false),
                    BudgetMonth = table.Column<short>(type: "smallint", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetDetail_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BudgetSubDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ocak = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mart = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nisan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mayis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Haziran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Temmuz = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Agustos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Eylul = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ekim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kasim = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aralik = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetSubDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetSubDetail_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDetail_BudgetId",
                table: "BudgetDetail",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetSubDetail_BudgetId",
                table: "BudgetSubDetail",
                column: "BudgetId");

            migrationBuilder.Sql($"{AppModuleMigrationHelper.CreateInstallationQuery("HANEL_APP_SYS", new HanelModules())}  USE HANEL_APP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetDetail");

            migrationBuilder.DropTable(
                name: "BudgetExchangeRate");

            migrationBuilder.DropTable(
                name: "BudgetSubDetail");

            migrationBuilder.DropTable(
                name: "PivotReportTemplate");

            migrationBuilder.DropTable(
                name: "Budget");
        }
    }
}
