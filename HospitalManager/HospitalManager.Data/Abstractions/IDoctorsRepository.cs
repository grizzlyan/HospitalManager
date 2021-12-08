using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IDoctorsRepository
    {
        Task<Doctor> CreateAsync(Doctor model);

        Task<IEnumerable<Doctor>> GetAllAsync();

        Task<IEnumerable<Doctor>> GetPaginationDoctors(
            PaginationFilters<Doctor> paginationFilters,
            SortFilter<Doctor> sortFilter,
            PagePagination pagePagination);

        Task<Doctor> GetByIdAsync(int id);

        Task<int> GetCountDoctorsAsync();

        Task UpdateAsync(Doctor model);

        Task UpdatePathToPhotoAsync(int id, string pathToPhoto);

        Task DeleteAsync(int id);
    }
}
