using BSHospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineScore.Models
{
    [Table("Users")]
    public class AppUser:BaseModel
    {
        [EmailAddress(ErrorMessage ="Email doğru formatta girilmedi")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Gsm { get; set; }
        public int UserTypeId { get; set; }
        
        
        public virtual ICollection< Hospital>? Hospitals { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection< Department>? Departments { get; set; }
        public virtual ICollection< Appointment>? Appointments { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }=new List<Patient>();

        public bool IsUserTypeIdValid
        {
            get
            {
                // Eğer UserTypeId 0'dan büyükse ve UserType propertysine bir referans atanmışsa true döner.
                return UserTypeId > 0 && UserType != null;
            }
        }

        public bool IsInRole(string v)
        {
            throw new NotImplementedException();
        }
    }
}
