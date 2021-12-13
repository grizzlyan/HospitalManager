﻿using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Extensions;
using HospitalManager.Models.PaginationsModels;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Helpers;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.AuthModels;
using HospitalManager.Services.Models.Pagination;
using HospitalManager.Services.Models.Pagination.Enums;
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
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _doctorsService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ModelListMapper<DoctorViewModel, DoctorModel> _modelListMapper;

        public DoctorsController(
            IDoctorsService doctorsService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _doctorsService = doctorsService;
            _userManager = userManager;
            _mapper = mapper;
            _modelListMapper = new ModelListMapper<DoctorViewModel, DoctorModel>(_mapper);
        }

        [HttpPost]
        [Route("Register")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create(UserDoctorDetails userDetails)
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

            var roleName = RolesEnum.Doctor.GetEnumDescription();

            await _userManager.AddToRoleAsync(identityUser, roleName);

            var userId = await _userManager.GetUserIdAsync(identityUser);

            var model = new DoctorPostModel
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                SpecializationId = userDetails.SpecializationId,
                UserId = userId
            };

            var createModel = _mapper.Map<DoctorModel>(model);

            var createdModel = await _doctorsService.CreateAsync(createModel);

            var doctor = _mapper.Map<DoctorViewModel>(createdModel);

            return Ok(new { Message = "User Reigstration Successful", Doctor = doctor });
        }

        [HttpGet]
        [Route("paginGet")]
        public async Task<PaginationViewModel<DoctorViewModel>> GetPaginationDoctors(
            [FromQuery] DoctorFilterFieldsParametres doctorFilterFieldsParametres,
            [FromQuery] SortFilterParametres<SortDoctorFieldEnum> sortFilterParametres,
            [FromQuery] PagePaginationPostModel pagePagination)
        {
            var doctorFilter = _mapper.Map<DoctorFilterFieldsModel>(doctorFilterFieldsParametres);
            var sortFilter = _mapper.Map<SortFilterModel<SortDoctorFieldEnum>>(sortFilterParametres);
            var pagePaginationModel = _mapper.Map<PagePaginationModel>(pagePagination);

            var doctorsPaginationModel = await _doctorsService.GetPaginationsDoctorsAsync(
                doctorFilter,
                sortFilter,
                pagePaginationModel);

            var doctorsList = _modelListMapper.MapModelList(doctorsPaginationModel.Data);

            var doctorsData = new PaginationViewModel<DoctorViewModel>
            {
                Data = doctorsList,
                TotalCount = doctorsPaginationModel.TotalCount
            };

            return doctorsData;
        }

        [HttpGet]
        [Route("{specializationId}")]
        public async Task<IEnumerable<DoctorViewModel>> GetBySecializationId(int specializationId)
        {
            var doctors = await _doctorsService.GetAllBySpecializationIdAsync(specializationId);

            var resultDoctorsList = _modelListMapper.MapModelList(doctors);

            return resultDoctorsList;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<DoctorViewModel> GetById(int id)
        {
            var doctor = await _doctorsService.GetByIdAsync(id);

            return _mapper.Map<DoctorViewModel>(doctor);
        }

        [HttpGet]
        public async Task<IEnumerable<DoctorViewModel>> Get()
        {
            var doctors = await _doctorsService.GetAllAsync();

            var resultDoctorsList = _modelListMapper.MapModelList(doctors);

            return resultDoctorsList;
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Update(DoctorViewModel model, int id)
        {
            var doctor = _mapper.Map<DoctorModel>(model);
            await _doctorsService.UpdateAsync(doctor, id);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _doctorsService.DeleteAsync(id);
        }
    }
}
