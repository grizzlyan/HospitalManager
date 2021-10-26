using AutoMapper;
using HospitalManager.Data.Entities;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //PL

            CreateMap<DoctorViewModel, DoctorModel>();
            CreateMap<MedicalProfessionViewModel, MedicalProfessionModel>();
            CreateMap<PatientViewModel, PatientModel>();
            CreateMap<DoctorModel, DoctorViewModel>();
            CreateMap<MedicalProfessionModel, MedicalProfessionViewModel>();
            CreateMap<PatientModel, PatientViewModel>();

            //BL

            CreateMap<DoctorModel, Doctor>();
            CreateMap<MedicalProfessionModel, MedicalProfession>();
            CreateMap<PatientModel, Patient>();
            CreateMap<Doctor, DoctorModel>();
            CreateMap<MedicalProfession, MedicalProfessionModel>();
            CreateMap<Patient, PatientModel>();
        }
    }
}
