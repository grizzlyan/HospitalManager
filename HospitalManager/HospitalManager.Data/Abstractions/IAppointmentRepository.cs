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
        public Task<Appointment> CreateAsync(Appointment model);

        Task<bool> IsContainsAppointmentAsync(Appointment model);

        public Task DeleteAsync(int id);

        public Task<Appointment> GetByIdAsync(int id);

        Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId);

        Task<IEnumerable<Appointment>> GetAllByPatientIdAsync(int patientId);

        public Task<IEnumerable<Appointment>> GetAllAsync();

        public Task UpdateAsync(Appointment model);
    }
}
