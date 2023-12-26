using BSHospital.Repository.Shared.Abstract;
using CineScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class AgentController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
            return Ok();
        }


        public IActionResult GetAll()
        {

            return Json(_unitOfWork.Users.GetAll().Include(u => u.UserType).ToList());
        }

        public IActionResult GetAllRoles()
        {

            return Json(_unitOfWork.UserTypes.GetAll().ToList());
        }
    }
}
