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
         */
        public HoneyMoonShopContext(DbContextOptions<HoneyMoonShopContext> options) : base(options)
        {
        }

        //public DbSet<Accessoire> AccessoireDbSet { get; set; }
        //public DbSet<Afspraak> AfspraakDbSet { get; set; }
        public DbSet<Jurk> JurkDbSet { get; set; }
        //public DbSet<Pak> PakDbSet { get; set; }
        public DbSet<Kleding> KledingDbSet { get; set; }
        //public DbSet<KledingKleur> KledingKleurDbSet { get; set; }
    }
}
