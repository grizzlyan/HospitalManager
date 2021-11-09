using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IAppointmentRepository
    {
        public Task Create(Appointment model);

        public Task Delete(int id);

        public Task<Appointment> Get(int id);

        public Task<IEnumerable<Appointment>> GetAll();

        public Task Update(Appointment model);
    }
}
