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
         * 
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
            modelBuilder.Entity<Jurk>().HasKey(p => p.KledingId);
            modelBuilder.Entity<Pak>().HasKey(p => p.PakId);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.AfspraakId);
            modelBuilder.Entity<Accessoire>().HasKey(p => p.AccessoireId);
            modelBuilder.Entity<Kleur>().HasKey(k => k.KleurId);
            modelBuilder.Entity<Afbeelding>().HasKey(a => a.AfbeeldingId);

            //relatie: pak-afspraak n>n
            modelBuilder.Entity<PakAfspraak>()
                .HasKey(t => new { t.PakId, t.Id});

            modelBuilder.Entity<PakAfspraak>()
                .HasOne(ka => ka.Pak)
                .WithMany(k => k.KledingAfspraken)
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
            modelBuilder.Entity<>()
                .HasKey(t => new { t.KledingId, t.AccessoireId });

            modelBuilder.Entity<KledingAccessoire>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAccessoires)
                .HasForeignKey(ka => ka.KledingId);

            modelBuilder.Entity<KledingAccessoire>()
                .HasOne(ka => ka.Accessoire)
                .WithMany(a => a.KledingAccessoires)
                .HasForeignKey(ka => ka.AccessoireId);

            //relatie: pak-accessoire n>n
            modelBuilder.Entity<PakAccessoire>()
                .HasKey(t => new { t.PakId, t.AccessoireId });

            modelBuilder.Entity<PakAccessoire>()
                .HasOne(ka => ka.Pak)
                .WithMany(k => k.PakAccessoires)
                .HasForeignKey(ka => ka.PakId);

            modelBuilder.Entity<PakAccessoire>()
                .HasOne(ka => ka.Accessoire)
                .WithMany(a => a.)
                .HasForeignKey(ka => ka.AccessoireId);

            //relatie: jurk afbeelding n>n
            //relatie: pak afbeelding n>n
            //relatie: jurk kleur n>n
            //relatie: pak kleur n>n
            //relatie: accessore afbeelding n>n
        }
    }
}
