using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BSHospitalWebsitee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Department()
        {
            return View();
        }

        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        //public IActionResult GetRandevu()
        //{
        //    // Partial view'i yükle
        //    return View("randevuForm");
        //}

        
    }
}