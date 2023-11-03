using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class AppointmentController : ControllerBase
    {
        public AppointmentController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
