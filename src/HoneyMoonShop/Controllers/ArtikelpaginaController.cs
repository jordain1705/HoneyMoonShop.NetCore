using System;
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
      
        public IActionResult Artikelpagina(int artikelnummer) {
          
            using (var context = new HoneyMoonShopContext()) {
                List<string> plaatjesjurk = new List<string>();
                var plaatjejurk = context.Afbeeldingen.Select(s => new { Afbeelding = s.AfbeeldingId }); 
                var selectArtikel = context.Jurken.Select(s => new {
                    Naam = s.Merk,
                    nummer = s.Artikelnummer,
                    omshrijving = s.Omschrijving,
                    Merk = s.Merk,
                    Stijl = s.Stijl,
                    prijs = s.MinPrijs
                });

            }
            return View();
        }
    }
}
