using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospitalWebsitee.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

       public PatientController(IUnitOfWork unitOfWork)
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
            return Json(_unitOfWork.Patients.GetAll().ToList());


            //var list = _unitOfWork.Patients.GetAll().Include(p => p.PatientName).ToList();
            //return Json(list);
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
