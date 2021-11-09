using AutoMapper;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class MedicalProfessionsController : ControllerBase
    {
        private readonly IMedicalProfessionsService _medicalProfessionsService;
        private readonly IMapper _mapper;

        public MedicalProfessionsController(IMedicalProfessionsService medicalProfessionsService, IMapper mapper)
        {
            _medicalProfessionsService = medicalProfessionsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<MedicalProfessionViewModel> Create(MedicalProfessionViewModel model)
        {
            var createModel = _mapper.Map<MedicalProfessionModel>(model);

            var createdModel = await _medicalProfessionsService.Create(createModel);

            return _mapper.Map<MedicalProfessionViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MedicalProfessionViewModel> GetById(int id)
        {
            var medicalProfession = await _medicalProfessionsService.Get(id);

            return _mapper.Map<MedicalProfessionViewModel>(medicalProfession);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalProfessionViewModel>> Get()
        {
            var medicalProfessions = await _medicalProfessionsService.GetAll();

            var resultMedicalProfessions = new List<MedicalProfessionViewModel>();

            foreach (var item in medicalProfessions)
            {
                var doctor = _mapper.Map<MedicalProfessionViewModel>(item);
                resultMedicalProfessions.Add(doctor);
            }

            return resultMedicalProfessions;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _medicalProfessionsService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Update(MedicalProfessionViewModel model)
        {
            var medicalProfession = _mapper.Map<MedicalProfessionModel>(model);
            await _medicalProfessionsService.Update(medicalProfession);
        }
    }
}
