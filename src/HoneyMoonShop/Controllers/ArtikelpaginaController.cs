using System;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Models;
using System.Linq;
using System.Collections.Generic;
using HoneymoonShop.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class ArtikelpaginaController : Controller
    {
        public IActionResult Artikelpagina(Jurk curJurk)
        {

            ViewData["curJurk"] = curJurk;

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

            //todo: viewmodel ipv viewdata
            //todo: waarom is dit een ding(stijlk en plaatjes jurk)
            //List<String> stijlk = context.Jurken.Where(s => s.Artikelnummer == curJurk.Artikelnummer).Select(s => s.Stijl).ToList();
            ViewData["merkje"] = merken;

            //List<string> plaatjesjurk = new List<string>();


            string img1 = "/Images/" + a + "a.png";
            string img2 = "/Images/" + a + "b.png";
            string img3 = "/Images/" + a + "c.png";

            ViewData["pl1"] = img1;

            ViewData["pl2"] = img2;

            ViewData["pl3"] = img3;

            using (var context = new HoneyMoonShopContext())
            {
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

            }

            using (var context = new HoneyMoonShopContext())
            {
                List<int> alleJurken = context.Jurken.Select(q => q.JurkId).ToList();

                List<Jurk> randJurken = new List<Jurk>();
                List<string> jurkNaam = new List<string>();
                List<string> jurkNummer = new List<string>();
                int hoogste = alleJurken.Count();
                var rnd = new Random();

                for (int i = 0; i <= 4; i++)
                {
                    int actualrandom = rnd.Next(1, hoogste);
                    foreach (var jurk in context.Jurken.Where(w => w.JurkId.Equals(actualrandom)))
                    {
                        randJurken.Add(jurk);
                    }
                }

                for (int im = 0; im <= 4; im++)
                {

                    String plaatje = Convert.ToString(randJurken.ElementAt(im).Artikelnummer);
                    String afr = "/Images/" + plaatje + "a.png"; //plaatje = rnadom jurk Id 
                    jurkNummer.Add(afr);
                    jurkNaam.Add(randJurken.ElementAt(im).Merk);

                    ViewData[("RandJurk" + im)] = jurkNummer.ElementAt(im);
                    ViewData[("JurkNaam" + im)] = jurkNaam.ElementAt(im);
                }

                ViewData[("AlleJurken")] = alleJurken;


            }

            return View();

        }
    }
}
