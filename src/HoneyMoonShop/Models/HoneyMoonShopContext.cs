using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneymoonShop.Models;
using Microsoft.EntityFrameworkCore;


namespace HoneymoonShop.Models
{
    public class HoneyMoonShopContext : DbContext
    {
        /* comands:
         * add-migration "name-migration" -context HoneyMoonShopContext
         * remove-migration = commit verwijderen
         * update-database -context HoneyMoonShopContext = push naar database
         * https://docs.microsoft.com/en-us/ef/core/modeling/relationships
         */

        public HoneyMoonShopContext(DbContextOptions<HoneyMoonShopContext> options) : base(options)
        {
        }

        public DbSet<Afspraak> Afspraak { get; set; }
        public DbSet<Kleding> Kleding { get; set; }
        public DbSet<Jurk> Jurk { get; set; }
        public DbSet<Pak> Pak { get; set; }
        public DbSet<Accessoire> Accessoire { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kleding>().HasKey(p => p.Artikelnummer);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.Id);

            modelBuilder.Entity<KledingAfspraak>()
                .HasKey(t => new {t.Artikelnummer, t.Id});

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAfspraken)
                .HasForeignKey(ka => ka.Artikelnummer);

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Afspraak)
                .WithMany(a => a.KledingAfspraken)
                .HasForeignKey(ka => ka.Id);
        }
    }
}
