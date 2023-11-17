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

        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Save();
            return Ok();

            //appointment.Department = _unitOfWork.Departments.GetById(appointment.DepartmentId);

            //appointment.Department = _unitOfWork.Departments.GetById(appointment.DepartmentId);
            //_unitOfWork.Appointments.Add(appointment);
            //_unitOfWork.Save();
            //return Ok();
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult GetAll()
        {
            //var list=unitOfWork.Appointments.GetAll(a=>a.IsCanceled==false).Include(a=>a.Department).Include(a=>a.Hospital).ToList();
            

            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u=>u.Hospital).Include(u=>u.Department).Include(u=>u.Doctor).ToList();
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
