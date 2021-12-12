using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IPatientsService
    {
        Task<PatientModel> CreateAsync(PatientModel model);

        Task<IEnumerable<PatientModel>> GetAllAsync();

        Task<PatientModel> GetByIdAsync(int id);

        Task<PatientModel> GetByUserIdAsync(string id);

        Task UpdateAsync(PatientModel model);

        Task DeleteAsync(int id);
    }
}
