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
    public interface IDoctorsService
    {
        Task<DoctorModel> CreateAsync(DoctorModel model);
        Task UpdateAsync(DoctorModel model);
        Task<DoctorModel> GetByIdAsync(int id);
        Task<List<DoctorModel>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<IEnumerable<DoctorModel>> GetPaginationsDoctorsAsync(DoctorFilterFieldsModel doctorFilterFields,
            SortFilterModel<SortDoctorFieldEnum> sortFilter,
            PagePaginationModel pagePagination);
        Task<int> GetTotalCountDoctorsAsync();
    }
}
