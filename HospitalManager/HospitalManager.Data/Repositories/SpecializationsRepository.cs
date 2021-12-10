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
        private readonly ApplicationDbContext _ctx;

        public SpecializationsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Specialization> CreateAsync(Specialization model)
        {
            _ctx.Specializations.Add(model);
            await _ctx.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {               
            return await _ctx.Specializations.ToListAsync();
        }

        public async Task<IEnumerable<Specialization>> GetPaginationSpecializationsAsync(
            SortFilter<Specialization> sortFilter,
            PagePagination pagePagination)
        {
            var result = _ctx
                .Specializations
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

        public async Task<Specialization> GetByIdAsync(int id)
        {
            return await _ctx.Specializations
                .Include(x => x.Doctors)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCountSpecializationsAsync()
        {
            var count = await _ctx.Specializations.CountAsync();
            return count;
        }

        public async Task UpdateAsync(Specialization model)
        {
            var specialization = await _ctx.Specializations.FindAsync(model.Id);
            specialization.SpecializationName = model.SpecializationName;
            specialization.Description = model.Description;

            _ctx.Specializations.Update(specialization);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var specialization = await _ctx.Specializations.FindAsync(id);
            _ctx.Remove(specialization);
            await _ctx.SaveChangesAsync();
        }
    }
}
