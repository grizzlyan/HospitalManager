using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IDoctorsRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorsService(IDoctorsRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorModel> CreateAsync(DoctorModel model)
        {
            var entity = _mapper.Map<Doctor>(model);

            var createdDoctor = await _doctorRepository.CreateAsync(entity);
            model.Id = createdDoctor.Id;

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }

        public async Task<DoctorModel> GetByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            return _mapper.Map<DoctorModel>(doctor);
        }

        public async Task<IEnumerable<DoctorModel>> GetAllAsync()
        {
            var resultDoctorsList = new List<DoctorModel>();

            var doctors = await _doctorRepository.GetAllAsync();

            foreach(var item in doctors)
            {
                var doctor = _mapper.Map<DoctorModel>(item);
                resultDoctorsList.Add(doctor);
            }

            return resultDoctorsList;
        }

        public async Task UpdateAsync(DoctorModel model)
        {
            var doctor = _mapper.Map<Doctor>(model);
            await _doctorRepository.UpdateAsync(doctor);
        }

        public async Task UpdatePathToPhotoAsync(int id, string pathToPhoto)
        {
            await _doctorRepository.UpdatePathToPhotoAsync(id, pathToPhoto);
        }

        public async Task<PaginationModel<DoctorModel>> GetPaginationsDoctorsAsync(
            DoctorFilterFieldsModel doctorFilterFields,
            SortFilterModel<SortDoctorFieldEnum> sortFilter,
            PagePaginationModel pagePagination
            )
        {
            var paginationFilter = _mapper.Map<PaginationFilters<Doctor>>(doctorFilterFields);
            var doctorSortFilter = _mapper.Map<SortFilter<Doctor>>(sortFilter);
            var pagePgination = _mapper.Map<PagePagination>(pagePagination);

            var doctors = await _doctorRepository.GetPaginationDoctors(paginationFilter, doctorSortFilter, pagePgination);
            
            var resultDoctorsList = new List<DoctorModel>();

            foreach (var item in doctors)
            {
                var doctor = _mapper.Map<DoctorModel>(item);
                resultDoctorsList.Add(doctor);
            }

            var countDoctors = await _doctorRepository.GetCountDoctorsAsync();

            var doctorsData = new PaginationModel<DoctorModel> { Data = resultDoctorsList, TotalCount = countDoctors };

            return doctorsData;
        }
    }
}
