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
    public class UserController : ControllerBase1
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
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
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto LoginDto)
        {
             AppUser user = unitOfWork.Users.GetAll(x => x.Email == LoginDto.UserName && x.Password == LoginDto.Password).Include(x => x.UserType).ToList().FirstOrDefault();
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Email));

                claims.Add(new Claim(ClaimTypes.Role,user.UserType.TypeName));
                //claims.Add(new Claim(ClaimTypes.Role, "Agent"));
                //claims.Add(new Claim(ClaimTypes.Role, "User"));
                //claims.Add(new Claim(ClaimTypes.Actor, user.Email));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Dashboard");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = LoginDto.RememberMe });
                if (user.UserType.TypeName=="Admin")
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (user.UserType.TypeName=="Agent")
                {
                    return RedirectToAction("Agent", "Dashboard");
                }
                else if (user.UserType.TypeName=="User")
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
    }
}
