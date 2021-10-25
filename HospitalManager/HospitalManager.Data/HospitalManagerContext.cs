using HospitalManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data
{
    public class HospitalManagerContext : DbContext
    {
        public HospitalManagerContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<MedicalProfession> MedicalProfessions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=customerdb;Trusted_Connection=True;");
        }
    }
}
