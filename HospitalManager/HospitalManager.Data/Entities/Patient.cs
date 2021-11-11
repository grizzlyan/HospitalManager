using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
