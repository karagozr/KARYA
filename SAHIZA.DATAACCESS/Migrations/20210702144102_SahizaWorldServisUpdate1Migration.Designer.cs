﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SAHIZA.DATAACCESS.Concrete.EntityFramework;

namespace SAHIZA.DATAACCESS.Migrations
{
    [DbContext(typeof(SahizaWorldContext))]
    [Migration("20210702144102_SahizaWorldServisUpdate1Migration")]
    partial class SahizaWorldServisUpdate1Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Belge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("DizaynId")
                        .HasColumnType("int");

                    b.Property<string>("Not1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Not2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DizaynId");

                    b.ToTable("Belge");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.BelgeDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BelgeId")
                        .HasColumnType("int");

                    b.Property<bool>("Bool")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("DecimalNumber")
                        .HasColumnType("float");

                    b.Property<int?>("DizaynDetayId")
                        .HasColumnType("int");

                    b.Property<string>("Not1")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BelgeId");

                    b.HasIndex("DizaynDetayId");

                    b.ToTable("BelgeDetay");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Cari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Aciklama2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Adres")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CariAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CariKodu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<short>("CariTip")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Eposta")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GrupKod1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GrupKod2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Il")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ilce")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RaporKod1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RaporKod2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TcNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Tel1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tel2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("VergiDairesi")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("VergiNo")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Cari");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Dizayn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("DizaynAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DizaynKodu")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Dizayn");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.DizaynDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<short>("DataTipi")
                        .HasColumnType("smallint");

                    b.Property<string>("Deger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DizaynId")
                        .HasColumnType("int");

                    b.Property<int>("Sira")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DizaynId");

                    b.ToTable("DizaynDetay");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Stok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Aciklama2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Birim")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("GarantiSuresiAy")
                        .HasColumnType("int");

                    b.Property<string>("GrupKod1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GrupKod2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("RaporKod1")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("RaporKod2")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double>("SatisFiyati")
                        .HasColumnType("float");

                    b.Property<short>("SatisParaBirimi")
                        .HasColumnType("smallint");

                    b.Property<string>("StokAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<short>("StokDurum")
                        .HasColumnType("smallint");

                    b.Property<string>("StokKodu")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<double>("VergiOrani")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Stok");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.StokHaraket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CariId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("float");

                    b.Property<DateTime>("GarantiBaslangic")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GarantiVar")
                        .HasColumnType("bit");

                    b.Property<double>("Miktar")
                        .HasColumnType("float");

                    b.Property<short>("ParaBirimi")
                        .HasColumnType("smallint");

                    b.Property<short>("StokHaraketTur")
                        .HasColumnType("smallint");

                    b.Property<int>("StokId")
                        .HasColumnType("int");

                    b.Property<double>("Tutar")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<double>("VergiOrani")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.HasIndex("StokId");

                    b.ToTable("StokHaraket");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Belge", b =>
                {
                    b.HasOne("SAHIZA.MODEL.Entities.Dizayn", "Dizayn")
                        .WithMany()
                        .HasForeignKey("DizaynId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dizayn");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.BelgeDetay", b =>
                {
                    b.HasOne("SAHIZA.MODEL.Entities.Belge", "Belge")
                        .WithMany("BelgeDetays")
                        .HasForeignKey("BelgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAHIZA.MODEL.Entities.DizaynDetay", "DizaynDetay")
                        .WithMany("BelgeDetays")
                        .HasForeignKey("DizaynDetayId");

                    b.Navigation("Belge");

                    b.Navigation("DizaynDetay");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.DizaynDetay", b =>
                {
                    b.HasOne("SAHIZA.MODEL.Entities.Dizayn", "Dizayn")
                        .WithMany("DizaynDetays")
                        .HasForeignKey("DizaynId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dizayn");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.StokHaraket", b =>
                {
                    b.HasOne("SAHIZA.MODEL.Entities.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAHIZA.MODEL.Entities.Stok", "Stok")
                        .WithMany()
                        .HasForeignKey("StokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cari");

                    b.Navigation("Stok");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Belge", b =>
                {
                    b.Navigation("BelgeDetays");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.Dizayn", b =>
                {
                    b.Navigation("DizaynDetays");
                });

            modelBuilder.Entity("SAHIZA.MODEL.Entities.DizaynDetay", b =>
                {
                    b.Navigation("BelgeDetays");
                });
#pragma warning restore 612, 618
        }
    }
}
