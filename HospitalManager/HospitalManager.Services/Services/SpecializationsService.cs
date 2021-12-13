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
    public class SpecializationsService : ISpecializationsService
    {
        private readonly ISpecializationsRepository _specializationRepository;
        private readonly IMapper _mapper;
        private readonly ModelListMapper<SpecializationModel, Specialization> _modelListMapper;

        public SpecializationsService(ISpecializationsRepository specializationRepository, IMapper mapper)
        {
            _specializationRepository = specializationRepository;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<SpecializationModel, Specialization>(_mapper);
        }

        public async Task<SpecializationModel> CreateAsync(SpecializationModel model)
        {
            var entity = _mapper.Map<Specialization>(model);

            var createdSpecialization = await _specializationRepository.CreateAsync(entity);
            model.Id = createdSpecialization.Id;

            return model;
        }

        public async Task<IEnumerable<SpecializationModel>> GetAllAsync()
        {
            var specializations = await _specializationRepository.GetAllAsync();

            var resultSpecializationsList = _modelListMapper.MapModelList(specializations);

            return resultSpecializationsList;
        }

        public async Task<PaginationModel<SpecializationModel>> GetPaginationSpecializationsAsync(
            SortFilterModel<SortSpecializationFieldEnum> sortFilter,
            PagePaginationModel pagePagination)
        {
            var specializationSortFilter = _mapper.Map<SortFilter<Specialization>>(sortFilter);
            var pagePgination = _mapper.Map<PagePagination>(pagePagination);

            var specializations = await _specializationRepository.GetPaginationSpecializationsAsync(
                specializationSortFilter,
                pagePgination);

            var resultSpecializations = _modelListMapper.MapModelList(specializations);

            var countSpecializations = await _specializationRepository.GetCountSpecializationsAsync();

            var specializationsData = new PaginationModel<SpecializationModel>
            {
                Data = resultSpecializations,
                TotalCount = countSpecializations
            };

            return specializationsData;
        }

        public async Task<SpecializationModel> GetByIdAsync(int id)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);

            return _mapper.Map<SpecializationModel>(specialization);
        }

        public async Task UpdateAsync(SpecializationModel model, int id)
        {
            var specialization = _mapper.Map<Specialization>(model);
            await _specializationRepository.UpdateAsync(specialization, id);
        }

        public async Task DeleteAsync(int id)
        {
            await _specializationRepository.DeleteAsync(id);
        }
    }
}
