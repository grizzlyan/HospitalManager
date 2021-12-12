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
        Task<Specialization> CreateAsync(Specialization model);

        Task<IEnumerable<Specialization>> GetAllAsync();

        Task<IEnumerable<Specialization>> GetPaginationSpecializationsAsync(
            SortFilter<Specialization> sortFilter,
            PagePagination pagePagination);

        Task<Specialization> GetByIdAsync(int id);

        Task<int> GetCountSpecializationsAsync();

        Task UpdateAsync(Specialization model, int id);

        Task DeleteAsync(int id); 
    }
}
