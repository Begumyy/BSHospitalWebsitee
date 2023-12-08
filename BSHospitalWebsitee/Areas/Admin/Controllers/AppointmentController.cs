using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
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
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).ToList();
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
        // evet sorun nerde simdi ? ne oluyor, ne yapınca ne oluyor ya da olmuyor :) siz beni duyabiliyor musun ? hayır ben gsöteriyorum hocam o zaman daha hızlı olur  hocam güncelleme oluyor gibi oldu ama bir değişiklik olmuyor  yeni kayıt da atmıyor dimi sadece guncellemiyoor  hayır hocam gordugun gibi hersey null geliyor boş bi cisim gonderiyorsun // id hala sıfır geliyor bak patient 'in içi doldu ama id 0 geldiği için patlıyor suan onuda getirdikmi sorun cozulecek
        //şıkır şıkır oldu bence  evet hocam gerçekten çok teşekür ederim 
        // içinden çıkmamadım ama ne yA:) ne yaptıgımı anlayabildiysen izlerken olay tamamdır.  ilkte patient ID gelmiyordu onun gelmesini sağladınız hocam patient id değil sadece orada direkt pateitn NESNESİ gonderiyoruz. nesneyi doldurduk o geldi sonra ana nesnene ID eklemeyi unutmussun. bir de garip birşey olmus update metodunu yazarken bi parantez hatasıyla tum parametreleri gecersiz kılmıssın evet hocam onları sonradan eklediğim içinonu atlamışım tamamdır o zaman ben çıkıyore ? 

        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            _unitOfWork.Appointments.Update(appointment);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
