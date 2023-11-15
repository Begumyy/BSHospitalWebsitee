using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=_unitOfWork.Patients.GetAll().ToList() });
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Patients.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            _unitOfWork.Patients.Update(patient);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
