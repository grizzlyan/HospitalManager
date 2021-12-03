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
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationsService _specializationsService;
        private readonly IMapper _mapper;

        public SpecializationsController(ISpecializationsService specializationsService, IMapper mapper)
        {
            _specializationsService = specializationsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<SpecializationViewModel> Create(SpecializationPostModel model)
        {
            var createModel = _mapper.Map<SpecializationModel>(model);

            var createdModel = await _specializationsService.CreateAsync(createModel);

            return _mapper.Map<SpecializationViewModel>(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<SpecializationViewModel> GetById(int id)
        {
            var specialization = await _specializationsService.GetByIdAsync(id);

            return _mapper.Map<SpecializationViewModel>(specialization);
        }

        /*[HttpGet]
        public async Task<IEnumerable<SpecializationViewModel>> Get()
        {
            var specializations = await _specializationsService.GetAllAsync();

            var resultSpecializations = new List<SpecializationViewModel>();

            foreach (var item in specializations)
            {
                var specialization = _mapper.Map<SpecializationViewModel>(item);
                resultSpecializations.Add(specialization);
            }

            return resultSpecializations;
        }*/

        [HttpGet]
        public async Task<PaginationViewModel<SpecializationViewModel>> GetPaginationSpecializations(
            [FromQuery] SortFilterParametres<SortSpecializationFieldEnum> sortFilterParametres,
            [FromQuery] PagePaginationPostModel pagePagination)
        {
            var sortFilter = _mapper.Map<SortFilterModel<SortSpecializationFieldEnum>>(sortFilterParametres);
            var pagePaginationModel = _mapper.Map<PagePaginationModel>(pagePagination);

            var specializationsPaginationModel = await _specializationsService.GetPaginationSpecializationsAsync(sortFilter, pagePaginationModel);

            var specializationList = new List<SpecializationViewModel>();

            foreach (var item in specializationsPaginationModel.Data)
            {
                var specialization = _mapper.Map<SpecializationViewModel>(item);
                specializationList.Add(specialization);
            }

            var specializationsData = new PaginationViewModel<SpecializationViewModel>
            {
                Data = specializationList,
                TotalCount = specializationsPaginationModel.TotalCount
            };

            return specializationsData;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Delete(int id)
        {
            await _specializationsService.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task Update(SpecializationPostModel model)
        {
            var specialization = _mapper.Map<SpecializationModel>(model);
            await _specializationsService.UpdateAsync(specialization);
        }
    }
}
