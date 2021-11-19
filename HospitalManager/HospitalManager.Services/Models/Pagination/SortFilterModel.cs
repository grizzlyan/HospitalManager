using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.Pagination
{
    public class SortFilterModel<T> where T: struct
    {
        public SortDirectionEnum? SortDirection { get; set; }
        public T? SortField { get; set; }
    }
}
