using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using HoneymoonShop.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class DatePickerController : Controller
    {
        // GET: /<controller>/
        /* public IActionResult DatePicker()
         {
             return View() ;
         }*/
        

        public IActionResult DatePickerDatum()
        {
            using (var context = new HoneyMoonShopContext())
            {
                DateTime localDate = DateTime.Now;

                //voegd de jurkafspraak toe aan de model als de pagina is geladen vanuit de artiekelpagina vna een jurk
                List<DateTime> datumsDisabled = new List<DateTime>(); //alle datums die niet bezet zijn en geen feestdagen zijn
                List<DateTime> feestdagen = new List<DateTime>(); //de feestdagen of andere datums die niet beschikbaar zijn.(hardcoded)
                var datumsBezet = context.Afspraak.Where(a => a.DatumTijd > localDate).Select(a => a.DatumTijd).ToList();
                datumsBezet = datumsBezet.Distinct().ToList();
                Afspraak afspraak = new Afspraak();

                for (int i = 0; i < datumsBezet.Count(); i++)
                {
                    //als de datum (jaar maand en dag hetzelfde) meer dan 2 keer voorkomt, dan word deze toegevoegd aan de disabled dates
                    //misschien kan dit zonder de database simpeler?
                    if (context.Afspraak.Where(a => a.DatumTijd.Day == datumsBezet[i].Day && a.DatumTijd.Month == datumsBezet[i].Month && a.DatumTijd.Year == datumsBezet[i].Year).ToList().Count() > 2)
                    {
                        datumsDisabled.Add(datumsBezet[i]);
                    }
                }
                datumsDisabled = datumsDisabled.Union(feestdagen).ToList(); //alle datums die disabled moeten zijn
                //viewdata's die door de view opgevraagd kunnen worden.
                ViewData["datumsDisabled"] = datumsDisabled;
                return View(afspraak);
            }
        }

        public IActionResult DatePickerTijd()
        {
            using (var context = new HoneyMoonShopContext())
            {
                Models.Afspraak afspraak = new Models.Afspraak();
                //get available times on the date and return them to the view
                var mogelijkeTijden = new List<DateTime>();
                var date1 = new DateTime(afspraak.DatumTijd.Year, afspraak.DatumTijd.Month, afspraak.DatumTijd.Day, 9, 30, 0);
                var date2 = new DateTime(afspraak.DatumTijd.Year, afspraak.DatumTijd.Month, afspraak.DatumTijd.Day, 12, 30, 0);
                var date3 = new DateTime(afspraak.DatumTijd.Year, afspraak.DatumTijd.Month, afspraak.DatumTijd.Day, 15, 0, 0);
                mogelijkeTijden.Add(date1);
                mogelijkeTijden.Add(date2);
                mogelijkeTijden.Add(date3);
                var bezetteTijden = context.Afspraak.Where(a => a.DatumTijd == date1 || a.DatumTijd == date2 || a.DatumTijd == date3).Select(a => a.DatumTijd).ToList();
                mogelijkeTijden = mogelijkeTijden.Except(bezetteTijden).ToList();
                ViewData["mogelijkeTijden"] = mogelijkeTijden;

                return View(afspraak);
            }
        }

        public IActionResult DatePickerGegevens(DateTime tijd)
        {
            Models.Afspraak afs = new Afspraak {DatumTijd = tijd};
            return View(afs);
        }

        public IActionResult DatePickerBevestigen(String naam, DateTime datum, int tel, String email)
        {
            Models.Afspraak afs = new Afspraak
            {
                Achternaam = naam,
                DatumTijd = datum,
                TelefoonNummer = tel,
                EmailAdres = email
            };

            return View(afs);

        }
        public ActionResult DatePickerVoltooid(Models.Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                HoneyMoonShopContext context = new HoneyMoonShopContext();
                context.Afspraak.Add(afspraak);
                context.SaveChanges();
            }
            // puts the afspraak into the database

            // go to the voltooid view
            return View();
        }
    }
}
