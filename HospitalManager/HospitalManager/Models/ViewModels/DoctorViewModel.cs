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

        public string PathToPhoto { get; set; }

        public int SpecializationId { get; set; }
        public SpecializationViewModel Specialization { get; set; }
    }
}
