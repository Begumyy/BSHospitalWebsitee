using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospitalWebsitee.Controllers
{
    public class AppointmentController : Controller
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

        public IActionResult GetAll()
        {
            //var list=unitOfWork.Appointments.GetAll(a=>a.IsCanceled==false).Include(a=>a.Department).Include(a=>a.Hospital).ToList();
            

            var list = _unitOfWork.Appointments.GetAll().Select(a=>a.Patients).ToList();
            return Json(list);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Appointments.DeleteById(id);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Appointments.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }
    }
}
