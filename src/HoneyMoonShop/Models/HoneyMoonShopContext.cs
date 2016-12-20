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
        public DbSet<Accessoire> Accessoire { get; set; }
        public DbSet<Jurk> Jurken { get; set; }
        public DbSet<Pak> Pakken { get; set; }
        public DbSet<Kleur> Kleuren { get; set; }
        public DbSet<Afbeelding> Afbeeldingen { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary keys
            modelBuilder.Entity<Jurk>().HasKey(p => p.JurkId);
            modelBuilder.Entity<Pak>().HasKey(p => p.PakId);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.AfspraakId);
            modelBuilder.Entity<Accessoire>().HasKey(p => p.AccessoireId);
            modelBuilder.Entity<Kleur>().HasKey(k => k.KleurId);
            modelBuilder.Entity<Afbeelding>().HasKey(a => a.AfbeeldingId);

            //relatie: pak-afspraak n>n
            modelBuilder.Entity<PakAfspraak>()
                .HasKey(t => new { t.PakId, t.Id });

            modelBuilder.Entity<PakAfspraak>()
                .HasOne(ka => ka.Pak)
                .WithMany(k => k.PakAfspraken)
                .HasForeignKey(ka => ka.PakId);

            modelBuilder.Entity<PakAfspraak>()
                .HasOne(ka => ka.Afspraak)
                .WithMany(a => a.PakAfspraken)
                .HasForeignKey(ka => ka.Id);

            //relatie: jurk-afspraak n>n
            modelBuilder.Entity<JurkAfspraak>()
               .HasKey(t => new { t.JurkId, t.Id });

            modelBuilder.Entity<JurkAfspraak>()
                .HasOne(ka => ka.Jurk)
                .WithMany(k => k.JurkAfspraken)
                .HasForeignKey(ka => ka.JurkId);

            modelBuilder.Entity<JurkAfspraak>()
                .HasOne(ka => ka.Afspraak)
                .WithMany(a => a.JurkAfspraken)
                .HasForeignKey(ka => ka.Id);

            //relatie: jurk-accessoire n>n
            modelBuilder.Entity<JurkAccessoire>()
                .HasKey(t => new { t.JurkId, t.AccessoireId });

            modelBuilder.Entity<JurkAccessoire>()
                .HasOne(ka => ka.Jurk)
                .WithMany(k => k.JurkAccessoires)
                .HasForeignKey(ka => ka.JurkId);

            modelBuilder.Entity<JurkAccessoire>()
                .HasOne(ja => ja.Accessoire)
                .WithMany(ja => ja.JurkAccessoires)
                .HasForeignKey(ja => ja.AccessoireId);

            //relatie: pak-accessoire n>n
            modelBuilder.Entity<PakAccessoire>()
                .HasKey(t => new { t.PakId, t.AccessoireId });

            modelBuilder.Entity<PakAccessoire>()
                .HasOne(ka => ka.Pak)
                .WithMany(k => k.PakAccessoires)
                .HasForeignKey(ka => ka.PakId);

            modelBuilder.Entity<PakAccessoire>()
                .HasOne(ka => ka.Accessoire)
                .WithMany(a => a.PakAccessoires)
                .HasForeignKey(ka => ka.AccessoireId);

            //relatie: jurk afbeelding n>1
            modelBuilder.Entity<Afbeelding>()
                .HasOne(ja => ja.Jurk)
                .WithMany(ja => ja.Afbeeldingen);
            //relatie: pak afbeelding n>1
            modelBuilder.Entity<Afbeelding>()
                .HasOne(ja => ja.Pak)
                .WithMany(ja => ja.Afbeeldingen);
            //relatie: accessore afbeelding n>1
            modelBuilder.Entity<Afbeelding>()
                .HasOne(ja => ja.Accessoire)
                .WithMany(ja => ja.Afbeeldingen);
            //relatie: jurk kleur n>n
            modelBuilder.Entity<JurkKleur>()
                .HasKey(t => new { t.JurkId, t.KleurId });

            modelBuilder.Entity<JurkKleur>()
                .HasOne(ka => ka.Jurk)
                .WithMany(k => k.JurkKleuren)
                .HasForeignKey(ka => ka.JurkId);

            modelBuilder.Entity<JurkKleur>()
                .HasOne(ka => ka.Kleur)
                .WithMany(a => a.JurkKleuren)
                .HasForeignKey(ka => ka.KleurId);
            //relatie: pak kleur n>n
            modelBuilder.Entity<PakKleur>()
                .HasKey(t => new { t.PakId, t.KleurId });

            modelBuilder.Entity<PakKleur>()
                .HasOne(ka => ka.Pak)
                .WithMany(k => k.PakKleuren)
                .HasForeignKey(ka => ka.PakId);

            modelBuilder.Entity<PakKleur>()
                .HasOne(ka => ka.Kleur)
                .WithMany(a => a.PakKleuren)
                .HasForeignKey(ka => ka.KleurId);
        }
    }
}
