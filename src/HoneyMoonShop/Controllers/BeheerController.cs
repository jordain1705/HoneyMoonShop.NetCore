using System.Collections.Generic;
using System.Linq;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class BeheerController : Controller
    {
        private IHoneymoonshopRepository repository;

        public BeheerController(IHoneymoonshopRepository repo)
        {
            repository = repo;
        }

        public ViewResult Crud() => View(repository.Jurken);

        public ViewResult EditCustom(int jurkId)
        {
            Jurk jurk = repository.Jurken
                .FirstOrDefault(p => p.JurkId == jurkId);

            List<string> alleMerken = repository.Jurken.Select(g => g.Merk).Distinct().ToList();
            ViewData["merken"] = alleMerken;
            List<string> alleStijlen = repository.Jurken.Select(g => g.Stijl).Distinct().ToList();
            ViewData["stijlen"] = alleStijlen;
            List<string> neklijnen = repository.Jurken.Select(g => g.Neklijn).Distinct().ToList();
            ViewData["neklijnen"] = neklijnen;
            List<string> silhouettes = repository.Jurken.Select(g => g.Silhouette).Distinct().ToList();
            ViewData["silhouettes"] = silhouettes;

            return View(jurk);
        }
           

        [HttpPost]
        public IActionResult Edit(Jurk jurk)
        {

            if (ModelState.IsValid)
            {
                repository.SaveJurk(jurk);
                //TempData["message"] = $"{jurk.Artikelnummer} has been saved";
                return RedirectToAction("Crud");
            }
            else
            {
                // there is something wrong with the data values
                return View(jurk);
            }
        }

        public ViewResult CreateCustom() => View("EditCustom", new Jurk());
        public ViewResult Create()
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
                ViewData["silhouettes"] = silhouettes;

                return View("Edit", new Jurk());
            }
        }

        [HttpPost]
        public IActionResult Delete(int jurkId)
        {
            Jurk deletedJurk = repository.DeleteJurk(jurkId);
            if (deletedJurk != null)
            {
                //TempData["message"] = $"{deletedJurk.Artikelnummer} was deleted";
            }
            return RedirectToAction("Crud");
        }
    }
}
