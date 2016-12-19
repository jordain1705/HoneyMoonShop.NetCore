using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using HoneymoonShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


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
        public DbSet<Accessoire> Accessoire { get; set; }
        public DbSet<AccessoireAfbeeldingen> AccessoireAfbeeldingenen { get; set; }
        public DbSet<KledingAfbeeldingen> KledingAfbeeldingenen { get; set; }
        public DbSet<KledingKleuren> KledingKleurenen { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary keys
            modelBuilder.Entity<Kleding>().HasKey(p => p.Artikelnummer);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.Id);
            modelBuilder.Entity<Accessoire>().HasKey(p => p.AccessoireId);

            //relatie: kleding-afspraak
            modelBuilder.Entity<KledingAfspraak>()
                .HasKey(t => new { t.Artikelnummer, t.Id });

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAfspraken)
                .HasForeignKey(ka => ka.Artikelnummer);

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Afspraak)
                .WithMany(a => a.KledingAfspraken)
                .HasForeignKey(ka => ka.Id);

            //relatie: multivalued attribuut Afbeelding
            modelBuilder.Entity<KledingAfbeeldingen>().HasKey(ka => ka.KledingAfbeelding);
            modelBuilder.Entity<KledingAfbeeldingen>().HasKey(ka => ka.Artikelnummer);

            modelBuilder.Entity<KledingAfbeeldingen>()
                .HasOne(kb => kb.Kleding)
                .WithMany(kp => kp.KledingAfbeeldingen)
                .HasForeignKey(kb => kb.Artikelnummer);

            //relatie: mutivalued attribuut Kleur
            modelBuilder.Entity<KledingKleuren>().HasKey(kk => kk.KledingKleur);
            modelBuilder.Entity<KledingKleuren>().HasKey(kk => kk.Artikelnummer);

            modelBuilder.Entity<KledingKleuren>()
                .HasOne(kb => kb.Kleding)
                .WithMany(kp => kp.KledingKleuren)
                .HasForeignKey(kb => kb.Artikelnummer);

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

            //relatie: multivalued attribuut Afbeelding
            modelBuilder.Entity<AccessoireAfbeeldingen>().HasKey(aa => aa.AccessoireId);
            modelBuilder.Entity<AccessoireAfbeeldingen>().HasKey(aa => aa.AccessoireAfbeelding);

            modelBuilder.Entity<AccessoireAfbeeldingen>()
                .HasOne(ak => ak.Accessoire)
                .WithMany(ak => ak.AccessoireAfbeeldingen)
                .HasForeignKey(ak => ak.AccessoireId);
        }
    }
}
