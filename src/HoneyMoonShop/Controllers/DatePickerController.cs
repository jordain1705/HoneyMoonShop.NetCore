using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Models;
using HoneymoonShop.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class DatePickerController : Controller
    {
        // GET: /<controller>/
        public IActionResult DatePicker()
        {
            //get all dates after the current date
            using (var context = new HoneyMoonShopContext())
            {
                DateTime localDate = DateTime.Now;
              
                List<DateTime> datumsDisabled = new List<DateTime>(); //alle datums die niet bezet zijn en geen feestdagen zijn
                List<DateTime> feestdagen = new List<DateTime>(); //de feestdagen of andere datums die niet beschikbaar zijn.(hardcoded)
                var datumsBezet = context.Afspraak.Where(a => a.DatumTijd > localDate).Select(a => a.DatumTijd).ToList();     
                //todo: als er 3 afspraken zijn dan komt die datum in datumsDisabled
                datumsDisabled = datumsDisabled.Union(feestdagen).ToList(); //alle datums die disabled moeten zijn
                //viewdata's die door de view opgevraagd kunnen worden.
                ViewData["curDate"] = localDate;
                ViewData["datumsDisabled"] = datumsDisabled;
            }
           return View();
        }
        //deze method moet de view returnen naar de afspraak maken met de mogelijke tijden op die dag.
        public IActionResult DatePicker(DateTime selectedDate)
        {
            using (var context = new HoneyMoonShopContext())
            {
                List<DateTime> availableTimes = new List<DateTime>();//lijst met tijden die kunnen
                var date1 = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 9, 30, 0);
                var date2 = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 12, 30, 0);
                var date3 = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 15, 0, 0);
                availableTimes.Add(date1);
                availableTimes.Add(date2);
                availableTimes.Add(date3);
                //lijst met tijden die al bezet zijn op die datum
                var bezetteTijden = context.Afspraak.Where(A => A.DatumTijd == selectedDate).Select(a => a.DatumTijd).ToList();
                availableTimes = availableTimes.Except(bezetteTijden).ToList();
                ViewData["availableTimes"] = availableTimes;
            }         
                return View("DatePicker");
        }
        
        public IActionResult afspraakNaarDatabase(Afspraak curAfspraak)
        {
            if(/*check of de afspraak op die datum al in de database staat, en evt andere checks*/true)
            {
                //eventueel extra atributen in de modelen toevoegen 
                //check if model=valid
                //model naar database
                //return naar de view dat de afspraak erin staat
            }
            else
            {
                //ga terug naar de database en zeg dat de afspraak fout is gegaan
            }
            return View();
        }

        [HttpPost]
        public ActionResult DatePicker(String datepicker)
        {
            ViewData["Datum"] = datepicker;
            return View();
            //check for reportName parameter value now
            //to do : Return something
        }
    }
}
