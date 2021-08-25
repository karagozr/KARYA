using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldDizaynDetayAltMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DizaynDetayAlt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DizaynDetayId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DizaynDetayAlt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DizaynDetayAlt_DizaynDetay_DizaynDetayId",
                        column: x => x.DizaynDetayId,
                        principalTable: "DizaynDetay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DizaynDetayAlt_DizaynDetayId",
                table: "DizaynDetayAlt",
                column: "DizaynDetayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DizaynDetayAlt");
        }
    }
}
