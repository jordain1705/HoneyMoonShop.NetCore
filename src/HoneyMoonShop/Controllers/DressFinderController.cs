using System;
using System.Collections.Generic;
using System.Linq;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class DressFinderController : Controller
    {
        public IActionResult Dressfinder()
        {
            using (var context = new HoneyMoonShopContext())
            {
                // .Where(b => b.Artikelnummer.Equals(12649));
                List<string> alleMerken = context.Jurken.Select(g => g.Merk).Distinct().ToList();
                ViewData["merken"] = alleMerken;

                List<string> alleStijlen = context.Jurken.Select(g => g.Stijl).Distinct().ToList();
                ViewData["stijlen"] = alleStijlen;
                List<int> minprijs = context.Jurken.Select(g => g.MinPrijs).ToList();

                ViewData["minprijs"] = minprijs.Min();

                List<int> maxprijs = context.Jurken.Select(g => g.MaxPrijs).ToList();
                ViewData["maxprijs"] = maxprijs.Max();

                List<string> neklijnen = context.Jurken.Select(g => g.Neklijn).Distinct().ToList();
                ViewData["neklijnen"] = neklijnen;

                List<string> silhouettes = context.Jurken.Select(g => g.Silhouette).Distinct().ToList();
                ViewData["silhouette"] = silhouettes;

                List<Jurk> jurken = context.Jurken.ToList();
                ViewData["jurken"] = jurken;

                List<string> kleuren = new List<String> { "ivoor/wit", "ivoor met kleur", "gekleurd" };
                //todo: hier komt later een query die de lijst vult
                ViewData["kleuren"] = kleuren;

                return View(jurken);
            }
        }

        public IActionResult FilterVerwerken(string[] filterMerk, string[] filterStijl)
        {
            using (var context = new HoneyMoonShopContext())
            {
                List<Jurk> jurken = new List<Jurk>();

                //we moeten dit ff goed testen. op dit moment gaat hij door elke filter door, maar hij controlleert alleen op merk in de query
                //maar als we stijlen in filterValues hebben, dan word daar dus niet op gecontrolleerd. Stel we doen dat wel dan komen jurken
                //er 2 keer in voor (eerst komtie als het op merk checkt. vervolgens opnieuw bij stijl
                 
               /* foreach (var filter in filterValues)
                {
                    foreach (var jurk in context.Jurken.Where(g => g.Merk.Contains(filter)).ToList())
                        jurken.Add(jurk);
                }*/

                //deze optie is overzichtelijker en IMO logischer (je kijkt naar de filterwaarde en controlleert of de value in die collectie voorkomt
                //je kan op meerdere dingen filteren in dezelfde query ook en je krijgt zo geen duplicates omdat je maar 1x door de productlist heen gaat
                //MAAR hier zit dus een bug in dat de merken met spatiebalk ertussen niet gepakt worden. Ik stel voor dat we gaan kijken of we dat kunnen
                //fixen en anders moeten we een nieuwe oplossing bedenken.
                jurken = context.Jurken.Where(g => filterMerk.Contains(g.Merk)&&filterStijl.Contains(g.Stijl)).ToList();
                ViewData["jurken"] = jurken;

                return PartialView("ProductsPartial", jurken);
            }
        }
    }
}
