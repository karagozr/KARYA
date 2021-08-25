using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldBelgeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Belge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DizaynId = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Not1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Not2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Belge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Belge_Dizayn_DizaynId",
                        column: x => x.DizaynId,
                        principalTable: "Dizayn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BelgeDetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BelgeId = table.Column<int>(type: "int", nullable: false),
                    DizaynDetayId = table.Column<int>(type: "int", nullable: true),
                    Not = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Double = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelgeDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BelgeDetay_Belge_BelgeId",
                        column: x => x.BelgeId,
                        principalTable: "Belge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BelgeDetay_DizaynDetay_DizaynDetayId",
                        column: x => x.DizaynDetayId,
                        principalTable: "DizaynDetay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Belge_DizaynId",
                table: "Belge",
                column: "DizaynId");

            migrationBuilder.CreateIndex(
                name: "IX_BelgeDetay_BelgeId",
                table: "BelgeDetay",
                column: "BelgeId");

            migrationBuilder.CreateIndex(
                name: "IX_BelgeDetay_DizaynDetayId",
                table: "BelgeDetay",
                column: "DizaynDetayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BelgeDetay");

            migrationBuilder.DropTable(
                name: "Belge");
        }
    }
}
