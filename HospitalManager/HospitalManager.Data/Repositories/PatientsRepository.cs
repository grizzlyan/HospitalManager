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
        private readonly HospitalManagerContext _ctx;

        public PatientsRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Patient model)
        {
            _ctx.Patients.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var patient = await _ctx.Patients.FindAsync(id);
            _ctx.Remove(patient);
        }

        public async Task<Patient> Get(int id)
        {
            return await _ctx.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _ctx.Patients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Update(Patient model)
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
