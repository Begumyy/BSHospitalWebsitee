﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Doctor:BaseModel
    {
        public string DepartmentName { get; set; }
        public int HospitalId { get; set; }

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
