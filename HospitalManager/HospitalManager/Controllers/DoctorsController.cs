using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Extensions;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private readonly UserManager<User> _userManager;

        public DoctorsController(
            IDoctorsService doctorsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _doctorsService = doctorsService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(DoctorViewModel model, UserDetails userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new User() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            userDetails.Role = RolesEnum.Doctor;

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

            var createModel = _mapper.Map<DoctorModel>(model);

            var createdModel = await _doctorsService.Create(createModel);

            return Ok(new { Message = "User Reigstration Successful" });

            //return _mapper.Map<DoctorViewModel>(createdModel);
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
