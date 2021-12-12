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
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientsService(IPatientsRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
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
            var resultPatientsList = new List<PatientModel>();

            var patients = await _patientRepository.GetAllAsync();

            foreach (var item in patients)
            {
                var patient = _mapper.Map<PatientModel>(item);
                resultPatientsList.Add(patient);
            }

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

        public async Task UpdateAsync(PatientModel model)
        {
            var patient = _mapper.Map<Patient>(model);
            await _patientRepository.UpdateAsync(patient);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
