using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpikeProjPR.Models;

namespace SpikeProjPR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SpikeProjPR.Models.Beekeeper> Beekeepers { get; set; }
        public DbSet<SpikeProjPR.Models.Apiary> Apiaries { get; set; }
        public DbSet<SpikeProjPR.Models.Hive> Hives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beekeeper>().ToTable("Beekeepers");
            modelBuilder.Entity<Apiary>().ToTable("Apiaries");
            modelBuilder.Entity<Hive>().ToTable("Hives");
            base.OnModelCreating(modelBuilder);
        }

    }
}
