using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int WorkExperience { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MedicalProfessionId { get; set; }
        public MedicalProfessionViewModel MedicalProfession { get; set; }
    }
}
