using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    [Area("Agent")]
    [Authorize(Roles = "Agent")]
    public class ControllerBase2 : Controller
    {
        
    }
}
