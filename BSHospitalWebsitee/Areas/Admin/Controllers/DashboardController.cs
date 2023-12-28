using BSHospital.Repository.Shared.Abstract;
using CineScore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class DashboardController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")] // silinicek user areaya eklenecek
        public IActionResult User ()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Agent()
        {
            return View();
        }
    }
}
