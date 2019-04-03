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
        /// <summary>
        /// Gets the index and returns the view.
        /// </summary>
        /// <returns>The index page</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Redirects from the form on the index to the results action.
        /// </summary>
        /// <param name="priceMax">The maximum price in the form</param>
        /// <param name="pointMin">The minimum points in the form</param>
        /// <returns>A redirect to the results action</returns>
        [HttpPost]
        public IActionResult Index(int priceMax, int pointMin)
        {
            return RedirectToAction("Results", new { priceMax, pointMin } );
        }

        /// <summary>
        /// Gets the results view based on the price and points provided and returns it.
        /// </summary>
        /// <param name="priceMax">Maximum price</param>
        /// <param name="pointMin">Minimum points</param>
        /// <returns>The results view</returns>
        [HttpGet]
        public IActionResult Results(int priceMax, int pointMin)
        {
            List<Wine> wines = Wine.GetWineList(priceMax, pointMin);
            return View(wines);
        }




    }

}
