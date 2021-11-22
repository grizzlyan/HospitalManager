using HospitalManager.Data.Abstractions;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Repositories
{
    public class SpecializationsRepository : ISpecializationsRepository
    {
        private readonly HospitalManagerContext _ctx;

        public SpecializationsRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Specialization model)
        {
            _ctx.Specialization.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var specialization = await _ctx.Specialization.FindAsync(id);
            _ctx.Remove(specialization);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Specialization> GetByIdAsync(int id)
        {
            return await _ctx.Specialization
                .Include(x => x.Doctors)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await _ctx.Specialization
               .Include(x => x.Doctors)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task UpdateAsync(Specialization model)
        {
            var specialization = await _ctx.Specialization.FindAsync(model.Id);
            specialization.SpecializationName = model.SpecializationName;

            _ctx.Specialization.Update(specialization);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Specialization>> GetPaginationSpecializationsAsync(
            SortFilter<Specialization> sortFilter,
            PagePagination pagePagination)
        {
            var result = _ctx
                .Specialization
                .AsNoTracking();

            if (sortFilter != null)
            {
                if (sortFilter.IsAscending)
                {
                    result = result.OrderBy(sortFilter.SortPredicate);
                }
                else
                {
                    result = result.OrderByDescending(sortFilter.SortPredicate);
                }
            }

            var paginationSpecialization = await result
                .Skip((pagePagination.Page - 1) * pagePagination.PageSize)
                .Take(pagePagination.PageSize)
                .ToListAsync();

            return paginationSpecialization;
        }

        public async Task<int> GetCountSpecializationsAsync()
        {
            var count = await _ctx.Specialization.CountAsync();
            return count;
        }
    }
}
