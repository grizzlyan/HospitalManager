using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IMedicalProfessionRepository
    {
        Task Create(MedicalProfession model);
        Task<MedicalProfession> Get(int id);
        Task Update(MedicalProfession model);
        Task Delete(int id);
    }
}
