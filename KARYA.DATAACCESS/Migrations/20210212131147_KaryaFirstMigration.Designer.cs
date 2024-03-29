﻿// <auto-generated />
using System;
using KARYA.DATAACCESS.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KARYA.DATAACCESS.Migrations
{
    [DbContext(typeof(KaryaContext))]
    [Migration("20210212131147_KaryaFirstMigration")]
    partial class KaryaFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AppModule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("DefaultAuthorize")
                        .HasColumnType("bit");

                    b.Property<int>("FieldGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<bool>("RecordBasedAuthorize")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AppModule");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuthorizeGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppModuleId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorizeGroupId")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("FilterRule")
                        .HasColumnType("smallint");

                    b.Property<string>("FilterValue1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilterValue2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAuthorize")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AppModuleId");

                    b.HasIndex("AuthorizeGroupId");

                    b.ToTable("AuthorizeGroupDetail");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetailFieldAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorizeGroupDetailId")
                        .HasColumnType("int");

                    b.Property<string>("BudgetsubCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Delete")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<bool>("Write")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizeGroupDetailId");

                    b.ToTable("AuthorizeGroupDetailFieldAccess");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldGroupId")
                        .HasColumnType("int");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("FieldType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("FieldGroupId");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.FieldGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FieldGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.UserAuthorizeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorizeGroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizeGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthorizeGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("EMail")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetail", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Karya.AppModule", "AppModule")
                        .WithMany()
                        .HasForeignKey("AppModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KARYA.MODEL.Entities.Karya.AuthorizeGroup", "AuthorizeGroup")
                        .WithMany("AuthorizeGroupDetails")
                        .HasForeignKey("AuthorizeGroupId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("AppModule");

                    b.Navigation("AuthorizeGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetailFieldAccess", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetail", "AuthorizeGroupDetail")
                        .WithMany("AuthorizeGroupDetailFieldAccessList")
                        .HasForeignKey("AuthorizeGroupDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorizeGroupDetail");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.Field", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Karya.FieldGroup", "FieldsGroup")
                        .WithMany("Fields")
                        .HasForeignKey("FieldGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FieldsGroup");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.UserAuthorizeGroup", b =>
                {
                    b.HasOne("KARYA.MODEL.Entities.Karya.AuthorizeGroup", "AuthorizeGroup")
                        .WithMany("UserAuthorizeGroups")
                        .HasForeignKey("AuthorizeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KARYA.MODEL.Entities.Karya.Users", "User")
                        .WithMany("UserAuthorizeGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorizeGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroup", b =>
                {
                    b.Navigation("AuthorizeGroupDetails");

                    b.Navigation("UserAuthorizeGroups");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.AuthorizeGroupDetail", b =>
                {
                    b.Navigation("AuthorizeGroupDetailFieldAccessList");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.FieldGroup", b =>
                {
                    b.Navigation("Fields");
                });

            modelBuilder.Entity("KARYA.MODEL.Entities.Karya.Users", b =>
                {
                    b.Navigation("UserAuthorizeGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
