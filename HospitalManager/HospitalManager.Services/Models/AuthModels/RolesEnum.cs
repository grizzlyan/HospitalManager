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
        Admin = 1,
        [Description("Doctor")]
        Manager = 2,
        [Description("Patient")]
        Customer = 3
    }
}
