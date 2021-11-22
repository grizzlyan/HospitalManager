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
        public Task<SpecializationModel> CreateAsync(SpecializationModel model);
        public Task UpdateAsync(SpecializationModel model);
        public Task<SpecializationModel> GetByIdAsync(int id);
        public Task<List<SpecializationModel>> GetAllAsync();
        public Task DeleteAsync(int id);
        Task<PaginationModel<SpecializationModel>> GetPaginationSpecializationsAsync(
            SortFilterModel<SortSpecializationFieldEnum> sortFilter,
            PagePaginationModel pagePagination);
    }
}
