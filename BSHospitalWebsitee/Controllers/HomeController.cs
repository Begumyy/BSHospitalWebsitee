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

    }
}