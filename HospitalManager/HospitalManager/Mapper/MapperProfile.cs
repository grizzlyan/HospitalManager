using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Data.Entities.Pagination;
using HospitalManager.Models.PaginationsModels;
using HospitalManager.Models.PostModels;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Models;
using HospitalManager.Services.Models.Pagination;
using HospitalManager.Services.Models.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HospitalManager.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //PL

            CreateMap<DoctorPostModel, DoctorModel>();
            CreateMap<DoctorModel, DoctorViewModel>();

            CreateMap<MedicalProfessionPostModel, MedicalProfessionModel>();
            CreateMap<MedicalProfessionModel, MedicalProfessionViewModel>();

            CreateMap<PatientPostModel, PatientModel>();
            CreateMap<PatientModel, PatientViewModel>();

            CreateMap<AppointmentPostModel, AppointmentModel>();
            CreateMap<AppointmentModel, AppointmentViewModel>();
            
            CreateMap<DoctorFilterFieldsParametres, DoctorFilterFieldsModel>();
            CreateMap<DoctorFilterFieldsModel, DoctorFilterFieldsParametres>();

            CreateMap<SortFilterParametres<SortDoctorFieldEnum>, SortFilterModel<SortDoctorFieldEnum>>();
            CreateMap<SortFilterModel<SortDoctorFieldEnum>, SortFilterParametres<SortDoctorFieldEnum>>();

            CreateMap<SortFilterParametres<SortMedicalProffessionFieldEnum>, SortFilterModel<SortMedicalProffessionFieldEnum>>();
            CreateMap<SortFilterModel<SortMedicalProffessionFieldEnum>, SortFilterParametres<SortMedicalProffessionFieldEnum>>();

            CreateMap<PagePaginationPostModel, PagePaginationModel>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = dest ?? new PagePaginationModel();

                    dest.Page = src.Page.HasValue ? src.Page.Value : 1;
                    dest.PageSize = src.PageSize.HasValue ? src.PageSize.Value : 3;

                    return dest;
                });

            //BL

            CreateMap<DoctorModel, Doctor>();
            CreateMap<Doctor, DoctorModel>();

            CreateMap<MedicalProfessionModel, MedicalProfession>();
            CreateMap<MedicalProfession, MedicalProfessionModel>();

            CreateMap<PatientModel, Patient>();
            CreateMap<Patient, PatientModel>();

            CreateMap<Appointment, AppointmentModel>();
            CreateMap<AppointmentModel, Appointment>();

            CreateMap<PagePaginationModel, PagePagination>();
            CreateMap<PagePagination, PagePaginationModel>();

            CreateMap<DoctorFilterFieldsModel, PaginationFilters<Doctor>>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    dest = dest ?? new PaginationFilters<Doctor>();

                    dest.FilterPredicates = new List<Expression<Func<Doctor, bool>>>();

                    if (src.MedicalProffessionId.HasValue)
                    {
                        switch (src.FilterDoctorField)
                        {
                            case FilterDoctorFieldEnum.MedicalProffession:
                                dest.FilterPredicates.Add(x => x.MedicalProfessionId == src.MedicalProffessionId);
                                break;
                            default:
                                break;
                        }
                    }

                    if (dest.FilterPredicates.Count == 0)
                    {
                        return null;
                    }

                    return dest;
                });

            CreateMap<SortFilterModel<SortDoctorFieldEnum>, SortFilter<Doctor>>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    if (!src.SortField.HasValue)
                    {
                        return null;
                    }

                    dest = dest ?? new SortFilter<Doctor>();

                    if (src.SortField.HasValue)
                    {
                        switch (src.SortField)
                        {
                            case SortDoctorFieldEnum.LastName:
                                dest.SortPredicate = x => x.LastName;
                                break;
                            case SortDoctorFieldEnum.FirstName:
                                dest.SortPredicate = x => x.FirstName;
                                break;
                            default:
                                break;
                        }
                    }

                    dest.IsAscending = src.SortDirection == SortDirectionEnum.Ascending;

                    return dest;
                });

            CreateMap<SortFilterModel<SortMedicalProffessionFieldEnum>, SortFilter<MedicalProfession>>()
                .ConvertUsing((src, dest, ctx) =>
                {
                    if (!src.SortField.HasValue)
                    {
                        return null;
                    }

                    dest = dest ?? new SortFilter<MedicalProfession>();

                    if (src.SortField.HasValue)
                    {
                        switch (src.SortField)
                        {
                            case SortMedicalProffessionFieldEnum.Name:
                                dest.SortPredicate = x => x.ProfessionName;
                                break;
                            default:
                                break;
                        }
                    }

                    dest.IsAscending = src.SortDirection == SortDirectionEnum.Ascending;

                    return dest;
                });
        }
    }
}
