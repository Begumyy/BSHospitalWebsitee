using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class PatientController : ControllerBase
    {
        public PatientController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            unitOfWork.Patients.Add(patient);
            unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Patients.GetAll().ToList() });
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            unitOfWork.Patients.DeleteById(id);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            unitOfWork.Patients.Update(patient);
            unitOfWork.Save();
            return Ok();
        }
    }
}
