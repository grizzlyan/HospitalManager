using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.ViewModels
{
    public class MedicalProfessionViewModel
    {
        public int Id { get; set; }

        public string ProfessionName { get; set; }

        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}
