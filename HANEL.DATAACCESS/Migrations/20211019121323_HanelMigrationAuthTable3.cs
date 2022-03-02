using HANEL.MODEL.Module;
using KARYA.DATAACCESS.Middlewares;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigrationAuthTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"{AppModuleMigrationHelper.CreateUpdateQuery("HANEL_APP_SYS", new HanelModules())}  USE HANEL_APP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
