using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class DepartmentController : ControllerBase1
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

        [HttpPost]
        public IActionResult Add(Department department)
        {
            if (department.DepartmantName!=null)
            {
                _unitOfWork.Departments.Add(department);
                _unitOfWork.Save();

            }
            return Json(new { success = true });
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Departments.GetAll().ToList() );
        }

        [HttpPost]
        public IActionResult DeleteById(int departmentId)
        {
            _unitOfWork.Departments.DeleteById(departmentId);
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
