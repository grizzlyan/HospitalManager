using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<AppointmentViewModel> Create(AppointmentPostModel model)
        {
            var createModel = _mapper.Map<AppointmentModel>(model);

            var createdModel = await _appointmentsService.CreateAsync(createModel);

            return _mapper.Map<AppointmentViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Patient")]
        public async Task<AppointmentViewModel> GetById(int id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);

            return _mapper.Map<AppointmentViewModel>(appointment);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Doctor")]
        public async Task<IEnumerable<AppointmentViewModel>> GetByDoctorId(int id)
        {
            var appointments = await _appointmentsService.GetAllByDoctorIdAsync(id);

            var resultAppointments = new List<AppointmentViewModel>();

            foreach (var item in appointments)
            {
                var appointment = _mapper.Map<AppointmentViewModel>(item);
                resultAppointments.Add(appointment);
            }

            return resultAppointments;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<AppointmentViewModel>> Get()
        {
            var appointments = await _appointmentsService.GetAllAsync();

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
        [Authorize]
        public async Task Delete(int id)
        {
            await _appointmentsService.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task Update(AppointmentPostModel model)
        {
            var appointment = _mapper.Map<AppointmentModel>(model);
            await _appointmentsService.UpdateAsync(appointment);
        }
    }
}
