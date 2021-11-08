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

        public int AppointmentId { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

        public int MedicalProfessionId { get; set; }
        public MedicalProfession MedicalProfession { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
