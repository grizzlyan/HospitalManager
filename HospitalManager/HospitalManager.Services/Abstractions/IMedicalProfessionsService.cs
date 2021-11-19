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
    public interface IMedicalProfessionsService
    {
        public Task<MedicalProfessionModel> CreateAsync(MedicalProfessionModel model);
        public Task UpdateAsync(MedicalProfessionModel model);
        public Task<MedicalProfessionModel> GetByIdAsync(int id);
        public Task<List<MedicalProfessionModel>> GetAllAsync();
        public Task DeleteAsync(int id);
        Task<IEnumerable<MedicalProfessionModel>> GetPaginationMadicalProffesionsAsync(
            SortFilterModel<SortMedicalProffessionFieldEnum> sortFilter,
            PagePaginationModel pagePagination);
        Task<int> GetTotalCountMedicalProffessionAsync();
    }
}
