using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models
{
    public class MedicalProfessionModel
    {
        public int Id { get; set; }

        public string ProfessionName { get; set; }

        public IEnumerable<DoctorModel> Doctors { get; set; }
    }
}
