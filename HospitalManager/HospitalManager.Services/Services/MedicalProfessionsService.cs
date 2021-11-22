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
    public class MedicalProfessionsService : IMedicalProfessionsService
    {
        private readonly IMedicalProfessionsRepository _medicalProfessionRepository;
        private readonly IMapper _mapper;

        public MedicalProfessionsService(IMedicalProfessionsRepository medicalProfessionRepository, IMapper mapper)
        {
            _medicalProfessionRepository = medicalProfessionRepository;
            _mapper = mapper;
        }

        public async Task<MedicalProfessionModel> CreateAsync(MedicalProfessionModel model)
        {
            var entity = _mapper.Map<MedicalProfession>(model);

            await _medicalProfessionRepository.CreateAsync(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            await _medicalProfessionRepository.DeleteAsync(id);
        }

        public async Task<MedicalProfessionModel> GetByIdAsync(int id)
        {
            var medicalProfession = await _medicalProfessionRepository.GetByIdAsync(id);

            return _mapper.Map<MedicalProfessionModel>(medicalProfession);
        }

        public async Task<List<MedicalProfessionModel>> GetAllAsync()
        {
            var resultMedicalProfessionsList = new List<MedicalProfessionModel>();

            var medicalProfessions = await _medicalProfessionRepository.GetAllAsync();

            foreach (var item in medicalProfessions)
            {
                var medicalProfession = _mapper.Map<MedicalProfessionModel>(item);
                resultMedicalProfessionsList.Add(medicalProfession);
            }

            return resultMedicalProfessionsList;
        }

        public async Task UpdateAsync(MedicalProfessionModel model)
        {
            var medicalProfession = _mapper.Map<MedicalProfession>(model);
            await _medicalProfessionRepository.UpdateAsync(medicalProfession);
        }

        public async Task<PaginationModel<MedicalProfessionModel>> GetPaginationMadicalProffesionsAsync (
            SortFilterModel<SortMedicalProffessionFieldEnum> sortFilter,
            PagePaginationModel pagePagination)
        {
            var medicalProffessionSortFilter = _mapper.Map<SortFilter<MedicalProfession>>(sortFilter);
            var pagePgination = _mapper.Map<PagePagination>(pagePagination);

            var medicalProffessions = await _medicalProfessionRepository.GetPaginationMedicalProffessions(
                medicalProffessionSortFilter, 
                pagePgination);

            var resultMedicalProffession = new List<MedicalProfessionModel>();

            foreach (var item in medicalProffessions)
            {
                var medicalProffession = _mapper.Map<MedicalProfessionModel>(item);
                resultMedicalProffession.Add(medicalProffession);
            }

            var countMedicalProffessions = await _medicalProfessionRepository.GetCountMedicalProffessionsAsync();

            var medicalProffessionsData = new PaginationModel<MedicalProfessionModel>
            {
                Data = resultMedicalProffession,
                TotalCount = countMedicalProffessions
            };

            return medicalProffessionsData;
        }
    }
}
