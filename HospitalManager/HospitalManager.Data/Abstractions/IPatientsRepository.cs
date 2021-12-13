using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IPatientsRepository
    {
        Task<Patient> CreateAsync(Patient model);

        Task<IEnumerable<Patient>> GetAllAsync();

        Task<Patient> GetByIdAsync(int id);

        Task<Patient> GetByUserIdAsync(string id);

        Task UpdateAsync(Patient model, int id);

        Task DeleteAsync(int id);
    }
}
