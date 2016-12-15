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
        /* commands:
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
       // public DbSet<Jurk> Jurk { get; set; }
        //public DbSet<Pak> Pak { get; set; }
        public DbSet<Accessoire> Accessoire { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary keys
            modelBuilder.Entity<Kleding>().HasKey(p => p.Artikelnummer);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.Id);
            modelBuilder.Entity<Accessoire>().HasKey(p => p.AccessoireId);

            //relatie: kleding-afspraak
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

            //relatie: kleding-accessoire
            modelBuilder.Entity<KledingAccessoire>()
                .HasKey(t => new { t.Artikelnummer, t.AccessoireId });

            modelBuilder.Entity<KledingAccessoire>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAccessoires)
                .HasForeignKey(ka => ka.Artikelnummer);

            modelBuilder.Entity<KledingAccessoire>()
                .HasOne(ka => ka.Accessoire)
                .WithMany(a => a.KledingAccessoires)
                .HasForeignKey(ka => ka.AccessoireId);

            //relatie: overerving kleding-jas-pak
            modelBuilder.Entity<Kleding>()
                .HasDiscriminator<string>("Kleding_type")
                .HasValue<Kleding>("Kleding")
                .HasValue<Jurk>("Kleding_jurk")
                .HasValue<Pak>("Kleding_pak");
        }
    }
}
