using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IDoctorsRepository
    {
        Task Create(Doctor model);
        Task<Doctor> Get(int id);
        Task<IEnumerable<Doctor>> GetAll();
        Task Update(Doctor model);
        Task Delete(int id);
    }
}
