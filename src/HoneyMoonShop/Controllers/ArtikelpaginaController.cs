using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class ArtikelpaginaController : Controller
    {
      
        public IActionResult Artikelpagina() {
            List<string> plaatjesjurk = new List<string>(); 
            plaatjesjurk.Add("/Images/");
            plaatjesjurk.Add("/Images/Dres2.png");
            plaatjesjurk.Add("/Images/Dres3.png");

            return View();
        }
    }
}
