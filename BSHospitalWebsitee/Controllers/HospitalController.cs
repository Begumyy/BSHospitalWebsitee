using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    
    public class HospitalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitalController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            _unitOfWork.Hospitals.Add(hospital);
            _unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            var list = _unitOfWork.Hospitals.GetAll();
            return Json(list);
            //return Json(new {data=unitOfWork.Hospitals.GetAll().ToList()});
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Hospitals.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }
        
        //controller'larin içinde hangisine authorization koymak istersen onun üzerine aşağıdaki gibi yazıyoruz.
        [Authorize(Roles ="Admin,Doctor")]
        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            _unitOfWork.Hospitals.Update(hospital);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
