using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class HospitalController : ControllerBase
    {
        public HospitalController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            unitOfWork.Hospitals.Add(hospital);
            unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Doctors.GetAll().ToList()});
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            unitOfWork.Hospitals.DeleteById(id);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            unitOfWork.Hospitals.Update(hospital);
            unitOfWork.Save();
            return Ok();
        }
    }
}
