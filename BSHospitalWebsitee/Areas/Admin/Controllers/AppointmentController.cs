using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class AppointmentController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Save();
            return Json(new { success = true });
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Appointments.GetAll().Include(b=>b.IsAccepted==false && b.IsCanceled==false && b.IsDeclined==false).ToList());
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Appointments.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            _unitOfWork.Appointments.Update(appointment);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
