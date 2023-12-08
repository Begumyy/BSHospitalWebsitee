using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class ControllerBase : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

    }
}
