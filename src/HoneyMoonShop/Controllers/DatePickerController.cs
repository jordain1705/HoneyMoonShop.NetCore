using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class DatePickerController : Controller
    {
        // GET: /<controller>/
        public IActionResult DatePicker()
        {
            return View();
        }
        public IActionResult DatePickerVoltooid()
        {
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
