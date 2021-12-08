using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.Pagination
{
    public class DoctorFilterFieldsModel
    {
        public FilterDoctorFieldEnum? FilterDoctorField { get; set; }
        public int? SpecializationId { get; set; }
    }
}
