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
    public class SpetializationsService : ISpecializationsService
    {
        private readonly ISpecializationsRepository _specializationRepository;
        private readonly IMapper _mapper;

        public SpetializationsService(ISpecializationsRepository specializationRepository, IMapper mapper)
        {
            _specializationRepository = specializationRepository;
            _mapper = mapper;
        }

        public async Task<SpecializationModel> CreateAsync(SpecializationModel model)
        {
            var entity = _mapper.Map<Specialization>(model);

            await _specializationRepository.CreateAsync(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            await _specializationRepository.DeleteAsync(id);
        }

        public async Task<SpecializationModel> GetByIdAsync(int id)
        {
            var specialization = await _specializationRepository.GetByIdAsync(id);

            return _mapper.Map<SpecializationModel>(specialization);
        }

        public async Task<List<SpecializationModel>> GetAllAsync()
        {
            var resultSpecializationsList = new List<SpecializationModel>();

            var specializations = await _specializationRepository.GetAllAsync();

            foreach (var item in specializations)
            {
                var specialization = _mapper.Map<SpecializationModel>(item);
                resultSpecializationsList.Add(specialization);
            }

            return resultSpecializationsList;
        }

        public async Task UpdateAsync(SpecializationModel model)
        {
            var specialization = _mapper.Map<Specialization>(model);
            await _specializationRepository.UpdateAsync(specialization);
        }

        public async Task<PaginationModel<SpecializationModel>> GetPaginationSpecializationsAsync (
            SortFilterModel<SortSpecializationFieldEnum> sortFilter,
            PagePaginationModel pagePagination)
        {
            var specializationSortFilter = _mapper.Map<SortFilter<Specialization>>(sortFilter);
            var pagePgination = _mapper.Map<PagePagination>(pagePagination);

            var medicalProffessions = await _specializationRepository.GetPaginationSpecializationsAsync(
                specializationSortFilter, 
                pagePgination);

            var resultSpecializations = new List<SpecializationModel>();

            foreach (var item in medicalProffessions)
            {
                var specialization = _mapper.Map<SpecializationModel>(item);
                resultSpecializations.Add(specialization);
            }

            var countSpecializations = await _specializationRepository.GetCountSpecializationsAsync();

            var specializationsData = new PaginationModel<SpecializationModel>
            {
                Data = resultSpecializations,
                TotalCount = countSpecializations
            };

            return specializationsData;
        }
    }
}
