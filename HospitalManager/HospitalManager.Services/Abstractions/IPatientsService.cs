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
        public Task<PatientModel> CreateAsync(PatientModel model);
        public Task UpdateAsync(PatientModel model);
        public Task<PatientModel> GetByIdAsync(int id);
        public Task<List<PatientModel>> GetAllAsync();
        public Task DeleteAsync(int id);
    }
}
