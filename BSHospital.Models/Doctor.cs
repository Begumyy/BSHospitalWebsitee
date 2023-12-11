using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Doctor:BaseModel
    {
        public string DoctorName { get; set; }
       


        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
       
       
    }
}
