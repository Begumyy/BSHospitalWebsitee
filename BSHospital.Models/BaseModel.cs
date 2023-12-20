﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        
        public bool IsCanceled { get; set; } = false;

        public bool IsAccepted { get; set; } = false;
        public bool IsDeclined { get; set; } = false;
    }
}
