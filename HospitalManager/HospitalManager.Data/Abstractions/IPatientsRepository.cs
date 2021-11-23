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
        Task CreateAsync(Patient model);

        Task<Patient> GetByIdAsync(int id);

        Task<IEnumerable<Patient>> GetAllAsync();

        Task UpdateAsync(Patient model);

        Task DeleteAsync(int id);
    }
}
