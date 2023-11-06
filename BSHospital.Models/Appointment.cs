using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Appointment:BaseModel
    {
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public virtual Hospital Hospital { get; set; }
        public virtual Department Department { get; set; }
        
    }
}
