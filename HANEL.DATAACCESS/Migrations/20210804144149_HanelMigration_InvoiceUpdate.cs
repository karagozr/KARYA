using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelMigration_InvoiceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ToplamVergi",
                table: "FaturaKalem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DefaultNote",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNotes",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FaturaKalemVergi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaKalemId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Matrah = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oran = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VergiTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaKalemVergi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaKalemVergi_FaturaKalem_FaturaKalemId",
                        column: x => x.FaturaKalemId,
                        principalTable: "FaturaKalem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalemVergi_FaturaKalemId",
                table: "FaturaKalemVergi",
                column: "FaturaKalemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaKalemVergi");

            migrationBuilder.DropColumn(
                name: "ToplamVergi",
                table: "FaturaKalem");

            migrationBuilder.DropColumn(
                name: "DefaultNote",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "UserNotes",
                table: "Fatura");
        }
    }
}
