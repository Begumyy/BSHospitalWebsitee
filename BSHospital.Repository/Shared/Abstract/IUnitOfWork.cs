using BSHospital.Models;
using CineScore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Repository.Shared.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Appointment> Appointments { get; }
        IRepository<Department> Departments { get; }
        IRepository<Doctor> Doctors { get; }
        IRepository<Hospital> Hospitals { get; }
        IRepository<Patient> Patients { get; }
        IRepository<AppUser> Users { get; }
        IRepository<UserType> UserTypes { get; }
        IRepository<Onaylananlar> Onaylananlars { get; }
        

        void Save();
    }
}

