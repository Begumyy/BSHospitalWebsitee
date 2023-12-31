﻿using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using CineScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class AppointmentController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).ToList();
            return Json(list);
            //return Json(_unitOfWork.Appointments.GetAll().ToList());
        }
    }
}
