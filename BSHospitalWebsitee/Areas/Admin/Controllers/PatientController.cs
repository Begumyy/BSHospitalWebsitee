using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using CineScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Appointment = BSHospital.Models.Appointment;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class PatientController : ControllerBase1
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
        public IActionResult Add( Patient patient)
        {
            //2.DENEME
            // Eğer TCKN'si ile eşleşen bir hasta varsa ve en az bir durumu false ise
            //if (_unitOfWork.Patients.Any(p => p.TCKN == patient.TCKN &&
            //                                   (!p.IsCancelled || !p.IsAccepted || !p.IsDeclined)))
            //{
            //    return BadRequest("Bu TCKN'ye sahip hastanın iptal edilmiş, kabul edilmiş veya reddedilmiş bir randevusu var.");
            //}
            //else
            //{
            //    // Eğer TCKN'si ile eşleşen bir hasta yoksa, yeni bir hasta ekleyin
            //    _unitOfWork.Patients.Add(patient);
            //    _unitOfWork.Save();

            //    return Ok("Hasta başarıyla eklendi.");
            //}


            //1.DENEME
            if (_unitOfWork.Patients.Any(p => p == patient.TCKN))
            {
                return BadRequest("Bu TCKN'ye sahip hastanın iptal edilmiş bir randevusu yok.");
            }
            else
            {
                _unitOfWork.Patients.Add(patient);
                _unitOfWork.Save();

                return Ok("Hasta başarıyla eklendi.");
            }

            // ADD METHODU 
            //_unitOfWork.Patients.Add(patient);
            //_unitOfWork.Save();
            //return Ok(patient);
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Patients.GetAll().Include(p=>p.Department).Include(p => p.Doctors).Include(p => p.Hospitals).ToList());
        }

        //public IActionResult GetAllDepartment()
        //{
        //    return Json(_unitOfWork.Departments.GetAll().ToList());
        //}

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
