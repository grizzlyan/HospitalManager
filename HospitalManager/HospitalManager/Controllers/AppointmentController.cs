using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentsService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentsService, IMapper mapper)
        {
            _appointmentsService = appointmentsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<AppointmentViewModel> Create(AppointmentViewModel model)
        {
            var createModel = _mapper.Map<AppointmentModel>(model);

            var createdModel = await _appointmentsService.Create(createModel);

            return _mapper.Map<AppointmentViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AppointmentViewModel> GetById(int id)
        {
            var appointment = await _appointmentsService.Get(id);

            return _mapper.Map<AppointmentViewModel>(appointment);
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentViewModel>> Get()
        {
            var appointments = await _appointmentsService.GetAll();

            var resultAppointments = new List<AppointmentViewModel>();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentViewModel>(item);
                resultAppointments.Add(appointment);
            }

            return resultAppointments;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            await _appointmentsService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task Update(AppointmentViewModel model)
        {
            var appointment = _mapper.Map<AppointmentModel>(model);
            await _appointmentsService.Update(appointment);
        }
    }
}
