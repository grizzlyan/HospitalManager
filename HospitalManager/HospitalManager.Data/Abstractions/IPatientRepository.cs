using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IPatientRepository
    {
        Task Create(Patient model);
        Task<Patient> Get(int id);
        Task<IEnumerable<Patient>> GetAll();
        Task Update(Patient model);
        Task Delete(int id);
    }
}
