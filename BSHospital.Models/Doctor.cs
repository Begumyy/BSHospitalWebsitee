using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Doctor:BaseModel
    {
        [Required(ErrorMessage ="Doktor Seçiniz")]
        public string DoctorName { get; set; }
       


        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
       
       
    }
}
