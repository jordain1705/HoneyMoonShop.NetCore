using System;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Models;
using System.Linq;
using System.Collections.Generic;
using HoneymoonShop.Data;

namespace HoneymoonShop.Controllers
{
    public class ArtikelpaginaController : Controller
    {
        public IActionResult Artikelpagina(Jurk curJurk)
        {           
            using (var context = new HoneyMoonShopContext())
            {
                int artikelNummer = curJurk.Artikelnummer;
                ViewData["nummer"] = artikelNummer;

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

                ViewData["merkje"] = merken;

                string img1 = "/Images/" + artikelNummer + "a.png";
                string img2 = "/Images/" + artikelNummer + "b.png";
                string img3 = "/Images/" + artikelNummer + "c.png";

                ViewData["pl1"] = img1;
                ViewData["pl2"] = img2;
                ViewData["pl3"] = img3;
                //hieronder laad het de bijbehorende accesoires(random)
                var alleAccessoires = context.Accessoire.ToList();
                var juisteAccessoires = new List<Accessoire>();
                List<string> AccesoiresPlaatjes = new List<string>();
                List<string> Accessoirelinks = new List<string>();
                List<string> AccessoireMerk = new List<string>();
                Random rnd = new Random();
                int hoogste = alleAccessoires.Count();
                for (int i = 0; i < hoogste; i++)
                {
                   hoogste = alleAccessoires.Count();
                   int actualRandom = rnd.Next(0, hoogste-1);
                   juisteAccessoires.Add(alleAccessoires.ElementAt(actualRandom));
                   alleAccessoires.RemoveAt(actualRandom);
                   Accessoirelinks.Add(juisteAccessoires[i].LinkNaarWebshop);
                   AccessoireMerk.Add(juisteAccessoires[i].Merk);
                   String plaatje = Convert.ToString(juisteAccessoires.ElementAt(i).AccessoireCode);
                   String afr = "/Images/Accessoire/" + plaatje + ".jpg";
                   AccesoiresPlaatjes.Add(afr);
                }
                ViewData["AccessoireLink"] = Accessoirelinks;
                ViewData["AccessoiresNum"] = AccesoiresPlaatjes;
                ViewData["AccessoireMerk"] = AccessoireMerk;
                ViewData["Accessoires"] = juisteAccessoires;
                //hier laad het random jurken 
                var alleJurken = context.Jurken.ToList();
                var juisteJurken = new List<Jurk>();
                List<string> jurkNaam = new List<string>();
                List<int> jurkNummer = new List<int>();
                List<string> plaatjes = new List<string>();      
                hoogste = alleJurken.Count();
                for (int i = 0; i < hoogste; i++)
                {
                    hoogste = alleJurken.Count();
                    int actualRandom = rnd.Next(0, hoogste - 1);
                    juisteJurken.Add(alleJurken.ElementAt(actualRandom));
                    alleJurken.RemoveAt(actualRandom);
                    jurkNaam.Add(juisteJurken[i].Merk);
                    jurkNummer.Add(juisteJurken[i].Artikelnummer);
                    string afr = "/Images/" + jurkNummer[i].ToString()+ "a.png";
                    plaatjes.Add(afr);               
                }
                ViewData["jurkNamen"] = jurkNaam;
                ViewData["jurkPlaatjes"] = plaatjes;
                ViewData["jurkNummer"] = jurkNummer;
            }
            return View();
        }
    }
}
