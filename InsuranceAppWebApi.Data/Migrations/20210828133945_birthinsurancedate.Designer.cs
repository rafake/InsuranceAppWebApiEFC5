﻿// <auto-generated />
using System;
using InsuranceAppWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceAppWebApi.Data.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20210828133945_birthinsurancedate")]
    partial class birthinsurancedate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.InsuranceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceId");

                    b.ToTable("InsuranceCompanies");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Insuree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsuranceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Insurees");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.InsureeInsurance", b =>
                {
                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("InsureeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("InsuranceId", "InsureeId");

                    b.HasIndex("InsureeId");

                    b.ToTable("InsureeInsurance");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InsureeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InsureeId")
                        .IsUnique();

                    b.ToTable("Partner");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.InsuranceCompany", b =>
                {
                    b.HasOne("InsuranceAppWebApi.Domain.Insurance", "Insurance")
                        .WithMany("InsuranceCompanies")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insurance");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.InsureeInsurance", b =>
                {
                    b.HasOne("InsuranceAppWebApi.Domain.Insurance", null)
                        .WithMany()
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceAppWebApi.Domain.Insuree", null)
                        .WithMany()
                        .HasForeignKey("InsureeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Partner", b =>
                {
                    b.HasOne("InsuranceAppWebApi.Domain.Insuree", null)
                        .WithOne("Partner")
                        .HasForeignKey("InsuranceAppWebApi.Domain.Partner", "InsureeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Insurance", b =>
                {
                    b.Navigation("InsuranceCompanies");
                });

            modelBuilder.Entity("InsuranceAppWebApi.Domain.Insuree", b =>
                {
                    b.Navigation("Partner");
                });
#pragma warning restore 612, 618
        }
    }
}
