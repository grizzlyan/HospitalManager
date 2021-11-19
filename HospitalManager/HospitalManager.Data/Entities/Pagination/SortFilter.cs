using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Entities.Pagination
{
    public class SortFilter <T>
    {
        public bool IsAscending { get; set; }
        public Expression<Func<T, object>> SortPredicate { get; set; }
    }
}
