using BSHospital.Data;
using BSHospital.Models;
using BSHospital.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSHospital.Repository.Shared.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Appointment> Appointments { get; private set; }

        public IRepository<Department> Departments { get; private set; }

        public IRepository<Doctor> Doctors { get; private set; }

        public IRepository<Hospital> Hospitals { get; private set; }

        public IRepository<Patient> Patients { get; private set; }
        public IRepository<AppUser> Users { get; private set; }
        

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Appointments = new Repository<Appointment>(_context);
            Departments = new Repository<Department>(_context);
            Doctors = new Repository<Doctor>(_context);
            Hospitals = new Repository<Hospital>(_context);
            Patients = new Repository<Patient>(_context);
            Users = new Repository<AppUser>(_context);
           
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
