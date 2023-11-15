﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Patient:BaseModel
    {
        public string Phone {  get; set; }
        public string Address { get; set; }
        public string TCKN { get; set; }
       
        public int Age { get; set; }
        public int? DepartmentId { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
        public virtual Department Department { get; set; }

    }
}
