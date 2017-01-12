using System.Collections.Generic;
using System.Linq;
using HoneymoonShop.Models;

namespace HoneymoonShop.Data
{
    internal class EfHoneymoonshopRepository : IHoneymoonshopRepository
    {
        private HoneyMoonShopContext context;

        public EfHoneymoonshopRepository(HoneyMoonShopContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Jurk> Jurken => context.Jurken;

        public void SaveJurk(Jurk jurk)
        {
            if (jurk.JurkId == 0)
            {
                context.Jurken.Add(jurk);
            }
            else
            {
                Jurk dbEntry = context.Jurken
                    .FirstOrDefault(p => p.JurkId == jurk.JurkId);
                if (dbEntry != null)
                {
                    dbEntry.Artikelnummer = jurk.Artikelnummer;
                    dbEntry.Merk = jurk.Merk;
                    dbEntry.Stijl = jurk.Stijl;
                    dbEntry.MinPrijs = jurk.MinPrijs;
                    dbEntry.MaxPrijs = jurk.MaxPrijs;
                    dbEntry.Neklijn = jurk.Neklijn;
                    dbEntry.Silhouette = jurk.Silhouette;
                }
            }
            context.SaveChanges();
        }

        public Jurk DeleteJurk(int jurkId)
        {
            Jurk dbEntry = context.Jurken
                .FirstOrDefault(p => p.JurkId == jurkId);
            if (dbEntry != null)
            {
                context.Jurken.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
