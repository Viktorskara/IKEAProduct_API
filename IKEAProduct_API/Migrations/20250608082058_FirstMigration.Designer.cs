﻿// <auto-generated />
using System;
using IKEAProduct_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IKEAProduct_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250608082058_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IKEAProduct_API.Models.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ruby"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Green"
                        });
                });

            modelBuilder.Entity("IKEAProduct_API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "EKTORP",
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "POÄNG",
                            ProductTypeId = 2
                        });
                });

            modelBuilder.Entity("IKEAProduct_API.Models.ProductColour", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ColourId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ColourId");

                    b.HasIndex("ColourId");

                    b.ToTable("ProductColours");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ColourId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            ColourId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            ColourId = 3
                        });
                });

            modelBuilder.Entity("IKEAProduct_API.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sofa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chair"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Table"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nightstand"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Bookshelf"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dining Table"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Wardrobe"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Desk"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Lamp"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Recliner"
                        });
                });

            modelBuilder.Entity("IKEAProduct_API.Models.Product", b =>
                {
                    b.HasOne("IKEAProduct_API.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("IKEAProduct_API.Models.ProductColour", b =>
                {
                    b.HasOne("IKEAProduct_API.Models.Colour", "Colour")
                        .WithMany("ProductColours")
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IKEAProduct_API.Models.Product", "Product")
                        .WithMany("ProductColours")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colour");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IKEAProduct_API.Models.Colour", b =>
                {
                    b.Navigation("ProductColours");
                });

            modelBuilder.Entity("IKEAProduct_API.Models.Product", b =>
                {
                    b.Navigation("ProductColours");
                });

            modelBuilder.Entity("IKEAProduct_API.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
