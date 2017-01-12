using System;
using HoneymoonShop.Models;

namespace HoneymoonShop.Data
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
            context.Database.EnsureDeleted(); //disable this for faster startup but it wont check if any datachanges has occured
            context.Database.EnsureCreated(); //disable this for faster startup but it wont check if any datachanges has occured

            // Perform seed functions
            AddJurk(context);
            AddAccessoires(context);

            // Save changes and release resources
            context.SaveChanges();
            context.Dispose();
        }

        private static void AddAccessoires(HoneyMoonShopContext context)
        {
            context.AddRange(
                new Accessoire { AccessoireCode = 12857, Categorie = "Schoenen", Geslacht = "Vrouw", LinkNaarWebshop = "http://www.honeymoonwebshop.nl/shop/Brooke-II-p-17310.html", Merk = "Elsa Coloured Shoes" },
                new Accessoire { AccessoireCode = 12419, Categorie = "Lingerie", Geslacht = "Vrouw", LinkNaarWebshop = "http://www.honeymoonwebshop.nl/shop/30304-BH-p-16668.html", Merk = "Di Lorenzo" },
                new Accessoire { AccessoireCode = 10809, Categorie = "Tasjes", Geslacht = "Vrouw", LinkNaarWebshop = "http://www.honeymoonwebshop.nl/shop/Tilly-p-16618.html", Merk = "Elsa Coloured Shoes" }
                );
        }

        private static void AddJurk(HoneyMoonShopContext context)
        {
            Jurk jurk;
            context.Add(
                jurk =
                    new Jurk()
                    {
                        Artikelnummer = 12649,
                        Merk = "Ladybird",
                        Omschrijving =
                            "Trouwjurk van het merk Ladybird gemaakt van kant. De top is strapless met een sweetheart lijn. De rok heeft een A-lijn met een sleep.",
                        MinPrijs = 1500,
                        MaxPrijs = 1750,
                        Neklijn = "Strapless",
                        Silhouette = "A-lijn",
                        Stijl = "Kant"
                    });
            AddAfbeelding(jurk, null, "12649", context);
            AddKleur(12649, "ff0000", "Rood", context);

            context.Add(new Jurk
            {
                Artikelnummer = 12810,
                Merk = "Diane Legrand",
                Omschrijving =
                    "Trouwjurk van het merk Diane Legrand gemaakt van kant. De top heeft een hoge doorzichtige neklijn en een laag uitgesneden rug, afgewerkt met beading. De rok is wijdvallend met een sleep.",
                MinPrijs = 1250,
                MaxPrijs = 1500,
                Neklijn = "Hoge neklijn",
                Silhouette = "Princess model",
                Stijl = "Prinses Bruid"
            });
            AddAfbeelding(jurk, null, "12810", context);
            AddKleur(12810, "#0ed61c", "Groen", context);

            context.Add(new Jurk
            {
                Artikelnummer = 12746,
                Merk = "Pronovias",
                Omschrijving =
                    "Trouwjurk van het merk Pronovias gemaakt van kant. De top is doorzichtig, heeft een hoge neklijn en een laag uitgesneden rug. De rok is wijdvallend met een sleep en is gemaakt van tulle.",
                MinPrijs = 2250,
                MaxPrijs = 2500,
                Neklijn = "Hoge neklijn",
                Silhouette = "Princess model",
                Stijl = "Prinses Bruid"
            });
            AddAfbeelding(jurk, null, "12746", context);
            AddKleur(12746, "7a3030", "Bruin", context);

            context.Add(new Jurk
            {
                Artikelnummer = 12695,
                Merk = "Maggie Sottero",
                Omschrijving =
                    "Trouwjurk van het merk Maggie Sottero gemaakt van organza. De hals is strapless met een sweetheart lijn. De top is afgewerkt met kant. De rok is wijdvallend met een sleep en is verwerkt in ruches.",
                MinPrijs = 2000,
                MaxPrijs = 2250,
                Neklijn = "Strapless",
                Silhouette = "Princess model",
                Stijl = "Kant"
            });

            AddAfbeelding(jurk, null, "12695", context);
            AddKleur(12695, "#FAC9C4", "Roze", context);

            context.Add(new Jurk
            {
                Artikelnummer = 12925,
                Merk = "Eddy K.",
                Omschrijving =
                    "Trouwjurk van het merk Eddy K. gemaakt van kant. De top is strapless met een lichte sweetheart lijn. De rok heeft een fishtail model met een sleep.",
                MinPrijs = 1750,
                MaxPrijs = 2000,
                Neklijn = "Strapless",
                Silhouette = "Fishtail",
                Stijl = "Kant"
            });
            AddAfbeelding(jurk, null, "12925", context);
            AddKleur(12925, "#1313c1", "blauw", context);

            context.Add(new Jurk
            {
                Artikelnummer = 12627,
                Merk = "Ladybird",
                Omschrijving =
                    "Trouwjurk van het merk Ladybird gemaakt van organza. De top heeft doorzichtige schouderbanden en een laag uitgesneden rug, beide afgewerkt met gekleurde kanten applicaties. De taille wordt geaccentueerd door een gekleurde riem, drapperie en kanten applicaties. De jurk heeft een A-lijn met sleep en kan gepast worden in de sand kleur.",
                MinPrijs = 1250,
                MaxPrijs = 1500,
                Neklijn = "Schouderbandjes",
                Silhouette = "A-lijn",
                Stijl = "Kleurrijke Bruid"
            });
            AddAfbeelding(jurk, null, "12627", context);
            AddKleur(12627, "#fff", "wit", context);
        }

        private static void AddAfbeelding(Jurk jurk, Pak pak, String sourcepath, HoneyMoonShopContext context)
        {
            context.AddRange(
                new Afbeelding { Jurk = jurk, Pak = null, SourcePath = "/" + sourcepath + "a" },
                new Afbeelding { Jurk = jurk, Pak = null, SourcePath = "/" + sourcepath + "b" },
                new Afbeelding { Jurk = jurk, Pak = null, SourcePath = "/" + sourcepath + "c" }
                );
        }

        private static void AddKleur(int artikelnummer, String hexacode, String kleurnaam, HoneyMoonShopContext context)
        {
            context.AddRange(
                new Kleur { Artikelnummer = artikelnummer, Hexacode = hexacode, KleurNaam = kleurnaam }
                );
        }
    }
}
