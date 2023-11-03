using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class DoctorController : ControllerBase
    {
        public DoctorController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
              
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
