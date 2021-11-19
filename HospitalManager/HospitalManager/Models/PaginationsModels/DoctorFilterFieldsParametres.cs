using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PaginationsModels
{
    public class DoctorFilterFieldsParametres
    {
        public FilterDoctorFieldEnum? filterDoctorField { get; set; }
        public int? MedicalProffessionId { get; set; }
    }
}
