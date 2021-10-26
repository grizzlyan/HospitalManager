using AutoMapper;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientsService patientsService, IMapper mapper)
        {
            _patientsService = patientsService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<PatientViewModel> Create(PatientViewModel model)
        {
            var createModel = _mapper.Map<PatientModel>(model);

            var createdModel = await _patientsService.Create(createModel);

            return _mapper.Map<PatientViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PatientViewModel> GetById(int id)
        {
            var patient = await _patientsService.Get(id);

            return _mapper.Map<PatientViewModel>(patient);
        }

        [HttpGet]
        public async Task<IEnumerable<PatientViewModel>> Get()
        {
            var patients = await _patientsService.GetAll();

            var resultPatients = new List<PatientViewModel>();

            foreach (var item in patients)
            {
                var patient = _mapper.Map<PatientViewModel>(item);
                resultPatients.Add(patient);
            }

            return resultPatients;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            await _patientsService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task Update(PatientViewModel model)
        {
            var patient = _mapper.Map<PatientModel>(model);
            await _patientsService.Update(patient);
        }
    }
}
