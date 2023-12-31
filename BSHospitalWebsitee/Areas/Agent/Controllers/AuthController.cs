using BSHospital.Repository.Shared.Abstract;
using CineScore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class AuthController : ControllerBase2
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private int? loggedInUserId;

        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AuthController(
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AppUser model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Kullanıcı girişi başarılı
                var user = await _userManager.FindByNameAsync(model.Email);
                var userId = user.Id;

                // Kullanıcının kimliği ile ilişkilendirilmiş verilere filtre uygula
                //var appointments = _unitOfWork.Appointments.GetAll().Where(a => a.AppUserId == userId).ToList();

                var appointments = _unitOfWork.Appointments.GetAll().Where(a => a.AppUserId == loggedInUserId && a.User.IsInRole("Agent"))
    .ToList();

                return Ok(appointments);
            }
            else
            {
                // Kullanıcı girişi başarısız
                return Unauthorized();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
