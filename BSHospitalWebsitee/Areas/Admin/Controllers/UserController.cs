using BSHospital.Repository.Shared.Concrete;
using CineScore.Models.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BSHospital.Repository.Shared.Abstract;
using CineScore.Models;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class UserController : ControllerBase
    {
        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
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
                claims.Add(new Claim(ClaimTypes.GivenName, user.Email));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Login");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = LoginDto.RememberMe });
                if (HttpContext.User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (HttpContext.User.IsInRole("Editor"))
                {
                    return RedirectToAction("Agent", "Dashboard");
                }
                else
                {
                    return RedirectToAction("User", "Dashboard");
                }
            }
            else
            {
                TempData["Error"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }
    }
}
