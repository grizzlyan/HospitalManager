using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PaginationsModels
{
    public class PagePaginationSortFilterModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int? SortDirection { get; set; }
        public int? SortField { get; set; }
    }
}
