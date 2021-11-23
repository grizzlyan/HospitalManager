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
        public Task CreateAsync(Appointment model);

        public Task DeleteAsync(int id);

        public Task<Appointment> GetByIdAsync(int id);

        Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId);

        public Task<IEnumerable<Appointment>> GetAllAsync();

        public Task UpdateAsync(Appointment model);
    }
}
