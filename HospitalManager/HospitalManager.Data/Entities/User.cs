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
        public IEnumerable<Doctor> Doctors { get; set; }

        public IEnumerable<Patient> Patients { get; set; }
    }
}
