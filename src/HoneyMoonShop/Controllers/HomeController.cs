﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dressfinder()
        {
            List<string> merken = new List<string>();
            merken.Add("dolce");
            merken.Add("gucci");
            merken.Add("zeeman");
            ViewData["merken"] = merken;
            
            List<string> stijlen = new List<string>();
            merken.Add("cool");
            merken.Add("stoer");
            merken.Add("mooi");
            ViewData["stijlen"] = stijlen;
                        
            return View(merken);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}