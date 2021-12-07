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
using System.Threading;
using System.Threading.Tasks;

namespace HospitalManager.Services.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly SemaphoreSlim _semaphoreSlim;

        public AppointmentsService(IAppointmentsRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _semaphoreSlim = new SemaphoreSlim(1);
        }

        public async Task<AppointmentModel> CreateAsync(AppointmentModel model)
        {
            var entity = _mapper.Map<Appointment>(model);

            bool isConainsAppointment;

            await _semaphoreSlim.WaitAsync();

            isConainsAppointment = await _appointmentRepository.IsContainsAppointmentAsync(entity);

            _semaphoreSlim.Release();

            if (!isConainsAppointment)
            {
                var createdAppointment = await _appointmentRepository.CreateAsync(entity);
                model.Id = createdAppointment.Id;

                return model;
            }

            return null;
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

        public async Task<IEnumerable<AppointmentModel>> GetAllByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetAllByDoctorIdAsync(doctorId);

            var appointmentsByDoctorId = new List<AppointmentModel>();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentModel>(item);
                appointmentsByDoctorId.Add(appointment);
            }

            return appointmentsByDoctorId;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllByPatientIdAsync(int patientId)
        {
            var appointments = await _appointmentRepository.GetAllByPatientIdAsync(patientId);

            var appointmentsByPatientId = new List<AppointmentModel>();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentModel>(item);
                appointmentsByPatientId.Add(appointment);
            }

            return appointmentsByPatientId;
        }

        public async Task<IEnumerable<AppointmentModel>> GetAllAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            var resultAppointmentsList = new List<AppointmentModel>();

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
