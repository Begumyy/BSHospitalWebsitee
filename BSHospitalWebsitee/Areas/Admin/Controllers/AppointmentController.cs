using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class AppointmentController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Appointments.GetAll().ToList());
        }
    }
}
