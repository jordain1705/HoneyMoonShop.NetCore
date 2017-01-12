using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ViewResult Edit(int jurkId) =>
            View(repository.Jurken
                .FirstOrDefault(p => p.JurkId == jurkId));

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

        public ViewResult Create() => View("Edit", new Jurk());

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
