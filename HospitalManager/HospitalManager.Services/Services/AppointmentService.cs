using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Repositories;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentModel> Create(AppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);

            await _appointmentRepository.Create(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task Delete(int id)
        {
            await _appointmentRepository.Delete(id);
        }

        public async Task<AppointmentModel> Get(int id)
        {
            var appointment = await _appointmentRepository.Get(id);

            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<List<AppointmentModel>> GetAll()
        {
            var resultAppointmentsList = new List<AppointmentModel>();

            var appointments = await _appointmentRepository.GetAll();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentModel>(item);
                resultAppointmentsList.Add(appointment);
            }

            return resultAppointmentsList;
        }

        public async Task Update(AppointmentModel model)
        {
            var appointment = _mapper.Map<Appointment>(model);
            await _appointmentRepository.Update(appointment);
        }
    }
}
