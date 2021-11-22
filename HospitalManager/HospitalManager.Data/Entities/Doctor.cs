using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int WorkExperience { get; set; }

        public string PathToPhoto { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
