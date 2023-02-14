﻿// <auto-generated />
using System;
using CategoryService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CategoryService.Persistence.Migrations
{
    [DbContext(typeof(CategoryDbContext))]
    [Migration("20221124192033_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryService.Domain.Category.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("category", "category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9cd89eb-3ea9-489c-b19f-7c8b65f156bc"),
                            Description = "Bilim kurgu kategorisi",
                            Name = "Bilim Kurgu"
                        },
                        new
                        {
                            Id = new Guid("ecb2303c-7161-4db5-ab46-10df4b1fc409"),
                            Description = "Korku kategorisi",
                            Name = "Korku"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}