using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            _unitOfWork.Departments.Add(department);
            _unitOfWork.Save();
            return Ok();
        }

        public IActionResult GetAll()
        {
            //return Json(new { data = unitOfWork.Departments.GetAll().ToList() });
            var list = _unitOfWork.Departments.GetAll();
            return Json(list);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Departments.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            _unitOfWork.Departments.Update(department);
            _unitOfWork.Save();
            return Ok();
        }

        
    }
}
