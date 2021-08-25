﻿// <auto-generated />
using System;
using HANEL.DATAACCESS.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HANEL.DATAACCESS.Migrations
{
    [DbContext(typeof(HanelContext))]
    [Migration("20210311154349_HanelMigrationFaturaServis")]
    partial class HanelMigrationFaturaServis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BudgetMainCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("BudgetSubCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("BudgetTaxMultiplier")
                        .HasColumnType("float");

                    b.Property<short>("BudgetType")
                        .HasColumnType("smallint");

                    b.Property<short>("BudgetYear")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SiteCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.BudgetDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<short>("BudgetMonth")
                        .HasColumnType("smallint");

                    b.Property<short>("BudgetYear")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<string>("UnitCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetDetail");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.BudgetExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<string>("MainCurrencyCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("PeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BudgetExchangeRate");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.BudgetSubDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Agustos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Aralik")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Ekim")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Eylul")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Haziran")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Kasim")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Mart")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Mayis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Nisan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ocak")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Subat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Temmuz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetSubDetail");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.PivotReportTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("JsonData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PivotReportTemplate");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.Fatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlanAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlanPosta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlanTckn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlanVkn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BelgeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("BelgeTipi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaturaNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaturaTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GelisTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenEPosta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenFax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenIl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenIlce")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenPosta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenTckn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GonderenVkn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sira")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamVergi")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Fatura");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.FaturaKalem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaturaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Miktar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sira")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FaturaId");

                    b.ToTable("FaturaKalem");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.FaturaVergiKalem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaturaId")
                        .HasColumnType("int");

                    b.Property<string>("Kod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Matrah")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Oran")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VergiTutari")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FaturaId");

                    b.ToTable("FaturaVergiKalem");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.BudgetDetail", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Finance.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Finance.BudgetSubDetail", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Finance.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.FaturaKalem", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.HanelApp.Fatura", "Fatura")
                        .WithMany("FaturaKalems")
                        .HasForeignKey("FaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fatura");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.FaturaVergiKalem", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.HanelApp.Fatura", "Fatura")
                        .WithMany("FaturaVergiKalems")
                        .HasForeignKey("FaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fatura");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.HanelApp.Fatura", b =>
                {
                    b.Navigation("FaturaKalems");

                    b.Navigation("FaturaVergiKalems");
                });
#pragma warning restore 612, 618
        }
    }
}
