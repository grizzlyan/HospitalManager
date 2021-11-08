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
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly HospitalManagerContext _ctx;

        public DoctorsRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(Doctor model)
        {
            _ctx.Doctors.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var doctor = await _ctx.Doctors.FindAsync(id);
            _ctx.Remove(doctor);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Doctor> Get(int id)
        {
            return await _ctx.Doctors
            .Include(x => x.MedicalProfession)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _ctx.Doctors
            .Include(x => x.MedicalProfession)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task Update(Doctor model)
        {
            var doctor = await _ctx.Doctors.FindAsync(model.Id);
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.EmploymentDate = model.EmploymentDate;
            doctor.WorkExperience = model.WorkExperience;
            doctor.MedicalProfessionId = model.MedicalProfessionId;

            _ctx.Doctors.Update(doctor);
            await _ctx.SaveChangesAsync();
        }
    }
}
