using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities.Pagination
{
    public class PaginationFilters<T>
    {
        public List<Expression<Func<T, bool>>> FilterPredicates { get; set; }
    }
}
