using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.AuthModels
{
    public enum RolesEnum
    {
        [Description("Manager")]
        Manager = 1,
        [Description("Doctor")]
        Doctor = 2,
        [Description("Patient")]
        Patient = 3
    }
}
