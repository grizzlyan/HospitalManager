using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PostModels
{
    public class AppointmentPostModel
    {
        public DateTime AppointmentDate { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
