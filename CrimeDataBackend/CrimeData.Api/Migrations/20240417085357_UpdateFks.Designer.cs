﻿// <auto-generated />
using System;
using CrimeData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrimeData.Api.Migrations
{
    [DbContext(typeof(CrimeDataContext))]
    [Migration("20240417085357_UpdateFks")]
    partial class UpdateFks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrimeData.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiSourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiSourceId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.ApiSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceEndpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApiSource", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.Crime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApiSourceId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CrimeAgainstCategoryId")
                        .HasColumnType("int");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longtitde")
                        .HasColumnType("float");

                    b.Property<int?>("OffenseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OffenseStartDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReportDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiSourceId");

                    b.HasIndex("CityId");

                    b.HasIndex("CrimeAgainstCategoryId");

                    b.HasIndex("OffenseId");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("Crime", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.CrimeAgainstCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiSourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiSourceId");

                    b.ToTable("CrimeAgainstCategory", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.Offence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiSourceId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiSourceId");

                    b.ToTable("Offence", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.ParentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApiSourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CredatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApiSourceId");

                    b.ToTable("ParentGroup", (string)null);
                });

            modelBuilder.Entity("CrimeData.Entities.City", b =>
                {
                    b.HasOne("CrimeData.Entities.Tables.ApiSource", "ApiSource")
                        .WithMany()
                        .HasForeignKey("ApiSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiSource");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.Crime", b =>
                {
                    b.HasOne("CrimeData.Entities.Tables.ApiSource", "ApiSource")
                        .WithMany("Crimes")
                        .HasForeignKey("ApiSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrimeData.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("CrimeData.Entities.Tables.CrimeAgainstCategory", "CrimeAgainstCategory")
                        .WithMany("Crimes")
                        .HasForeignKey("CrimeAgainstCategoryId");

                    b.HasOne("CrimeData.Entities.Tables.Offence", "Offence")
                        .WithMany("Crimes")
                        .HasForeignKey("OffenseId");

                    b.HasOne("CrimeData.Entities.Tables.ParentGroup", "ParentGroup")
                        .WithMany("Crimes")
                        .HasForeignKey("ParentGroupId");

                    b.Navigation("ApiSource");

                    b.Navigation("City");

                    b.Navigation("CrimeAgainstCategory");

                    b.Navigation("Offence");

                    b.Navigation("ParentGroup");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.CrimeAgainstCategory", b =>
                {
                    b.HasOne("CrimeData.Entities.Tables.ApiSource", "ApiSource")
                        .WithMany("CrimeAgainsCategories")
                        .HasForeignKey("ApiSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiSource");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.Offence", b =>
                {
                    b.HasOne("CrimeData.Entities.Tables.ApiSource", "ApiSource")
                        .WithMany("Offences")
                        .HasForeignKey("ApiSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiSource");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.ParentGroup", b =>
                {
                    b.HasOne("CrimeData.Entities.Tables.ApiSource", "ApiSource")
                        .WithMany("ParentGroups")
                        .HasForeignKey("ApiSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiSource");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.ApiSource", b =>
                {
                    b.Navigation("CrimeAgainsCategories");

                    b.Navigation("Crimes");

                    b.Navigation("Offences");

                    b.Navigation("ParentGroups");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.CrimeAgainstCategory", b =>
                {
                    b.Navigation("Crimes");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.Offence", b =>
                {
                    b.Navigation("Crimes");
                });

            modelBuilder.Entity("CrimeData.Entities.Tables.ParentGroup", b =>
                {
                    b.Navigation("Crimes");
                });
#pragma warning restore 612, 618
        }
    }
}
