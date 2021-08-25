using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANEL.DATAACCESS.Migrations
{
    public partial class HanelFaturaUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlanAdi",
                table: "Fatura",
                newName: "GonderenUnvan");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "FaturaVergiKalem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "FaturaVergiKalem",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "ParaBirimi",
                table: "FaturaKalem",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "Fatura",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GonderenAdi",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GelisTarihi",
                table: "Fatura",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlanUnvan",
                table: "Fatura",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GonderenSoyad",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OdenecekTutar",
                table: "Fatura",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "TevkifatliFatura",
                table: "Fatura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamFiyat",
                table: "Fatura",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamTutar",
                table: "Fatura",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParaBirimi",
                table: "FaturaKalem");

            migrationBuilder.DropColumn(
                name: "AlanUnvan",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "GonderenSoyad",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "OdenecekTutar",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "TevkifatliFatura",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "Fatura");

            migrationBuilder.DropColumn(
                name: "ToplamTutar",
                table: "Fatura");

            migrationBuilder.RenameColumn(
                name: "GonderenUnvan",
                table: "Fatura",
                newName: "AlanAdi");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "FaturaVergiKalem",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "FaturaVergiKalem",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "Fatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "GonderenAdi",
                table: "Fatura",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GelisTarihi",
                table: "Fatura",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50);
        }
    }
}
