using CineScore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Appointment:BaseModel
    {
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public int? AppUserId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;


        public virtual Patient Patient { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual AppUser User { get; set; }
        
    }
}
