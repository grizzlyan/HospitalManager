using HospitalManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PaginationsModels
{
    public class PaginationViewModel <T>
    {
        public IEnumerable<T> DoctorsData { get; set; }
        public int TotalCount { get; set; }
    }
}
