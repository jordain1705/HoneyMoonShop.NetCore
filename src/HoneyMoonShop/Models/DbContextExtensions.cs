using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HoneymoonShop.Models
{
    public static class DbContextExtensions
    {
        /*
         * http://stackoverflow.com/questions/38034137/asp-net-core-rc2-seed-database
         * https://blogs.msdn.microsoft.com/dotnet/2016/09/29/implementing-seeding-custom-conventions-and-interceptors-in-ef-core-1-0/
          */
        public static void Seed(this HoneyMoonShopContext context)
        {
            // Perform database delete and create
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Perform seed functions
            AddKleding(context);
            AddJurk(context);
            AddAccessoires(context);

            // Save changes and release resources
            context.SaveChanges();
            context.Dispose();
        }

        private static void AddAccessoires(HoneyMoonShopContext context)
        {
            context.AddRange(
                
                );
        }

        private static void AddJurk(HoneyMoonShopContext context)
        {
           
        }

        private static void AddKleding(HoneyMoonShopContext context)
        {
            context.AddRange(
                new Kleding { Artikelnummer = 12649, Merk = "Ladybird", Omschrijving = "test Omschrijving", MinPrijs = 1500, MaxPrijs = 1750},
                new Kleding { Artikelnummer = 12810, Merk = "Diane Legrand", Omschrijving = "Test omschrijving 3", MinPrijs = 1250, MaxPrijs = 1500},
                new Kleding { Artikelnummer = 12746, Merk = "Pronovias", Omschrijving = "Test Omschrijving 4", MinPrijs = 2250, MaxPrijs = 2500},
                new Kleding { Artikelnummer = 12695, Merk = "Maggie Sottero", Omschrijving = "Test Omschrijving 5", MinPrijs = 2000, MaxPrijs = 2250},
                new Kleding { Artikelnummer = 12925, Merk = "Eddy K.", Omschrijving = "TestomSchrijvdkld", MinPrijs = 1750, MaxPrijs = 2000},
                new Kleding { Artikelnummer = 12627, Merk = "Ladybird", Omschrijving = "zelfde dingen", MinPrijs = 1250, MaxPrijs = 1500}
                );
        }
    }
}
