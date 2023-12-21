﻿using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class IptalOlanlarController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public IptalOlanlarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {

            return View();
        }


        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).Where(u => u.IsDeclined == true).ToList();
            return Json(list);
        }

        [HttpPost]
        public IActionResult DeclineById(int id)
        {
            _unitOfWork.Appointments.DeclineById(id);
            _unitOfWork.Save();
            return Ok(id);
        }
    }
}
