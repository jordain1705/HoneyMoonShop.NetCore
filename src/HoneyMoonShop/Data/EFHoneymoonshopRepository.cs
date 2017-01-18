using System;
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
        public IEnumerable<Afspraak> Afspraken => context.Afspraak;

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

        public void SaveAfspraak(Afspraak afspraak)
        {
            if (afspraak.AfspraakId == 0)
            {
                context.Afspraak.Add(afspraak);
            }
            else
            {
                Afspraak dbEntry = context.Afspraak
                    .FirstOrDefault(p => p.AfspraakId == afspraak.AfspraakId);
                if (dbEntry != null)
                {
                    dbEntry.Achternaam = afspraak.Achternaam;
                    dbEntry.Voornaam = afspraak.Voornaam;
                    dbEntry.DatumTijd = afspraak.DatumTijd;
                    dbEntry.EmailAdres = afspraak.EmailAdres;
                    dbEntry.SoortAfspraak = afspraak.SoortAfspraak;
                    dbEntry.TelefoonNummer = afspraak.TelefoonNummer;
                    dbEntry.Trouwdatum = afspraak.Trouwdatum;
                }
            }
            context.SaveChanges();
        }
        public Afspraak DeleteAfspraak(int afspraakId)
        {
            Afspraak dbEntry = context.Afspraak
                .FirstOrDefault(p => p.AfspraakId == afspraakId);
            if (dbEntry != null)
            {
                context.Afspraak.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
