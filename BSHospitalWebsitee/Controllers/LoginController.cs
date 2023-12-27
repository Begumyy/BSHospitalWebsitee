using BSHospital.Repository.Shared.Abstract;
using CineScore.Models.DTOs;
using CineScore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult User()
        {
            return Json(unitOfWork.Users.GetAll().ToList());
        }



        //Admin/User/Add diye bi yere post ediyorsun, ama burası Admin/User işte, ADD diye bir metot göremiyorum. anladım hocam tamam dmeekki ona bakmaklazım.

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(AppUser user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Save();
            //return View();
            return Ok();
        }

        [Authorize] // Sadece oturumu olan kullanıcılar bu action'a erişebilir
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // Oturumu sonlandır
            return RedirectToAction("Login", "Login"); // Çıkış yapıldığında login sayfasına yönlendir
        }

       


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto LoginDto)
        {
            AppUser user = unitOfWork.Users.GetAll(x => x.Email == LoginDto.UserName && x.Password == LoginDto.Password).Include(x => x.UserType).ToList().FirstOrDefault();
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Email));

                claims.Add(new Claim(ClaimTypes.Role, user.UserType.TypeName));
                //claims.Add(new Claim(ClaimTypes.Role, "Agent"));
                //claims.Add(new Claim(ClaimTypes.Role, "User"));
                //claims.Add(new Claim(ClaimTypes.Actor, user.Email));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Dashboard");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = LoginDto.RememberMe });
                if (user.UserType.TypeName == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new {Area ="Admin"});
                }
                else if (user.UserType.TypeName == "Agent")
                {
                    return RedirectToAction("Agent", "DashboardAgent", new {area="Agent"});
                }
                else if (user.UserType.TypeName == "User")
                {
                    return RedirectToAction("User", "Dashboard");
                }
            }
            else
            {
                TempData["Error"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            return Ok();
        }

        public IActionResult GetAll()
        {
            return Json(unitOfWork.Patients.GetAll().ToList());
        }
    }
}
