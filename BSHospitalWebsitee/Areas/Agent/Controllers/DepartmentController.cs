using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class DepartmentController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Departments.GetAll().ToList());
        }
    }
}
