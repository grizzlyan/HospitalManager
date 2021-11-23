﻿using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IAppointmentService
    {
        public Task<AppointmentModel> CreateAsync(AppointmentModel model);

        public Task DeleteAsync(int id);

        public Task<AppointmentModel> GetByIdAsync(int id);

        Task<IEnumerable<AppointmentModel>> GetAllByDoctorIdAsync(int doctorId);

        public Task<IEnumerable<AppointmentModel>> GetAllAsync();

        public Task UpdateAsync(AppointmentModel model);
    }
}
