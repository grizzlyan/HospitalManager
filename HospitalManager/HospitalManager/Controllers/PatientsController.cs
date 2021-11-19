﻿using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Extensions;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
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
    [Route("[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsService _patientsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PatientsController(
            IPatientsService patientsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _patientsService = patientsService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create(PatientPostModel model, UserDetails userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new User() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            userDetails.Role = RolesEnum.Patient;

            var roleName = userDetails.Role.GetEnumDescription();

            await _userManager.AddToRoleAsync(identityUser, roleName);

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (var error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            var createModel = _mapper.Map<PatientModel>(model);

            var createdModel = await _patientsService.CreateAsync(createModel);

            return Ok(new { Message = "User Reigstration Successful" });

            //return _mapper.Map<PatientViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Manager, Doctor")]
        public async Task<PatientViewModel> GetById(int id)
        {
            var patient = await _patientsService.GetByIdAsync(id);

            return _mapper.Map<PatientViewModel>(patient);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IEnumerable<PatientViewModel>> Get()
        {
            var patients = await _patientsService.GetAllAsync();

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
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _patientsService.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Patient")]
        public async Task Update(PatientPostModel model)
        {
            var patient = _mapper.Map<PatientModel>(model);
            await _patientsService.UpdateAsync(patient);
        }
    }
}
