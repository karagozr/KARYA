using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KARYA.DATAACCESS.Migrations
{
    public partial class KaryaFirstMigration : Migration
    {
      
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppModule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultAuthorize = table.Column<bool>(type: "bit", nullable: false),
                    RecordBasedAuthorize = table.Column<bool>(type: "bit", nullable: false),
                    FieldGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGroupId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizeGroupDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorizeGroupId = table.Column<int>(type: "int", nullable: false),
                    AppModuleId = table.Column<int>(type: "int", nullable: false),
                    IsAuthorize = table.Column<bool>(type: "bit", nullable: false),
                    FilterRule = table.Column<short>(type: "smallint", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterValue1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterValue2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeGroupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizeGroupDetail_AppModule_AppModuleId",
                        column: x => x.AppModuleId,
                        principalTable: "AppModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorizeGroupDetail_AuthorizeGroup_AuthorizeGroupId",
                        column: x => x.AuthorizeGroupId,
                        principalTable: "AuthorizeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldGroupId = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldType = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_FieldGroup_FieldGroupId",
                        column: x => x.FieldGroupId,
                        principalTable: "FieldGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthorizeGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuthorizeGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthorizeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuthorizeGroup_AuthorizeGroup_AuthorizeGroupId",
                        column: x => x.AuthorizeGroupId,
                        principalTable: "AuthorizeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAuthorizeGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizeGroupDetailFieldAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorizeGroupDetailId = table.Column<int>(type: "int", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetsubCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Write = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeGroupDetailFieldAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizeGroupDetailFieldAccess_AuthorizeGroupDetail_AuthorizeGroupDetailId",
                        column: x => x.AuthorizeGroupDetailId,
                        principalTable: "AuthorizeGroupDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizeGroupDetail_AppModuleId",
                table: "AuthorizeGroupDetail",
                column: "AppModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizeGroupDetail_AuthorizeGroupId",
                table: "AuthorizeGroupDetail",
                column: "AuthorizeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizeGroupDetailFieldAccess_AuthorizeGroupDetailId",
                table: "AuthorizeGroupDetailFieldAccess",
                column: "AuthorizeGroupDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_FieldGroupId",
                table: "Field",
                column: "FieldGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorizeGroup_AuthorizeGroupId",
                table: "UserAuthorizeGroup",
                column: "AuthorizeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorizeGroup_UserId",
                table: "UserAuthorizeGroup",
                column: "UserId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizeGroupDetailFieldAccess");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "UserAuthorizeGroup");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "AuthorizeGroupDetail");

            migrationBuilder.DropTable(
                name: "FieldGroup");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AppModule");

            migrationBuilder.DropTable(
                name: "AuthorizeGroup");
        }
    }
}
