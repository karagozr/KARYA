using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAHIZA.DATAACCESS.Migrations
{
    public partial class SahizaWorldStokCariStokHaraketUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KdvOrani",
                table: "StokHaraket",
                newName: "VergiOrani");

            migrationBuilder.AddColumn<DateTime>(
                name: "GarantiBaslangic",
                table: "StokHaraket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "GarantiVar",
                table: "StokHaraket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "ParaBirimi",
                table: "StokHaraket",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "GarantiSuresiAy",
                table: "Stok",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SatisFiyati",
                table: "Stok",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<short>(
                name: "SatisParaBirimi",
                table: "Stok",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<double>(
                name: "VergiOrani",
                table: "Stok",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "VergiNo",
                table: "Cari",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "VergiDairesi",
                table: "Cari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "TcNo",
                table: "Cari",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GarantiBaslangic",
                table: "StokHaraket");

            migrationBuilder.DropColumn(
                name: "GarantiVar",
                table: "StokHaraket");

            migrationBuilder.DropColumn(
                name: "ParaBirimi",
                table: "StokHaraket");

            migrationBuilder.DropColumn(
                name: "GarantiSuresiAy",
                table: "Stok");

            migrationBuilder.DropColumn(
                name: "SatisFiyati",
                table: "Stok");

            migrationBuilder.DropColumn(
                name: "SatisParaBirimi",
                table: "Stok");

            migrationBuilder.DropColumn(
                name: "VergiOrani",
                table: "Stok");

            migrationBuilder.RenameColumn(
                name: "VergiOrani",
                table: "StokHaraket",
                newName: "KdvOrani");

            migrationBuilder.AlterColumn<string>(
                name: "VergiNo",
                table: "Cari",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VergiDairesi",
                table: "Cari",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TcNo",
                table: "Cari",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
