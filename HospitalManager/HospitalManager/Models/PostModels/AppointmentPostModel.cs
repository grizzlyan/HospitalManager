using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PostModels
{
    public class AppointmentPostModel
    {
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
