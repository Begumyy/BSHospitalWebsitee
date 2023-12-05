using BSHospital.Models;
using BSHospital.Models.DTOs;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            //AppUser user = _unitOfWork.Users.GetFirstOrDefault(u => u.Name==loginDto.UserName && u.Password==loginDto.Password);
            return View();
        }
    }
}
