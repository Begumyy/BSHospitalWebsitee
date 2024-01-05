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
            if (appointment.AppointmentDate != null)
            {
                _unitOfWork.Appointments.Add(appointment);
                _unitOfWork.Save();

            }
            return Json(new { success = true });
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
                appointment.AppUserId = agentId;
                // ... (Randevu oluşturma işlemleri)

                // Başarılı bir şekilde oluşturulduktan sonra, randevuları listeleyen bir sorgu yap
                var randevular = _unitOfWork.Appointments.GetAll(x => x.AppUserId == agentId);  //GetFirstOrDefault fonksiyonu, birinci öncelikle "first" öğesini getirir. Eğer her ajanın birden fazla randevusu varsa, sadece ilkini getirecektir. Eğer bir ajanın birden fazla randevusu olabilirse, GetFirstOrDefault yerine GetAll gibi bir fonksiyon kullanarak filtreleme yapmanız gerekebilir.

                // JSON formatında randevu listesini döndür
                return Json(randevular);
            }

            return Json(new { ErrorMessage = "AppUserId geçerli bir sayı değil." });
        }

        [HttpGet]
        public IActionResult ListRandevular()
        {
            //_unitOfWork.Appointments.GetAll().Where(x => x.AppUserId == User.Claims.FirstOrDefault(c => c.Type == "AppUserId").Value, out agentId));


            // Agent ID'sini al
            int agentId;
            if (int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "AppUserId")?.Value, out agentId))
            {
                // Agent ID'sini kullanarak randevuları listeleyen bir sorgu yap
                var randevular = _unitOfWork.Appointments.GetAll(x => x.AppUserId == agentId).ToList();  //GetFirstOrDefault fonksiyonu, birinci öncelikle "first" öğesini getirir. Eğer her ajanın birden fazla randevusu varsa, sadece ilkini getirecektir. Eğer bir ajanın birden fazla randevusu olabilirse, GetFirstOrDefault yerine GetAll gibi bir fonksiyon kullanarak filtreleme yapmanız gerekebilir.

                // JSON formatında randevu listesini döndür
                return Json(randevular);
            }

            return Json(new { ErrorMessage = "AppUserId geçerli bir sayı değil." });
        }
    }
}
