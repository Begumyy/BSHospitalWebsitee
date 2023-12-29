using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class OnaylananlarController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public OnaylananlarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult GetAll()
        {
                var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).Where(u => u.IsAccepted==true).Where(u=>u.IsDeclined==false).ToList();
                return Json(list);
        }
        [HttpPost]
        public IActionResult AcceptById(int id)
        {
            
            _unitOfWork.Appointments.AcceptById(id);
            _unitOfWork.Save();
            return Ok(id);
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
    }
}
