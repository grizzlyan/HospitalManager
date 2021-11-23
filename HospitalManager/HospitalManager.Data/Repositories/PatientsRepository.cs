using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public PatientsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Patient model)
        {
            _ctx.Patients.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _ctx.Patients.FindAsync(id);
            _ctx.Remove(patient);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _ctx.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _ctx.Patients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAsync(Patient model)
        {
            var patient = await _ctx.Patients.FindAsync(model.Id);
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.City = model.City;

            _ctx.Update(patient);
            await _ctx.SaveChangesAsync();
        }
    }
}
