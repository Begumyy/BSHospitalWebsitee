using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BSHospitalWebsitee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Department()
        {
            return View();
        }

        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).ToList();
            return Json(list);
        }

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