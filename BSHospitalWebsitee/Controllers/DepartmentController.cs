using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            _unitOfWork.Departments.Add(department);
            _unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Departments.GetAll().ToList());
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
