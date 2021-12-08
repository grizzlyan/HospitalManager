using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface ISpecializationsService
    {
        Task<SpecializationModel> CreateAsync(SpecializationModel model);

        Task<IEnumerable<SpecializationModel>> GetAllAsync();

        Task<PaginationModel<SpecializationModel>> GetPaginationSpecializationsAsync(
            SortFilterModel<SortSpecializationFieldEnum> sortFilter,
            PagePaginationModel pagePagination);

        Task<SpecializationModel> GetByIdAsync(int id);

        Task UpdateAsync(SpecializationModel model);

        Task DeleteAsync(int id);
    }
}
