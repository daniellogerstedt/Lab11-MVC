using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;

namespace MVCLab.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int priceMax, int pointMin)
        {
            return RedirectToAction("Results", new { priceMax, pointMin } );
        }

        [HttpGet]
        public IActionResult Results(int priceMax, int pointMin)
        {
            List<Wine> wines = Wine.GetWineList(priceMax, pointMin);
            return View(wines);
        }




    }

}
