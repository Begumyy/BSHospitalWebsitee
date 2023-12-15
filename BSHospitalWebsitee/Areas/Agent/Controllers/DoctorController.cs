using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class DoctorController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Doctors.GetAll().ToList());
        }
    }
}
