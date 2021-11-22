using AutoMapper;
using HospitalManager.Models.PaginationsModels;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using HospitalManager.Services.Models.Pagination.Enums;
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
        public async Task<MedicalProfessionViewModel> Create(MedicalProfessionPostModel model)
        {
            var createModel = _mapper.Map<MedicalProfessionModel>(model);

            var createdModel = await _medicalProfessionsService.CreateAsync(createModel);

            return _mapper.Map<MedicalProfessionViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MedicalProfessionViewModel> GetById(int id)
        {
            var medicalProfession = await _medicalProfessionsService.GetByIdAsync(id);

            return _mapper.Map<MedicalProfessionViewModel>(medicalProfession);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalProfessionViewModel>> Get()
        {
            var medicalProfessions = await _medicalProfessionsService.GetAllAsync();

            var resultMedicalProfessions = new List<MedicalProfessionViewModel>();

            foreach (var item in medicalProfessions)
            {
                var doctor = _mapper.Map<MedicalProfessionViewModel>(item);
                resultMedicalProfessions.Add(doctor);
            }

            return resultMedicalProfessions;
        }

        [HttpGet]
        public async Task<PaginationViewModel<MedicalProfessionViewModel>> GetPaginationMedicalProffessions(
            [FromQuery] SortFilterParametres<SortMedicalProffessionFieldEnum> sortFilterParametres,
            [FromQuery] PagePaginationPostModel pagePagination)
        {
            var sortFilter = _mapper.Map<SortFilterModel<SortMedicalProffessionFieldEnum>>(sortFilterParametres);
            var pagePaginationModel = _mapper.Map<PagePaginationModel>(pagePagination);

            var medicalProffessionsPaginationModel = await _medicalProfessionsService.GetPaginationMadicalProffesionsAsync(sortFilter, pagePaginationModel);

            var medicalProffessionsList = new List<MedicalProfessionViewModel>();

            foreach (var item in medicalProffessionsPaginationModel.Data)
            {
                var medicalProffession = _mapper.Map<MedicalProfessionViewModel>(item);
                medicalProffessionsList.Add(medicalProffession);
            }

            var medicalProffessionsData = new PaginationViewModel<MedicalProfessionViewModel>
            {
                DoctorsData = medicalProffessionsList,
                TotalCount = medicalProffessionsPaginationModel.TotalCount
            };

            return medicalProffessionsData;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _medicalProfessionsService.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Update(MedicalProfessionPostModel model)
        {
            var medicalProfession = _mapper.Map<MedicalProfessionModel>(model);
            await _medicalProfessionsService.UpdateAsync(medicalProfession);
        }
    }
}
