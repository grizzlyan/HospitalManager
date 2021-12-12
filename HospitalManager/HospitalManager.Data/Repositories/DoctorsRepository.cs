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
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly ApplicationDbContext _ctx;

        public DoctorsRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Doctor> CreateAsync(Doctor model)
        {
            _ctx.Doctors.Add(model);
            await _ctx.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _ctx.Doctors
                .Include(x => x.Specialization)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllBySpecializationIdAsync(int id)
        {
            return await _ctx.Doctors.Where(x => x.SpecializationId == id).ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetPaginationDoctors(
            PaginationFilters<Doctor> paginationFilters,
            SortFilter<Doctor> sortFilter,
            PagePagination pagePagination)
        {
            var result = _ctx
                .Doctors
                .Include(x=>x.Specialization)
                .AsNoTracking();

            if (paginationFilters != null)
            {
                foreach (var predicate in paginationFilters.FilterPredicates)
                {
                    result = result.Where(predicate);
                }
            }

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

            var paginationDoctors = await result
                .Skip((pagePagination.Page - 1) * pagePagination.PageSize)
                .Take(pagePagination.PageSize)
                .ToListAsync();

            return paginationDoctors;
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _ctx.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> GetByUserIdAsync(string id)
        {
            return await _ctx.Doctors.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<int> GetCountDoctorsAsync()
        {
            var count = await _ctx.Doctors.CountAsync();
            return count;
        }

        public async Task UpdateAsync(Doctor model, int id)
        {
            var doctor = await _ctx.Doctors.FindAsync(id);
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.SpecializationId = model.SpecializationId;

            _ctx.Doctors.Update(doctor);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdatePathToPhotoAsync(int id, string pathToPhoto)
        {
            var doctor = await _ctx.Doctors.FindAsync(id);
            doctor.PathToPhoto = pathToPhoto;

            _ctx.Doctors.Update(doctor);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _ctx.Doctors.FindAsync(id);
            _ctx.Remove(doctor);
            await _ctx.SaveChangesAsync();
        }
    }
}
