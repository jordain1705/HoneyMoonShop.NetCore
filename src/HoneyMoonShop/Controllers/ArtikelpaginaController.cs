using System;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class ArtikelpaginaController : Controller
    {
        public IActionResult Artikelpagina(Jurk curJurk) {
              
                ViewData["curJurk"]= curJurk;

                int a = curJurk.Artikelnummer;
                ViewData["nummer"] = a;

                int maxp = curJurk.MaxPrijs;
                ViewData["maxi"] = maxp;

                int minp = curJurk.MinPrijs; 
                ViewData["min"] = minp;

                string teks = curJurk.Omschrijving;
                ViewData["Omschrijving"] = teks;

                String merken = curJurk.Merk;
                ViewData["merkje"] = merken;

                String stylo = curJurk.Stijl;
                ViewData["stylo"] = stylo;

                String nl = curJurk.Neklijn;
                ViewData["nek"] = nl;

                String sil = curJurk.Silhouette;
                ViewData["silh"] = sil;

                //todo: waarom is dit een ding(stijlk en plaatjes jurk)
                //List<String> stijlk = context.Jurken.Where(s => s.Artikelnummer == curJurk.Artikelnummer).Select(s => s.Stijl).ToList();
                ViewData["merkje"] = merken;

                //List<string> plaatjesjurk = new List<string>();
               

                string img1 = "/Images/" + a + "a.png";
                string img2 = "/Images/" + a +"b.png";
                string img3 = "/Images/" + a+ "c.png";
                
                ViewData["pl1"] = img1;
                
                ViewData["pl2"] = img2;
               
                ViewData["pl3"] = img3;
                
               

                
            
            return View();
        }
        //getjurkbyartikelnummermethod
        // make a hhtpget and a route method 
        //GET
    }
}
