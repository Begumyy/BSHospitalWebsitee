using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class DashboardAgentController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardAgentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Agent")]
        public IActionResult Agent()
        {
            return View();
        }
    }
}
