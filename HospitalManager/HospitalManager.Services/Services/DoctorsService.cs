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
    public class DoctorsService : IDoctorsService
    {
        private readonly IDoctorsRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorsService(IDoctorsRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorModel> Create(DoctorModel model)
        {
            var entity = _mapper.Map<Doctor>(model);

            await _doctorRepository.CreateAsync(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task Delete(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }

        public async Task<DoctorModel> Get(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            return _mapper.Map<DoctorModel>(doctor);
        }

        public async Task<List<DoctorModel>> GetAll()
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

        public async Task Update(DoctorModel model)
        {
            var doctor = _mapper.Map<Doctor>(model);
            await _doctorRepository.UpdateAsync(doctor);
        }
    }
}
