using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class HospitalController : ControllerBase2
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public HospitalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var list =_unitOfWork.Hospitals.GetAll().ToList();
            return Json(list);
        }
    }
}
