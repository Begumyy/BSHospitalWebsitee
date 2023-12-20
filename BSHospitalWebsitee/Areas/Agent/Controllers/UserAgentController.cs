﻿using BSHospital.Repository.Shared.Abstract;
using CineScore.Models.DTOs;
using CineScore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using BSHospital.Repository.Shared.Concrete;
using NuGet.Protocol.Core.Types;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class UserAgentController : ControllerBase2
    {
        private readonly IUnitOfWork unitOfWork;

        public UserAgentController(IUnitOfWork unitOfWork)
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

                claims.Add(new Claim(ClaimTypes.Role, user.UserType.TypeName));
                //claims.Add(new Claim(ClaimTypes.Role, "Agent"));
                //claims.Add(new Claim(ClaimTypes.Role, "User"));
                //claims.Add(new Claim(ClaimTypes.Actor, user.Email));
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "DashboardAgent");

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = LoginDto.RememberMe });
                 if (user.UserType.TypeName == "Agent")
                {
                    return RedirectToAction("Agent", "DashboardAgent");
                    
                }
            }
            else
            {
                TempData["Error"] = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            return Ok();
        }



        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // ... (kodlarınız)

                    unitOfWork.Save();

                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    // Veritabanı kayıt hatası
                    // ex.Message veya ex.InnerException.Message gibi hata mesajlarını loglayabilirsiniz.
                    ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu.");
                    ViewBag.ErrorMessage = "Veritabanı Kayıt Hatası: " + ex.Message;

                    return View(loginDto);
                }
            }
            else
            {
                // ModelState geçerli değilse, hata mesajları ile birlikte kayıt sayfasını tekrar göster.
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"{key}: {error.ErrorMessage}");
                    }
                }

                return View(loginDto);
            }
        }



        //[HttpPost]
        //public IActionResult Add()
        //{
        //    unitOfWork.Users.Add();
        //}
    }
}
