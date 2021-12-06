using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities
{
    public class Specialization
    {
        public int Id { get; set; }

        public string SpecializationName { get; set; }

        public string Description { get; set; }

        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
