﻿// <auto-generated />
using System;
using AdvertService.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvertService.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230227001441_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdvertService.DAL.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ownerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("performerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("adverts");
                });

            modelBuilder.Entity("AdvertService.DAL.Entities.AdvertToRequests", b =>
                {
                    b.Property<int>("advertId")
                        .HasColumnType("int");

                    b.Property<int>("requestId")
                        .HasColumnType("int");

                    b.HasKey("advertId", "requestId");

                    b.ToTable("advertsToRequests");
                });

            modelBuilder.Entity("AdvertService.DAL.Entities.AdvertToRequests", b =>
                {
                    b.HasOne("AdvertService.DAL.Entities.Advert", "advert")
                        .WithMany("advertToRequest")
                        .HasForeignKey("advertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("advert");
                });

            modelBuilder.Entity("AdvertService.DAL.Entities.Advert", b =>
                {
                    b.Navigation("advertToRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
