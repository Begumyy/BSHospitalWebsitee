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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }
    }
}