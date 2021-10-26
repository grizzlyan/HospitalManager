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
        public Task<PatientModel> Create(PatientModel model);
        public Task Update(PatientModel model);
        public Task<PatientModel> Get(int id);
        public Task<List<PatientModel>> GetAll();
        public Task Delete(int id);
    }
}
