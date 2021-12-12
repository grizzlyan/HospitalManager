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

        Task<IEnumerable<DoctorModel>> GetAllAsync();

        Task<IEnumerable<DoctorModel>> GetAllBySpecializationIdAsync(int id);

        Task<PaginationModel<DoctorModel>> GetPaginationsDoctorsAsync(DoctorFilterFieldsModel doctorFilterFields,
            SortFilterModel<SortDoctorFieldEnum> sortFilter,
            PagePaginationModel pagePagination);

        Task<DoctorModel> GetByIdAsync(int id);

        Task<DoctorModel> GetByUserIdAsync(string id);

        Task UpdateAsync(DoctorModel model, int id);

        Task UpdatePathToPhotoAsync(int id, string pathToPhoto);

        Task DeleteAsync(int id);
    }
}
