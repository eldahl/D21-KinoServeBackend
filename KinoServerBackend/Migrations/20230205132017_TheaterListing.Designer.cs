﻿// <auto-generated />
using KinoServerBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KinoServerBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230205132017_TheaterListing")]
    partial class TheaterListing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KinoServerBackend.Model.Theater", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Theaters");
                });
#pragma warning restore 612, 618
        }
    }
}