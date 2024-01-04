﻿using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSHospital.Websitee.Areas.Agent.Controllers
{
    public class DashboardAgentController : ControllerBase2
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardAgentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Agent")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Agent")]
        public IActionResult Agent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Email", "E-posta adresi doğru formatta değil");
                // Eğer modelin doğruluğu sağlanmıyorsa, hataları inceleyebilir veya uygun bir şekilde işleyebilirsiniz
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Hataları inceleyip uygun bir şekilde cevap verebilirsiniz

                return BadRequest(new { message = "E-posta adresi doğru formatta değil", errors = ModelState });
            }

            // Ardından randevuyu ekleyin
            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Save();
            return Ok(appointment.Id);

        }
        public IActionResult GetAll()
        {
            var list = _unitOfWork.Appointments.GetAll().Include(u => u.Patient).Include(u => u.Hospital).Include(u => u.Department).Include(u => u.Doctor).Where(a=>a.IsAccepted==false).Where(a => a.IsDeclined == false).ToList();
            return Json(list);
        }
        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            
            _unitOfWork.Appointments.DeleteById(id);
            _unitOfWork.Save();
            return Ok(id);
        }

       
        [HttpPost]
        public IActionResult Update(Appointment appointment)
        {
            _unitOfWork.Appointments.Update(appointment);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
