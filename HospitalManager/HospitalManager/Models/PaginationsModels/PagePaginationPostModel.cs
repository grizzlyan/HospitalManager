using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PaginationsModels
{
    public class PagePaginationPostModel
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
