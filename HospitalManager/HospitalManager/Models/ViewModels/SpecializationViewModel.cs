using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.ViewModels
{
    public class SpecializationViewModel
    {
        public int Id { get; set; }

        public string SpecializationName { get; set; }

        public string Description { get; set; }

        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}
