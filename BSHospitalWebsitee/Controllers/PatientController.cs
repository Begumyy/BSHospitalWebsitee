using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Appointment = BSHospital.Models.Appointment;

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
            //Appointment appointment = new Appointment();
            //var hasta = _unitOfWork.Patients.GetFirstOrDefault(p => p.Id == appointment.PatientId);




            //// Hasta bulunduğunda randevu nesnesine hasta bilgisini ekle
            //patient = hasta;

            // Ardından randevuyu ekleyin

            

                _unitOfWork.Patients.Add(patient);
                _unitOfWork.Save();
                return Ok(patient.Id);
            
           

            //_unitOfWork.Patients.Add(patient);
            //_unitOfWork.Save();
            // return View();
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Patients.GetAll().ToList());


            
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
