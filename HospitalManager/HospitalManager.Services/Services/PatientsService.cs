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

        public async Task<PatientModel> Create(PatientModel model)
        {
            var entity = _mapper.Map<Patient>(model);

            await _patientRepository.Create(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task Delete(int id)
        {
            await _patientRepository.Delete(id);
        }

        public async Task<PatientModel> Get(int id)
        {
            var medicalProfession = await _patientRepository.Get(id);

            return _mapper.Map<PatientModel>(medicalProfession);
        }

        public async Task<List<PatientModel>> GetAll()
        {
            var resultPatientsList = new List<PatientModel>();

            var patients = await _patientRepository.GetAll();

            foreach (var item in patients)
            {
                var patient = _mapper.Map<PatientModel>(item);
                resultPatientsList.Add(patient);
            }

            return resultPatientsList;
        }

        public async Task Update(PatientModel model)
        {
            var patient = _mapper.Map<Patient>(model);
            await _patientRepository.Update(patient);
        }
    }
}
