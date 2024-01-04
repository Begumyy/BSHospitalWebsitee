using CineScore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class Patient:BaseModel
    {
        [Required(ErrorMessage = " Adınızı Giriniz")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = " Telefon Giriniz")]
        public string Phone {  get; set; }
        [Required(ErrorMessage = " Adres Giriniz")]
        public string Address { get; set; }
        [Required(ErrorMessage = " TCKN Giriniz")]
        public string TCKN { get; set; }

        [Required(ErrorMessage = " Yaşınızı Giriniz")]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public int? AppUserId { get; set; }
      
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
        public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
        public virtual Department Department { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
