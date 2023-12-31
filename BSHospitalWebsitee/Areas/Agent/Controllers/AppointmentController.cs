using BSHospital.Data.Migrations;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patient = BSHospital.Models.Patient;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class AppointmentController : ControllerBase2
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
            //_unitOfWork.Appointments.Add(appointment);
            //_unitOfWork.Save();
            //return Ok(appointment);

             Patient patient = new Patient();
            if (patient.TCKN != null)
            {
                // Hasta TCKN'si null değilse, belirli bir randevuyu güncelle
                var existingAppointment = _unitOfWork.Appointments.GetFirstOrDefault(a => a.Patient.TCKN == patient.TCKN);

                if (existingAppointment != null)
                {
                    // İlgili randevu bulundu
                    // İşlemlerinizi gerçekleştirin, örneğin iscancalled'ı false yapın
                    existingAppointment.IsCanceled = false;

                    _unitOfWork.Appointments.Update(existingAppointment);
                    _unitOfWork.Save();

                    return Ok("Hasta için randevu başarıyla güncellendi.");
                }
                else
                {
                    return BadRequest("Belirtilen TCKN'ye sahip randevu bulunamadı.");
                }
            }
            else
            {
                // Hasta TCKN'si null ise, yeni bir randevu oluştur
                Appointment newAppointment = new Appointment();

                // Yeni randevu özelliklerini ayarlayın...

                _unitOfWork.Appointments.Add(newAppointment);
                _unitOfWork.Save();

                return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            }

        }
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).Where(a => a.IsAccepted == false).Where(a => a.IsDeclined == false).ToList();
            return Json(list);
        }

       

        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            _unitOfWork.Appointments.Update(appointment);
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

        public IActionResult PatientGetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).Where(a => a.IsAccepted == false).Where(a => a.IsDeclined == false).ToList();
            return Json(list);
        }

        [HttpPost]
        public ActionResult CreateRandevu(Appointment appointment)
        {
            // Agent ID'sini al
            int agentId;
            if (int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "AppUserId")?.Value, out agentId))
            {
                // Agent ID'sini kullanarak randevu oluştur
                // ... (Randevu oluşturma işlemleri)

                // Başarılı bir şekilde oluşturulduktan sonra, randevuları listeleyen bir sorgu yap
                var randevular = _unitOfWork.Appointments.GetFirstOrDefault(x => x.AppUserId == agentId);

                // JSON formatında randevu listesini döndür
                return Json(randevular);
            }

            return Json(new { ErrorMessage = "AppUserId geçerli bir sayı değil." });
        }

        [HttpGet]
        public ActionResult ListRandevular()
        {
            // Agent ID'sini al
            int agentId;
            if (int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "AppUserId")?.Value, out agentId))
            {
                // Agent ID'sini kullanarak randevuları listeleyen bir sorgu yap
                var randevular = _unitOfWork.Appointments.GetFirstOrDefault(x => x.AppUserId == agentId);

                // JSON formatında randevu listesini döndür
                return Json(randevular);
            }

            return Json(new { ErrorMessage = "AgentId geçerli bir sayı değil." });
        }
    }
}
