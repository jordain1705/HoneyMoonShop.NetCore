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
    public class AfspraakBeheerController : Controller
    {
        private IHoneymoonshopRepository repository;

        public AfspraakBeheerController(IHoneymoonshopRepository repo)
        {
            repository = repo;
        }

        public ViewResult Crud() => View(repository.Afspraken);

        public ViewResult Edit(int afspraakId)
        {
           Afspraak afspraak = repository.Afspraken
                .FirstOrDefault(p => p.AfspraakId == afspraakId);

            return View(afspraak);
        }


        [HttpPost]
        public IActionResult Edit(Afspraak afspraak)
        {

            if (ModelState.IsValid)
            {
                repository.SaveAfspraak(afspraak);
                //TempData["message"] = $"{jurk.Artikelnummer} has been saved";
                return RedirectToAction("Crud");
            }
            else
            {
                // there is something wrong with the data values
                return View(afspraak);
            }
        }

        public ViewResult Create() => View("Edit", new Afspraak());
        

        [HttpPost]
        public IActionResult Delete(int afspraakId)
        {
            Afspraak deletedAfspraak = repository.DeleteAfspraak(afspraakId);
            if (deletedAfspraak != null)
            {
                //TempData["message"] = $"{deletedJurk.Artikelnummer} was deleted";
            }
            return RedirectToAction("Crud");
        }
    }
}