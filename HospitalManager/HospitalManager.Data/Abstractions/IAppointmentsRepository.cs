using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IAppointmentsRepository
    {
        Task<Appointment> CreateAsync(Appointment model);

        Task<IEnumerable<Appointment>> GetAllAsync();

        Task<IEnumerable<Appointment>> GetAllByDoctorIdAsync(int doctorId);

        Task<IEnumerable<Appointment>> GetAllByPatientIdAsync(int patientId);

        Task<Appointment> GetByIdAsync(int id);

        Task UpdateAsync(Appointment model);

        Task DeleteAsync(int id);      

        Task<bool> IsContainsAppointmentAsync(Appointment model);
    }
}
