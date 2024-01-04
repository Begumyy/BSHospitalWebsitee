using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class DoctorController : ControllerBase1
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

        [HttpPost]
        public IActionResult Add(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {

                // Eğer modelin doğruluğu sağlanmıyorsa, hataları inceleyebilir veya uygun bir şekilde işleyebilirsiniz
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Hataları inceleyip uygun bir şekilde cevap verebilirsiniz

                return BadRequest(new { message = "E-posta adresi doğru formatta değil", errors = ModelState });
            }
            _unitOfWork.Doctors.Add(doctor);
            _unitOfWork.Save();
            return Json(new { success = true });
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Doctors.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Doctors.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            _unitOfWork.Doctors.Update(doctor);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
