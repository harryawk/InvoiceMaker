
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
    }
}
