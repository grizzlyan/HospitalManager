using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IDoctorsService
    {
        public Task<DoctorModel> Create(DoctorModel model);
        public Task Update(DoctorModel model);
        public Task<DoctorModel> Get(int id);
        public Task<List<DoctorModel>> GetAll();
        public Task Delete(int id);
    }
}
