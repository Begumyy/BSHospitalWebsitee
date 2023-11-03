using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospitalWebsitee.Controllers
{
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            unitOfWork.Departments.Add(department);
            unitOfWork.Save();
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Departments.GetAll().ToList()});
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            unitOfWork.Departments.DeleteById(id);
            unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            unitOfWork.Departments.Update(department);
            unitOfWork.Save();
            return Ok();
        }

        
    }
}
