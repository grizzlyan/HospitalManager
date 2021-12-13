using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ModelListMapper<PatientModel, Patient> _modelListMapper;

        public PatientsService(IPatientsRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<PatientModel, Patient>(_mapper);
        }

        public async Task<PatientModel> CreateAsync(PatientModel model)
        {
            var entity = _mapper.Map<Patient>(model);

            var createdPatient = await _patientRepository.CreateAsync(entity);
            model.Id = createdPatient.Id;

            return model;
        }

        public async Task<IEnumerable<PatientModel>> GetAllAsync()
        {
            var patients = await _patientRepository.GetAllAsync();

            var resultPatientsList = _modelListMapper.MapModelList(patients);

            return resultPatientsList;
        }

        public async Task<PatientModel> GetByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            return _mapper.Map<PatientModel>(patient);
        }

        public async Task<PatientModel> GetByUserIdAsync(string id)
        {
            var patient = await _patientRepository.GetByUserIdAsync(id);

            return _mapper.Map<PatientModel>(patient);
        }

        public async Task UpdateAsync(PatientModel model, int id)
        {
            var patient = _mapper.Map<Patient>(model);
            await _patientRepository.UpdateAsync(patient, id);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
