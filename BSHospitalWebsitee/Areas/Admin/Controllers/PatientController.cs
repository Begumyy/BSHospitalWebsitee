using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using CineScore.Models;
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
        //public IActionResult Add(Patient patient, int id)
        //{

            //        var existingPatient = _unitOfWork.Patients
            //.FirstOrDefault(p => p.TCKN == patient.TCKN);

            //        if (existingPatient != null)
            //        {
            //            // Aynı TCKN'ye sahip bir hasta bulunduğunda buraya gelinir

            //            // Randevuları getir
            //            existingPatient.Appointments = existingPatient.Appointments ?? new List<Appointment>();

            //            Appointment newAppointment = new Appointment();
            //            existingPatient.Appointments.Add(newAppointment);

            //            _unitOfWork.Save();

            //            return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //        }
            //        else
            //        {
            //            // Aynı TCKN'ye sahip bir hasta bulunamadığında buraya gelinir
            //            // Yeni hasta ekleme işlemini gerçekleştirin
            //            _unitOfWork.Patients.Add(patient);
            //            _unitOfWork.Save();

            //            return Ok("Hasta başarıyla eklendi.");
            //        }


            //var existingPatient = _unitOfWork.Patients.GetAll().FirstOrDefault(p => p.TCKN == patient.TCKN);

            //if (existingPatient != null)
            //{
            //    // Aynı TCKN'ye sahip bir hasta bulunduğunda buraya gelinir

            //    // Randevuları getir
            //    existingPatient.Appointments = _unitOfWork.Appointments.Where(a => a.PatientId == existingPatient.Id).ToList();

            //    if (existingPatient.Appointments == null)
            //    {
            //        existingPatient.Appointments = new List<Appointment>();
            //    }

            //    Appointment newAppointment = new Appointment();
            //    existingPatient.Appointments.Add(newAppointment);

            //    _unitOfWork.Save();

            //    return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //}
            //else
            //{
            //    // Aynı TCKN'ye sahip bir hasta bulunamadığında buraya gelinir
            //    // Yeni hasta ekleme işlemini gerçekleştirin
            //    _unitOfWork.Patients.Add(patient);
            //    _unitOfWork.Save();

            //    return Ok("Hasta başarıyla eklendi.");
            //}





            //// Önce veritabanında aynı TCKN'ye sahip bir hastayı kontrol et
            //var existingPatient = _unitOfWork.Patients
            //    .Include(p => p.Appointments)
            //    .FirstOrDefault(p => p.TCKN == patient.TCKN);

            //if (existingPatient != null)
            //{
            //    // Aynı TCKN'ye sahip bir hasta bulunduğunda buraya gelinir
            //    // Şimdi existingPatient üzerinden istediğiniz işlemi gerçekleştirin
            //    // Örneğin, randevu ekleme gibi bir işlem yapabilirsiniz

            //    if (existingPatient.Appointments == null)
            //    {
            //        existingPatient.Appointments = new List<Appointment>();
            //    }

            //    Appointment newAppointment = new Appointment();
            //    existingPatient.Appointments.Add(newAppointment);

            //    _unitOfWork.Save();

            //    return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //}
            //else
            //{
            //    // Aynı TCKN'ye sahip bir hasta bulunamadığında buraya gelinir
            //    // Yeni hasta ekleme işlemini gerçekleştirin
            //    _unitOfWork.Patients.Add(patient);
            //    _unitOfWork.Save();

            //    return Ok("Hasta başarıyla eklendi.");
            //}




            //if (patient.TCKN != null)
            //{
            //    // Hasta TCKN'si null değilse, belirli bir randevuyu güncelle
            //    var existingAppointment = _unitOfWork.Appointments.GetFirstOrDefault(a => a.Patient.TCKN == patient.TCKN);

            //    if (existingAppointment != null)
            //    {
            //        // İlgili randevu bulundu
            //        // İşlemlerinizi gerçekleştirin, örneğin iscancalled'ı false yapın
            //        existingAppointment.IsCanceled = false;

            //        _unitOfWork.Appointments.Update(existingAppointment);
            //        _unitOfWork.Save();

            //        return Ok("Hasta için randevu başarıyla güncellendi.");
            //    }
            //    else
            //    {
            //        return BadRequest("Belirtilen TCKN'ye sahip randevu bulunamadı.");
            //    }
            //}
            //else
            //{
            //    // Hasta TCKN'si null ise, yeni bir randevu oluştur
            //    Appointment newAppointment = new Appointment();

            //    // Yeni randevu özelliklerini ayarlayın...

            //    _unitOfWork.Appointments.Add(newAppointment);
            //    _unitOfWork.Save();

            //    return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //}



            //if (patient.TCKN != null)
            //{

            //    _unitOfWork.Appointments.UpdateById(id);

            //    _unitOfWork.Save();
            //    return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //}
            //else
            //{
            //    Appointment appointment = new Appointment();
            //    _unitOfWork.Appointments.Add(appointment);


            //    _unitOfWork.Save();
            //    return Ok("Hasta başarıyla eklendi.");
            //}



            //var existingPatient = _unitOfWork.Patients.Include(p => p.Appointments).FirstOrDefault(p => p.TCKN == patient.TCKN && (!p.Appointments.Any(a => a.IsCancelled || a.IsAccepted || a.IsDeclined)));

            //var existingPatient = _unitOfWork.Patients.Where(p => p.TCKN == patient.TCKN).Include(p => p.Appointments).FirstOrDefault(p => !p.Appointments.Any(a => a.IsCancelled || a.IsAccepted || a.IsDeclined));

            //var existingPatient = _unitOfWork.Patients.Where(p => p.TCKN == patient.TCKN).Include(p => p.Appointments).FirstOrDefault(p => !p.Appointments.Any(a => a.IsCancelled || a.IsAccepted || a.IsDeclined));

            //var existingPatient = _unitOfWork.Patients.Where(p => p.TCKN == patient.TCKN && !p.Appointments.Any(a => a.IsCancelled || a.IsAccepted || a.IsDeclined)).Include(p => p.Appointments).FirstOrDefault();


            //if (existingPatient != null)
            //{
            //    // Hasta bulundu, yeni randevu oluştur
            //    Appointment newAppointment = new Appointment();
            //    // Yeni randevu özelliklerini ayarla...

            //    existingPatient.Appointments.Add(newAppointment);
            //    _unitOfWork.Save();

            //    return Ok("Hasta için yeni randevu başarıyla oluşturuldu.");
            //}
            //else
            //{
            //    // Eğer TCKN'si ile eşleşen bir hasta yoksa, yeni bir hasta ekleyin
            //    _unitOfWork.Patients.Add(patient);
            //    _unitOfWork.Save();

            //    return Ok("Hasta başarıyla eklendi.");
            //}

        //}


        //[HttpPost]
        //public IActionResult Add( Patient patient)
        //{
        //    //2.DENEME
        //    // Eğer TCKN'si ile eşleşen bir hasta varsa ve en az bir durumu false ise
        //    //if (_unitOfWork.Patients.Any(p => p.TCKN == patient.TCKN &&
        //    //                                   (!p.IsCancelled || !p.IsAccepted || !p.IsDeclined)))
        //    //{
        //    //    return BadRequest("Bu TCKN'ye sahip hastanın iptal edilmiş, kabul edilmiş veya reddedilmiş bir randevusu var.");
        //    //}
        //    //else
        //    //{
        //    //    // Eğer TCKN'si ile eşleşen bir hasta yoksa, yeni bir hasta ekleyin
        //    //    _unitOfWork.Patients.Add(patient);
        //    //    _unitOfWork.Save();

        //    //    return Ok("Hasta başarıyla eklendi.");
        //    //}


        //    //1.DENEME
        //    //if (_unitOfWork.Patients.Any(p => p == patient.TCKN))
        //    //{
        //    //    return BadRequest("Bu TCKN'ye sahip hastanın iptal edilmiş bir randevusu yok.");
        //    //}
        //    //else
        //    //{
        //    //    _unitOfWork.Patients.Add(patient);
        //    //    _unitOfWork.Save();

        //    //    return Ok("Hasta başarıyla eklendi.");
        //    //}

        //    // ADD METHODU (zaten kullandığımız)
        //    _unitOfWork.Patients.Add(patient);
        //    _unitOfWork.Save();
        //    return Ok(patient);
        //}

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Patients.GetAll().Include(p=>p.Department).Include(p => p.Doctors).Include(p => p.Hospitals).ToList());
        }

        //public IActionResult GetAllDepartment()
        //{
        //    return Json(_unitOfWork.Departments.GetAll().ToList());
        //}

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

        [HttpPost]
        public IActionResult UpdateById(int id)
        {
            _unitOfWork.Appointments.UpdateById(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
