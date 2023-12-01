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

            // Ardından randevuyu ekleyin
            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Save();
            return Ok(appointment.Id);



            //_unitOfWork.Appointments.Add(appointment);
            //_unitOfWork.Save();
            //return Ok();

            ////appointment.Department = _unitOfWork.Departments.GetById(appointment.DepartmentId);

            ////appointment.Department = _unitOfWork.Departments.GetById(appointment.DepartmentId);
            ////_unitOfWork.Appointments.Add(appointment);
            ////_unitOfWork.Save();
            ////return Ok();
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u=>u.Hospital).Include(u=>u.Department).Include(u=>u.Doctor).ToList();
            return Json(list);
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    _unitOfWork.Appointments.DeleteById(id);
        //    _unitOfWork.Save();
        //    return Ok();
        //}

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Appointments.DeleteById(id);
            _unitOfWork.Save();
            return Ok(id);

           
        }

        //[HttpPost]
        //public IActionResult Update(Appointment appointment)
        //{
        //    //_unitOfWork.Appointments.GetById();
        //    _unitOfWork.Appointments.Update(appointment);
        //    _unitOfWork.Save();
        //    return Ok(appointment.Id);


        //}


        [HttpPost]
        public IActionResult Update(Appointment updatedAppointment)
        {
            // Mevcut randevuyu al
            Appointment existingAppointment = _unitOfWork.Appointments.GetById(updatedAppointment.Id);

            if (existingAppointment == null)
            {
                // Güncellenmesi gereken randevu bulunamazsa işle
                return NotFound("Randevu bulunamadı");
            }

            // Mevcut randevunun özelliklerini yeni değerlerle güncelle  
            existingAppointment.HospitalId = updatedAppointment.HospitalId; // Property1 ve diğer özellikleri gerçek özellik adlarıyla değiştir
            existingAppointment.DepartmentId = updatedAppointment.DepartmentId;
            existingAppointment.DoctorId = updatedAppointment.DoctorId;
            existingAppointment.PatientId = updatedAppointment.PatientId;
            existingAppointment.AppointmentDate = updatedAppointment.AppointmentDate;

            // Diğer özellikleri buna göre güncelle

            // Gerekiyorsa ilişkileri güncelle (örneğin, randevuyla ilişkili diğer varlıklar varsa)

            // Değişiklikleri veritabanına kaydet
            _unitOfWork.Save();

            return Ok(existingAppointment.Id);
        }
    }
}
