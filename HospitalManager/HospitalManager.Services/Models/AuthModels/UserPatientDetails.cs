using HospitalManager.Services.Models.AuthModels.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.AuthModels
{
    public class UserPatientDetails : UserDetails
    {
        [Required]
        public string City { get; set; }
    }
}
