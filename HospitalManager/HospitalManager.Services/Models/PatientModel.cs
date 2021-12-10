using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models
{
    public class PatientModel
    {
        public int? Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string City { get; set; }

        public string UserId { get; set; }
    }
}
