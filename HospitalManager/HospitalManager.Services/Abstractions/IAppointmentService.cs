using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Abstractions
{
    public interface IAppointmentService
    {
        public Task<AppointmentModel> Create(AppointmentModel model);

        public Task Delete(int id);

        public Task<AppointmentModel> Get(int id);

        public Task<List<AppointmentModel>> GetAll();

        public Task Update(AppointmentModel model);
    }
}
