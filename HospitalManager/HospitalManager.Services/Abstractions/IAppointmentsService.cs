using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IAppointmentsService
    {
        Task<AppointmentModel> CreateAsync(AppointmentModel model);

        Task<IEnumerable<AppointmentModel>> GetAllAsync();

        Task<IEnumerable<AppointmentModel>> GetAppointmentsByDoctorIdAsync(int doctorId);

        Task<IEnumerable<AppointmentModel>> GetAppointmentsByPatientIdAsync(int patientId);

        Task<AppointmentModel> GetByIdAsync(int id);

        Task UpdateAsync(AppointmentModel model, int id);

        Task DeleteAsync(int id); 
    }
}
