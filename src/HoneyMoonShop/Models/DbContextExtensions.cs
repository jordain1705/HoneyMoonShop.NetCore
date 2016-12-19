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
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            // Perform seed operations
            AddKleding(context);

            // Save changes and release resources
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing ON");
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ReferenceThing OFF");
            context.Dispose();
        }

        private static void AddKleding(HoneyMoonShopContext context)
        {
            context.AddRange(
                new Kleding { Artikelnummer = 12649, Merk = "Ladybird", Omschrijving = "test Omschrijving", Prijs = 1500 }

                );
        }
    }
}
