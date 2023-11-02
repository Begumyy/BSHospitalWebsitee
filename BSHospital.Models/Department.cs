using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Department:BaseModel
    {
        public virtual ICollection<Patient> Patients { get; set; }= new List<Patient>();
        public virtual ICollection<Doctor> Doctors { get; set; }= new List<Doctor>();
        public virtual ICollection<Hospital> Hospitals { get; set; }= new List<Hospital>();
        public virtual ICollection<Appointment> Appointments { get; set; }= new List<Appointment>();
    }
}
