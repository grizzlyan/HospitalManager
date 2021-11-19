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
        private readonly HospitalManagerContext _ctx;

        public DoctorsRepository(HospitalManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Doctor model)
        {
            _ctx.Doctors.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _ctx.Doctors.FindAsync(id);
            _ctx.Remove(doctor);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _ctx.Doctors
            .Include(x => x.MedicalProfession)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _ctx.Doctors
            .Include(x => x.MedicalProfession)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task UpdateAsync(Doctor model)
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

        public async Task<IEnumerable<Doctor>> GetPaginationDoctors(
            PaginationFilters<Doctor> paginationFilters,
            SortFilter<Doctor> sortFilter,
            PagePagination pagePagination)
        {
            var result = _ctx
                .Doctors
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
                if(sortFilter.IsAscending)
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

        public async Task<int> GetCountDoctorsAsync()
        {
            var count = await _ctx.Doctors.CountAsync();
            return count;
        }
    }
}
