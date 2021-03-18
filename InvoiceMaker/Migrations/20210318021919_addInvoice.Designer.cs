﻿// <auto-generated />
using System;
using InvoiceMaker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceMaker.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210318021919_addInvoice")]
    partial class addInvoice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvoiceMaker.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Currency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyID")
                        .HasColumnType("int");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<string>("DiscountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDue")
                        .HasColumnType("datetime2");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseOrderID")
                        .HasColumnType("int");

                    b.Property<int>("To")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CurrencyID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("PurchaseOrderID")
                        .IsUnique();

                    b.HasIndex("To");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("InvoiceMaker.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("InvoiceMaker.Models.UnitMeasurement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UnitMeasurements");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Invoice", b =>
                {
                    b.HasOne("InvoiceMaker.Models.Currency", "Currency")
                        .WithMany("Invoices")
                        .HasForeignKey("CurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceMaker.Models.Language", "Language")
                        .WithMany("Invoices")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceMaker.Models.PurchaseOrder", "PurchaseOrder")
                        .WithOne("Invoice")
                        .HasForeignKey("InvoiceMaker.Models.Invoice", "PurchaseOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceMaker.Models.Company", "Company")
                        .WithMany("Invoices")
                        .HasForeignKey("To")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Currency");

                    b.Navigation("Language");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Company", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Currency", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("InvoiceMaker.Models.Language", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("InvoiceMaker.Models.PurchaseOrder", b =>
                {
                    b.Navigation("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}