using System;
using System.Collections.Generic;
using System.Linq;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class DressFinderController : Controller
    {
        private readonly HoneyMoonShopContext _context;

        public DressFinderController(HoneyMoonShopContext context)
        {
            _context = context;
        }


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

        public IActionResult FilterVerwerken(string[] filterMerk, string[] filterStijl, string neklijnDd, string silhouetteDd, string kleurenDd, string[] slider, string orderType)
        {
            using (var context = new HoneyMoonShopContext())
            {
                List<Jurk> jurken = new List<Jurk>();
                jurken = context.Jurken.ToList();
                var queryable = jurken.AsQueryable();

                if (filterMerk.Any())
                    //filter op merken. als geen merk is ingevoegd dan laat het alle merken zien
                    jurken = jurken.Intersect(context.Jurken.Where(g => filterMerk.Contains(g.Merk)).ToList()).ToList();
                if (filterStijl.Any())
                    //filter op stijlen. als geen stijl is ingevoegd dan laat het alle stijlen zien
                    jurken = jurken.Intersect(context.Jurken.Where(g => filterStijl.Contains(g.Stijl)).ToList()).ToList();
                if (neklijnDd != null && neklijnDd != "Neklijn")
                    //als er een neklijn is aangeklikt dan wordt daarop gefilterd
                    jurken = jurken.Intersect(context.Jurken.Where(g => g.Neklijn == neklijnDd)).ToList();
                if (silhouetteDd != null && silhouetteDd != "Silhouette")
                    //als er een silhouette is aangeklikt dan wordt daarop gefilterd
                    jurken = jurken.Intersect(context.Jurken.Where(g => g.Silhouette == silhouetteDd)).ToList();
                if (slider.Count() == 2)//deze controle is als de slider 2 waarde heeft(zodat hij het niet doet bij de eerste opstart)
                {
                    //zorgt dat alleen resultaaten binnen de aangegeven prijsgrens worden gebruikt
                    //bug: de slider update soms random niet (ligt denk ik aan de functieaanroep)
                    jurken = jurken.Intersect(context.Jurken.Where(g => (g.MinPrijs >= Convert.ToInt32(slider[0])) && (g.MaxPrijs <= Convert.ToInt32(slider[1]))).ToList()).ToList();
                }
                var orderedJurken = jurken.OrderByDescending(g => g.MinPrijs).ToList();
                List<Jurk> sortedJurken = new List<Jurk>();
                if (orderType == "ascending")
                {
                    sortedJurken = orderedJurken.OrderBy(g => g.MinPrijs).ToList();
                }
                else
                {
                    sortedJurken = orderedJurken.OrderByDescending(g => g.MinPrijs).ToList();
                }
                List<string> merken = new List<string>();
                List<int> artikelNummers = new List<int>();
                for (int i = 0; i < sortedJurken.Count(); i++)
                {
                    merken.Add(sortedJurken[i].Merk);
                    artikelNummers.Add(sortedJurken[i].Artikelnummer);
                }
                ViewData["artikelNummers"] = artikelNummers;
                ViewData["merken"] = merken;
                ViewData["jurken"] = sortedJurken;

                return PartialView("ProductsPartial", sortedJurken);
            }
        }
       /* public IActionResult dressListOrderChanger(List<Jurk> jurken, string orderType)
        {
            List<Jurk> sortedJurken = new List<Jurk>();

            if (orderType == "ascending")
            {
               sortedJurken = jurken.OrderBy(g => g.MinPrijs).ToList();
            }
            else
            {
               sortedJurken = jurken.OrderByDescending(g => g.MinPrijs).ToList();
            }

            return PartialView("ProductsPartial", sortedJurken);
        }*/
    }
}
