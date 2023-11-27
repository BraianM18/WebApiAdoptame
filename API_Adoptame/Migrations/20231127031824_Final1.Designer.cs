﻿// <auto-generated />
using System;
using API_Adoptame.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Adoptame.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20231127031824_Final1")]
    partial class Final1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_Adoptame.DAL.Entities.AdoptionDetail", b =>
                {
                    b.Property<Guid>("IDadoptiondetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AdoptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdoptionStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PetID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDadoptiondetail");

                    b.HasIndex("PetID")
                        .IsUnique()
                        .HasFilter("[PetID] IS NOT NULL");

                    b.ToTable("AdoptionDetails");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.Fundation", b =>
                {
                    b.Property<Guid>("IDfundation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IDfundation");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Fundations");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.Pet", b =>
                {
                    b.Property<Guid>("IDpet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdoptionDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FundationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Race")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IDpet");

                    b.HasIndex("FundationID");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("IDuser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("IDuser");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.AdoptionDetail", b =>
                {
                    b.HasOne("API_Adoptame.DAL.Entities.Pet", "Pet")
                        .WithOne("AdoptionDetail")
                        .HasForeignKey("API_Adoptame.DAL.Entities.AdoptionDetail", "PetID");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.Pet", b =>
                {
                    b.HasOne("API_Adoptame.DAL.Entities.Fundation", null)
                        .WithMany("Pets")
                        .HasForeignKey("FundationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.Fundation", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("API_Adoptame.DAL.Entities.Pet", b =>
                {
                    b.Navigation("AdoptionDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
