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
    public class MedicalProfessionsRepository : IMedicalProfessionsRepository
    {
        private readonly HospitalManagerContext _ctx;

        public MedicalProfessionsRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(MedicalProfession model)
        {
            _ctx.MedicalProfessions.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profession = await _ctx.MedicalProfessions.FindAsync(id);
            _ctx.Remove(profession);
            await _ctx.SaveChangesAsync();
        }

        public async Task<MedicalProfession> GetByIdAsync(int id)
        {
            return await _ctx.MedicalProfessions
                .Include(x => x.Doctors)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MedicalProfession>> GetAllAsync()
        {
            return await _ctx.MedicalProfessions
               .Include(x => x.Doctors)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task UpdateAsync(MedicalProfession model)
        {
            var profession = await _ctx.MedicalProfessions.FindAsync(model.Id);
            profession.ProfessionName = model.ProfessionName;

            _ctx.MedicalProfessions.Update(profession);
            await _ctx.SaveChangesAsync();
        }
    }
}
