using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PaginationsModels
{
    public class SortFilterParametres<T> where T: struct
    {
        public SortDirectionEnum? sortDirection { get; set; }
        public T? SortField { get; set; }
    }
}
