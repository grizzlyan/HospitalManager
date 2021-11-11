using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
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

        public async Task<MedicalProfessionModel> Create(MedicalProfessionModel model)
        {
            var entity = _mapper.Map<MedicalProfession>(model);

            await _medicalProfessionRepository.CreateAsync(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task Delete(int id)
        {
            await _medicalProfessionRepository.DeleteAsync(id);
        }

        public async Task<MedicalProfessionModel> Get(int id)
        {
            var medicalProfession = await _medicalProfessionRepository.GetByIdAsync(id);

            return _mapper.Map<MedicalProfessionModel>(medicalProfession);
        }

        public async Task<List<MedicalProfessionModel>> GetAll()
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

        public async Task Update(MedicalProfessionModel model)
        {
            var medicalProfession = _mapper.Map<MedicalProfession>(model);
            await _medicalProfessionRepository.UpdateAsync(medicalProfession);
        }
    }
}
