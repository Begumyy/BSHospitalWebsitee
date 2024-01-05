using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class HospitalController : ControllerBase1
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

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            if (hospital.HospitalName != null&&hospital.Address!=null)
            {
                _unitOfWork.Hospitals.Add(hospital);
                _unitOfWork.Save();

            }
            return Json(new { success = true });
        }


        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Hospitals.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Hospitals.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            _unitOfWork.Hospitals.Update(hospital);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
