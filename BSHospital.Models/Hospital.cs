﻿using CineScore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Hospital:BaseModel
    {
        [Required(ErrorMessage ="Hopital Giriniz")]
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Adres Giriniz")]
        public string Address { get; set; }
        public int? AppUserId { get; set; }

        public virtual AppUser  User { get; set; }
       
        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
