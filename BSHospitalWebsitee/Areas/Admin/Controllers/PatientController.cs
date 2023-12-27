﻿using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using BSHospital.Repository.Shared.Concrete;
using CineScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Appointment = BSHospital.Models.Appointment;

namespace BSHospital.Websitee.Areas.Admin.Controllers
{
    public class PatientController : ControllerBase1
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add( Patient patient)
        {   
            _unitOfWork.Patients.Add(patient);
            _unitOfWork.Save();
            
            return Ok(patient);


            
        }

        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Patients.GetAll().Include(p=>p.Department).Include(p => p.Doctors).Include(p => p.Hospitals).Include(p => p.AppUser).ToList());
        }
        //public IActionResult GetAllDepartment()
        //{
        //    return Json(_unitOfWork.Departments.GetAll().ToList());
        //}

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            _unitOfWork.Patients.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Başarıyla silindi");
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            _unitOfWork.Patients.Update(patient);
            _unitOfWork.Save();
            return Ok();
        }
    }
}