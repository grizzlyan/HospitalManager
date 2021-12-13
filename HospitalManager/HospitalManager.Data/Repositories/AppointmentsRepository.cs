using HospitalManager.Data.Abstractions;
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
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public AppointmentsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Appointment> CreateAsync(Appointment model)
        {
            _ctx.Appointments.Add(model);
            await _ctx.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _ctx.Appointments.Include(x=>x.Doctor).Include(x=>x.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId)
        {
            return await _ctx.Appointments.Where(x => x.DoctorId == doctorId).Include(x=>x.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByPatientIdAsync(int patientId)
        {
            return await _ctx.Appointments.Where(x => x.PatientId == patientId).Include(x => x.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _ctx.Appointments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Appointment model, int id)
        {
            var appointment = await _ctx.Appointments.FindAsync(id);
            appointment.AppointmentDate = model.AppointmentDate;

            _ctx.Appointments.Update(appointment);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _ctx.Appointments.FindAsync(id);
            _ctx.Remove(appointment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> IsContainsAppointmentAsync(Appointment model)
        {
            return await _ctx.Appointments.AnyAsync(x => x.AppointmentDate == model.AppointmentDate);
        }
    }
}
