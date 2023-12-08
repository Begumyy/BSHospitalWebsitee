using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ControllerBase1 : Controller
    {
        //public readonly IUnitOfWork unitOfWork;
        //public ControllerBase(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

    }
}
