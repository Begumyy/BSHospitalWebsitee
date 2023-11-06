using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospitalWebsitee.Controllers
{
    public class AppointmentController : ControllerBase
    {
        public AppointmentController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
           
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult GetAll()
        {
            //var list=unitOfWork.Appointments.GetAll(a=>a.IsCanceled==false).Include(a=>a.Department).Include(a=>a.Hospital).ToList();
            var list = unitOfWork.Appointments.GetAll().ToList();
            return Json(list);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            unitOfWork.Appointments.DeleteById(id);
            unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            unitOfWork.Appointments.DeleteById(id);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }
    }
}
