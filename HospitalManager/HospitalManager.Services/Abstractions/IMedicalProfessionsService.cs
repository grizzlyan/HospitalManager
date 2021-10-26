using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IMedicalProfessionsService
    {
        public Task<MedicalProfessionModel> Create(MedicalProfessionModel model);
        public Task Update(MedicalProfessionModel model);
        public Task<MedicalProfessionModel> Get(int id);
        public Task<List<MedicalProfessionModel>> GetAll();
        public Task Delete(int id);
    }
}
