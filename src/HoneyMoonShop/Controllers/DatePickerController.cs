using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class DatePickerController : Controller
    {
        // GET: /<controller>/
        public IActionResult DatePicker()
        {
            return View() ;
        }
        public IActionResult DatePickerDatum()
        {
            using (var context = new HoneyMoonShopContext())
            {
                DateTime localDate = DateTime.Now;

                List<DateTime> datumsDisabled = new List<DateTime>(); //alle datums die niet bezet zijn en geen feestdagen zijn
                List<DateTime> feestdagen = new List<DateTime>(); //de feestdagen of andere datums die niet beschikbaar zijn.(hardcoded)
                var datumsBezet = context.Afspraak.Where(a => a.DatumTijd > localDate).Select(a => a.DatumTijd).ToList();
                //todo: als er 3 afspraken zijn dan komt die datum in datumsDisabled
                datumsBezet = datumsBezet.Distinct().ToList();
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
                return View();
            }
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
