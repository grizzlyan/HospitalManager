﻿using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _ctx;

        public AppointmentRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Appointment model)
        {
            var appointmentDate = await _ctx.Appointments.AnyAsync(x => x.AppointmentDate == model.AppointmentDate);

            if (!appointmentDate)
            {
                _ctx.Appointments.Add(model);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _ctx.Appointments.FindAsync(id);
            _ctx.Remove(appointment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _ctx.Appointments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId)
        {
            return await _ctx.Appointments.Where(x => x.DoctorId == doctorId).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _ctx.Appointments.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Appointment model)
        {
            var appointment = await _ctx.Appointments.FindAsync(model.Id);
            appointment.AppointmentDate = model.AppointmentDate;
            appointment.AppointmentDuration = model.AppointmentDuration;
            appointment.DoctorId = model.DoctorId;
            appointment.PatientId = model.PatientId;

            _ctx.Appointments.Update(appointment);
            await _ctx.SaveChangesAsync();
        }
    }
}
