using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
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
        private readonly ModelListMapper<DoctorModel, Doctor> _modelListMapper;

        public DoctorsService(IDoctorsRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<DoctorModel, Doctor>(_mapper);
        }

        public async Task<DoctorModel> CreateAsync(DoctorModel model)
        {
            var entity = _mapper.Map<Doctor>(model);

            var createdDoctor = await _doctorRepository.CreateAsync(entity);
            model.Id = createdDoctor.Id;

            return model;
        }

        public async Task<IEnumerable<DoctorModel>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            var resultDoctorsList = _modelListMapper.MapModelList(doctors);

            return resultDoctorsList;
        }

        public async Task<IEnumerable<DoctorModel>> GetAllBySpecializationIdAsync(int id)
        {
            var doctors = await _doctorRepository.GetAllBySpecializationIdAsync(id);

            var resultDoctorsList = _modelListMapper.MapModelList(doctors);

            return resultDoctorsList;
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

            var resultDoctorsList = _modelListMapper.MapModelList(doctors);

            var countDoctors = await _doctorRepository.GetCountDoctorsAsync();

            var doctorsData = new PaginationModel<DoctorModel> { Data = resultDoctorsList, TotalCount = countDoctors };

            return doctorsData;
        }

        public async Task<DoctorModel> GetByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            return _mapper.Map<DoctorModel>(doctor);
        }

        public async Task<DoctorModel> GetByUserIdAsync(string id)
        {
            var doctor = await _doctorRepository.GetByUserIdAsync(id);

            return _mapper.Map<DoctorModel>(doctor);
        }

        public async Task UpdateAsync(DoctorModel model, int id)
        {
            var doctor = _mapper.Map<Doctor>(model);
            await _doctorRepository.UpdateAsync(doctor, id);
        }

        public async Task UpdatePathToPhotoAsync(int id, string pathToPhoto)
        {
            await _doctorRepository.UpdatePathToPhotoAsync(id, pathToPhoto);
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}
