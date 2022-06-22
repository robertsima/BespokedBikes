using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BespokedBikes.Models;

namespace BespokedBikes.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Sale> sales { get; set; }

        public DbSet<Sale> products { get; set; }

        public DbSet<Sale> salespeople { get; set; }

        public DbSet<Sale> customers { get; set; }

        public DbSet<Sale> discounts { get; set; }


    }
}
