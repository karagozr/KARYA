using KARYA.DATAACCESS.Middlewares;
using Microsoft.EntityFrameworkCore.Migrations;
using SAHIZA.MODEL.Module;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldAppModuleUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"{AppModuleMigrationHelper.CreateUpdateQuery("SAHIZA_WORLD_SYS", new SahizaModules())}  USE SAHIZA_WORLD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
