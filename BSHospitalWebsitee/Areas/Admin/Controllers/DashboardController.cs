using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize(Roles = "User")]
        public IActionResult User ()
        {
            return View();
        }

        [Authorize(Roles = "Agent")]
        public IActionResult Agent()
        {
            return View();
        }
    }
}
