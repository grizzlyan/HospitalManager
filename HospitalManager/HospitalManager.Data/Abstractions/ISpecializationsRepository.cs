using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface ISpecializationsRepository
    {
        Task CreateAsync(Specialization model);
        Task<Specialization> GetByIdAsync(int id);
        Task<IEnumerable<Specialization>> GetAllAsync();
        Task UpdateAsync(Specialization model);
        Task DeleteAsync(int id);
        Task<IEnumerable<Specialization>> GetPaginationSpecializationsAsync(
            SortFilter<Specialization> sortFilter,
            PagePagination pagePagination);
        Task<int> GetCountSpecializationsAsync();
    }
}
