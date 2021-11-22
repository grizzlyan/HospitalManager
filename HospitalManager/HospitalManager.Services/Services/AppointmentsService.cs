using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Repositories;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class AppointmentsService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentsService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentModel> CreateAsync(AppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);

            await _appointmentRepository.CreateAsync(entity);
            model.Id = entity.Id;

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

        public async Task<AppointmentModel> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task<List<AppointmentModel>> GetAllAsync()
        {
            var resultAppointmentsList = new List<AppointmentModel>();

            var appointments = await _appointmentRepository.GetAllAsync();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentModel>(item);
                resultAppointmentsList.Add(appointment);
            }

            return resultAppointmentsList;
        }

        public async Task UpdateAsync(AppointmentModel model)
        {
            var appointment = _mapper.Map<Appointment>(model);
            await _appointmentRepository.UpdateAsync(appointment);
        }
    }
}
