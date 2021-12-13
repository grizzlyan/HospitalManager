﻿using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Extensions;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ModelListMapper<PatientViewModel, PatientModel> _modelListMapper;

        public PatientsController(
            IPatientsService patientsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _patientsService = patientsService;
            _userManager = userManager;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<PatientViewModel, PatientModel>(_mapper);
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserPatientDetails userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new User() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (var error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            var roleName = RolesEnum.Patient.GetEnumDescription();

            await _userManager.AddToRoleAsync(identityUser, roleName);

            var userId = await _userManager.GetUserIdAsync(identityUser);

            var model = new PatientPostModel
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                City = userDetails.City,
                UserId = userId
            };

            var createModel = _mapper.Map<PatientModel>(model);

            var createdModel = await _patientsService.CreateAsync(createModel);

            var patient = _mapper.Map<PatientViewModel>(createdModel);

            return Ok(new { Message = "User Reigstration Successful", Patient = patient });
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<PatientViewModel>> Get()
        {
            var patients = await _patientsService.GetAllAsync();

            var resultPatients = _modelListMapper.MapModelList(patients);

            return resultPatients;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Patient")]
        public async Task<PatientViewModel> GetById(int id)
        {
            var patient = await _patientsService.GetByIdAsync(id);

            return _mapper.Map<PatientViewModel>(patient);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Patient")]
        public async Task Update(PatientViewModel model, int id)
        {
            var patient = _mapper.Map<PatientModel>(model);
            await _patientsService.UpdateAsync(patient, id);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _patientsService.DeleteAsync(id);
        }
    }
}
