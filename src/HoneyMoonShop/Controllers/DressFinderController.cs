using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class DressFinderController : Controller
    {
        public IActionResult Dressfinder()
        {
            List<string> merken = new List<string>();  //hier komt later een query die de lijst vult
            merken.Add("dolce");
            merken.Add("gucci");
            merken.Add("zeeman");
            merken.Add("gucci");
            merken.Add("zeeman");
            merken.Add("gucci");
            merken.Add("zeeman");
            ViewData["merken"] = merken;

            List<string> stijlen = new List<string>();  //hier komt later een query die de lijst vult
            stijlen.Add("cool");
            stijlen.Add("stoer");
            stijlen.Add("mooi");
            stijlen.Add("moeeoi");
            stijlen.Add("e");

            ViewData["stijlen"] = stijlen;

            List<double> prijzen = new List<double>();  //hier komt later een query die de lijst vult
            prijzen.Add(1.99);
            prijzen.Add(20.00);
            prijzen.Add(1290.32);
            ViewData["minprijs"] = (int)prijzen.Min();
            ViewData["maxprijs"] = (int)prijzen.Max();

            List<string> neklijnen = new List<String>(); //hier komt later een query die de lijst vult
            neklijnen.Add("V-hals");
            neklijnen.Add("kraag");
            neklijnen.Add("zwarte pieten band");
            ViewData["neklijnen"] = neklijnen;

            List<string> silhouette = new List<String>(); //hier komt later een query die de lijst vult
            silhouette.Add("peer");
            silhouette.Add("zandloper");
            silhouette.Add("appel");
            ViewData["silhouette"] = silhouette;

            List<string> kleuren = new List<String>(); //hier komt later een query die de lijst vult
            kleuren.Add("ivoor/wit");
            kleuren.Add("ivoor met kleur");
            kleuren.Add("gekleurd");
            ViewData["kleuren"] = kleuren;

            List<string> dresses = new List<String>();
            dresses.Add("/Images/Dress.png");
            dresses.Add("/Images/Dres2.png");
            dresses.Add("/Images/Dres3.png");
            dresses.Add("/Images/Dress.png");
            dresses.Add("/Images/Dres2.png");
            dresses.Add("/Images/Dres3.png");
            dresses.Add("/Images/Dress.png");
            dresses.Add("/Images/Dres2.png");
            dresses.Add("/Images/Dres3.png");
            ViewData["dresses"] = dresses;

            return View(merken);
        }

        public IActionResult Artikelpagina()
        {
            return View();
        }
    }
}
