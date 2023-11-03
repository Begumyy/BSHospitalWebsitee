using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class AppointmentController : ControllerBase
    {
        public AppointmentController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            List<Appointment> appointments = new List<Appointment>(); //veritabanından randevular alınacak
            return View(appointments);//randevular da view'a gönderilecek   ???? admin'de yapılacak!!!
        }

        [HttpPost]

        public IActionResult Add(Appointment appointment)
        {
            unitOfWork.Appointments.Add(appointment);
            unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Appointments.GetAll().ToList()});
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            unitOfWork.Appointments.DeleteById(id);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            unitOfWork.Appointments.Update(appointment);
            unitOfWork.Save();
            return Ok();

        }
    }
}
