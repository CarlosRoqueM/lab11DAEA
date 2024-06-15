﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab11DAEA.Models;

#nullable disable

namespace lab11DAEA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240615172046_v4 - lab13")]
    partial class v4lab13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lab11DAEA.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("documentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("lab11DAEA.Models.Detail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Invoiceid")
                        .HasColumnType("int");

                    b.Property<int>("InvoicesId")
                        .HasColumnType("int");

                    b.Property<int>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float>("subTotal")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("Invoiceid");

                    b.HasIndex("Productid");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("lab11DAEA.Models.Invoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("invoiceNumbre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("lab11DAEA.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("lab11DAEA.Models.Detail", b =>
                {
                    b.HasOne("lab11DAEA.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("Invoiceid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab11DAEA.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("lab11DAEA.Models.Invoice", b =>
                {
                    b.HasOne("lab11DAEA.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
