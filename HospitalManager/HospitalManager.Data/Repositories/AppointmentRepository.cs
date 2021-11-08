using HospitalManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Repositories
{
    public class AppointmentRepository
    {
        private readonly HospitalManagerContext _ctx;

        public AppointmentRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Appointment model)
        {
            _ctx.Appointments.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var appointment = await _ctx.Appointments.FindAsync(id);
            _ctx.Remove(appointment);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Appointment> Get(int id)
        {
            return await _ctx.Appointments
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _ctx.Appointments
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task Update(Appointment model)
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
