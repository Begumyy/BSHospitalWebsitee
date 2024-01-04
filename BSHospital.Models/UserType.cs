using BSHospital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineScore.Models
{
    public class UserType : BaseModel
    {
        [Required]
        public string TypeName { get; set; }


        
    }
}

