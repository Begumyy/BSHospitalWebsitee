using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
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
        public IActionResult Add([FromBody] Patient patient)
        {
            //patient.DepartmentId = 1;
            //_unitOfWork.Patients.Add(patient);
            //_unitOfWork.Save();
            ////return Ok(patient.Id);
            ////return Ok(patient.Depatment.Id);
            ////return Ok(patient.departmentId);
            ////return Json(new { success = true });
            //return Ok(patient);


            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                // Hata mesajlarını loglayabilir veya hata durumu döndürebilirsiniz
                return BadRequest(errors);
            }

            // "Department" nesnesini alın
            Department department = _unitOfWork.Departments.GetById(patient.DepartmentId);

            // Eğer "Department" nesnesi null değilse, ilişkilendirme yapın
            if (department != null)
            {
                patient.Department = department;
                _unitOfWork.Patients.Add(patient);
                _unitOfWork.Save();
                return Ok(patient);
            }
            else
            {
                // Hata durumu, uygun "DepartmentId" bulunamadı
                return BadRequest("Geçerli bir departman seçilmelidir.");
            }
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
