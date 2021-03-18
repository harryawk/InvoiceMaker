
using InvoiceMaker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMaker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        

        public DbSet<Language> Languages { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<UnitMeasurement> UnitMeasurements { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Invoice>()
            //    .HasOne(i => i.Company)
            //    .WithMany(c => c.Invoices)
            //    .HasForeignKey(i => i.To)
            //    .IsRequired();

            //modelBuilder.Entity<Invoice>()
            //    .HasOne(i => i.Currency)
            //    .WithMany(c => c.Invoices)
            //    .HasForeignKey(i => i.CurrencyID)
            //    .IsRequired();

            //modelBuilder.Entity<Invoice>()
            //    .HasOne(i => i.PurchaseOrder)
            //    .WithOne(p => p.Invoice)
            //    .HasForeignKey<Invoice>(i => i.PurchaseOrderID);

        }
    }
}
