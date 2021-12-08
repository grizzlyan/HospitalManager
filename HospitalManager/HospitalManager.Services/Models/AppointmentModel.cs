using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int DoctorId { get; set; }
        public DoctorModel Doctor { get; set; }

        public int PatientId { get; set; }
        public PatientModel Patient { get; set; }
    }
}
