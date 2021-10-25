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
    public class MedicalProfessionRepository : IMedicalProfessionRepository
    {
        private readonly HospitalManagerContext _ctx;

        public MedicalProfessionRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Create(MedicalProfession model)
        {
            _ctx.MedicalProfessions.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var profession = await _ctx.MedicalProfessions.FindAsync(id);
            _ctx.Remove(profession);
        }

        public async Task<MedicalProfession> Get(int id)
        {
            return await _ctx.MedicalProfessions
                .Include(x => x.Doctors)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MedicalProfession>> GetAll()
        {
            return await _ctx.MedicalProfessions
               .Include(x => x.Doctors)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task Update(MedicalProfession model)
        {
            var profession = await _ctx.MedicalProfessions.FindAsync(model.Id);
            profession.ProfessionName = model.ProfessionName;

            _ctx.MedicalProfessions.Update(profession);
            await _ctx.SaveChangesAsync();
        }
    }
}
