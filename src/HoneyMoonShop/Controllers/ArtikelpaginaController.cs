﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class ArtikelpaginaController : Controller
    {
        public int artikelnummer { get; private set; }

  
        public IActionResult Artikelpagina(int artikelnummer) {

            
            using (var context = new HoneyMoonShopContext()) {
               //var  anummer = context.Jurken.Select(s => s.Artikelnummer);
                //string arti = anummer.ToString();
                //int artikelnummer= int.Parse(arti);
                
                List<String> plaatjesjurk = context.Afbeeldingen.Where(s => s.Artikelnummer==(artikelnummer)).Select(s =>  s.SourcePath ).ToList();
                ViewData["plaatjes"] = plaatjesjurk;

               String merken = context.Jurken.Where(s => s.Artikelnummer == artikelnummer).Select(s => s.Merk).ToString();
                ViewData["merkje"] = merken;

                List<String> stijlk = context.Jurken.Where(s => s.Artikelnummer == artikelnummer).Select(s => s.Stijl).ToList();
                ViewData["merkje"] = merken;
                //List<string> hooiwagenplaatjesjurk = new List<string>();
                // foreach(var a in context.Afbeeldingen) { 
                //   var plaatjejurk = context.Afbeeldingen.Where(s => s.Artikelnummer == artikelnummer).Select(s => new { Afbeelding = s.SourcePath }); 


                var selectArtikel =
                    context.Jurken.Select(s => new {
                    Naam = s.Merk,
                    nummer = s.Artikelnummer,
                    omshrijving = s.Omschrijving,
                    Merk = s.Merk,
                    Stijl = s.Stijl,
                    Prijsindicatie= s.MaxPrijs
                });

            }
            return View();
        }
    }
}
