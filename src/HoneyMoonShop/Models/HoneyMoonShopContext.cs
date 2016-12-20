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
        public DbSet<Accessoire> Accessoire { get; set; }
        public DbSet<AccessoireAfbeeldingen> AccessoireAfbeeldingenSet { get; set; }
        public DbSet<KledingAfbeeldingen> KledingAfbeeldingenSet{ get; set; }
        public DbSet<KledingKleuren> KledingKleurenSet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary keys
            modelBuilder.Entity<Kleding>().HasKey(p => p.KledingId);
            modelBuilder.Entity<Afspraak>().HasKey(p => p.AfspraakId);
            modelBuilder.Entity<Accessoire>().HasKey(p => p.AccessoireId);

            //relatie: kleding-afspraak
            modelBuilder.Entity<KledingAfspraak>()
                .HasKey(t => new { t.KledingId, t.Id });

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAfspraken)
                .HasForeignKey(ka => ka.KledingId);

            modelBuilder.Entity<KledingAfspraak>()
                .HasOne(ka => ka.Afspraak)
                .WithMany(a => a.KledingAfspraken)
                .HasForeignKey(ka => ka.Id);

            //relatie: multivalued attribuut Afbeelding
            modelBuilder.Entity<KledingAfbeeldingen>().HasKey(kb => kb.KledingAfbeeldingId);
            modelBuilder.Entity<KledingAfbeeldingen>().HasKey(kb => kb.KledingId);

            modelBuilder.Entity<KledingAfbeeldingen>()
                .HasOne(kb => kb.Kleding)
                .WithMany(kp => kp.KledingAfbeeldingen)
                .HasForeignKey(kb => kb.KledingAfbeeldingId);

            //relatie: mutivalued attribuut Kleur
            modelBuilder.Entity<KledingKleuren>().HasKey(kk => kk.KledingKleurenId);
            modelBuilder.Entity<KledingKleuren>().HasKey(kk => kk.KledingId);

            modelBuilder.Entity<KledingKleuren>()
                .HasOne(kb => kb.Kleding)
                .WithMany(kp => kp.KledingKleuren)
                .HasForeignKey(kb => kb.KledingId);

            //relatie: kleding-accessoire
            modelBuilder.Entity<KledingAccessoire>()
                .HasKey(t => new { t.KledingId, t.AccessoireId });

            modelBuilder.Entity<KledingAccessoire>()
                .HasOne(ka => ka.Kleding)
                .WithMany(k => k.KledingAccessoires)
                .HasForeignKey(ka => ka.KledingId);

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
            modelBuilder.Entity<AccessoireAfbeeldingen>().HasKey(aa => aa.AccessoireAfbeeldingId);

            modelBuilder.Entity<AccessoireAfbeeldingen>()
                .HasOne(ak => ak.Accessoire)
                .WithMany(ak => ak.AccessoireAfbeeldingen)
                .HasForeignKey(ak => ak.AccessoireId);
        }
    }
}
