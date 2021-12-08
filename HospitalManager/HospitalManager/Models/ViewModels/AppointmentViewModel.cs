using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int DoctorId { get; set; }
        public DoctorViewModel Doctor { get; set; }

        public int PatientId { get; set; }
        public PatientViewModel Patient { get; set; }
    }
}
