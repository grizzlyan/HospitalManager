using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities
{
    public class User : IdentityUser
    {
        public int DoctorId { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        public int PatientId { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

        public int ManagerId { get; set; }
        public IEnumerable<Manager> Managers { get; set; }
    }
}
