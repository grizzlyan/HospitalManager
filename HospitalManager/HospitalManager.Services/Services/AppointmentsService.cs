using AutoMapper;
using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Repositories;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly ModelListMapper<AppointmentModel, Appointment> _modelListMapper;

        public AppointmentsService(IAppointmentsRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<AppointmentModel, Appointment>(_mapper);
        }

        public async Task<AppointmentModel> CreateAsync(AppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);

            var isConainsAppointment = await _appointmentRepository.IsContainsAppointmentAsync(entity);

            if (!isConainsAppointment)
            {
                var createdAppointment = await _appointmentRepository.CreateAsync(entity);
                model.Id = createdAppointment.Id;

                return model;
            }

            return null;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            var resultAppointmentsList = _modelListMapper.MapModelList(appointments);

            return resultAppointmentsList;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAllByDoctorIdAsync(doctorId);

            var appointmentsByDoctorId = _modelListMapper.MapModelList(appointments);

            return appointmentsByDoctorId;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var appointments = await _appointmentRepository.GetAllByPatientIdAsync(patientId);

            var appointmentsByPatientId = _modelListMapper.MapModelList(appointments);

            return appointmentsByPatientId;
        }

        public async Task<AppointmentModel> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            return _mapper.Map<AppointmentModel>(appointment);
        }

        public async Task UpdateAsync(AppointmentModel model, int id)
        {
            var appointment = _mapper.Map<Appointment>(model);
            await _appointmentRepository.UpdateAsync(appointment, id);
        }

        public async Task DeleteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }
    }
}
