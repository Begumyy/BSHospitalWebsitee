using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class RandevuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RandevuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            //var list=_unitOfWork.Appointments.GetAll(a=>a.IsCanceled==false).Include(a=>a.AppointmentDate).Include(a=>a.Department).Include(a=>a.Hospital).ToList();
            var list = _unitOfWork.Appointments.GetAll().ToList();
            return Json(list);
        }
    }
}
