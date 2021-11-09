using AutoMapper;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorsService doctorsService, IMapper mapper)
        {
            _doctorsService = doctorsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<DoctorViewModel> Create(DoctorViewModel model)
        {
            var createModel = _mapper.Map<DoctorModel>(model);

            var createdModel = await _doctorsService.Create(createModel);

            return _mapper.Map<DoctorViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DoctorViewModel> GetById(int id)
        {
            var doctor = await _doctorsService.Get(id);

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        [HttpGet]
        public async Task<IEnumerable<DoctorViewModel>> Get()
        {
            var doctors = await _doctorsService.GetAll();

            var resultDoctors = new List<DoctorViewModel>();

            foreach (var item in doctors)
            {
                var doctor = _mapper.Map<DoctorViewModel>(item);
                resultDoctors.Add(doctor);
            }

            return resultDoctors;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _doctorsService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Doctor")]
        public async Task Update (DoctorViewModel model)
        {
            var doctor = _mapper.Map<DoctorModel>(model);
            await _doctorsService.Update(doctor);
        }
    }
}
