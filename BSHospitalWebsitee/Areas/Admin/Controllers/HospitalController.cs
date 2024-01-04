﻿using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class HospitalController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;
        public HospitalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                // ModelState'deki hataları al

                return BadRequest(new { message = "Eksik veya hatalı alanlar var.", errors });
                
            }
            _unitOfWork.Hospitals.Add(hospital);
            _unitOfWork.Save();
            return Json(hospital);
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Hospitals.GetAll().ToList());
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Hospitals.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            _unitOfWork.Hospitals.Update(hospital);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
