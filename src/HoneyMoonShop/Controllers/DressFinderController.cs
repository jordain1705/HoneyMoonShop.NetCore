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
                var test = context.Jurken;
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

                List<string> kleuren = new List<String>(); //hier komt later een query die de lijst vult
                kleuren.Add("ivoor/wit");
                kleuren.Add("ivoor met kleur");
                kleuren.Add("gekleurd");
                ViewData["kleuren"] = kleuren;

                return View(jurken);
            }
        }
    }
}

