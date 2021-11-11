using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IMedicalProfessionsRepository
    {
        Task CreateAsync(MedicalProfession model);
        Task<MedicalProfession> GetByIdAsync(int id);
        Task<IEnumerable<MedicalProfession>> GetAllAsync();
        Task UpdateAsync(MedicalProfession model);
        Task DeleteAsync(int id);
    }
}
