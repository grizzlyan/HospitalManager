using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;
        private readonly IMapper _mapper;
        private readonly ModelListMapper<AppointmentViewModel, AppointmentModel> _modelListMapper;

        public AppointmentsController(IAppointmentsService appointmentsService, IMapper mapper)
        {
            _appointmentsService = appointmentsService;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<AppointmentViewModel, AppointmentModel>(_mapper);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<AppointmentViewModel> Create(AppointmentPostModel model)
        {
            var createModel = _mapper.Map<AppointmentModel>(model);

            var createdModel = await _appointmentsService.CreateAsync(createModel);

            return _mapper.Map<AppointmentViewModel>(createdModel);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<AppointmentViewModel>> Get()
        {
            var appointments = await _appointmentsService.GetAllAsync();

            var resultAppointments = _modelListMapper.MapModelList(appointments);

            return resultAppointments;
        }

        [HttpGet]
        [Route("appointmentsByDoctorId/{doctorId}")]
        [Authorize(Roles = "Manager, Doctor")]
        public async Task<IEnumerable<AppointmentViewModel>> GetByDoctorId(int doctorId)
        {
            var appointments = await _appointmentsService.GetAppointmentsByDoctorIdAsync(doctorId);

            var resultAppointments = _modelListMapper.MapModelList(appointments);

            return resultAppointments;
        }

        [HttpGet]
        [Route("appointmentsByPatientId/{patientId}")]
        [Authorize(Roles = "Manager, Patient")]
        public async Task<IEnumerable<AppointmentViewModel>> GetByPatientId(int patientId)
        {
            var appointments = await _appointmentsService.GetAppointmentsByPatientIdAsync(patientId);

            var resultAppointments = _modelListMapper.MapModelList(appointments);

            return resultAppointments;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<AppointmentViewModel> GetById(int id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);

            return _mapper.Map<AppointmentViewModel>(appointment);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task Update(AppointmentViewModel model, int id)
        {
            var appointment = _mapper.Map<AppointmentModel>(model);
            await _appointmentsService.UpdateAsync(appointment, id);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Patient")]
        public async Task Delete(int id)
        {
            await _appointmentsService.DeleteAsync(id);
        }
    }
}
