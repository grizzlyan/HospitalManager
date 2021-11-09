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
            CreateMap<DoctorModel, DoctorViewModel>();
            CreateMap<MedicalProfessionViewModel, MedicalProfessionModel>();
            CreateMap<MedicalProfessionModel, MedicalProfessionViewModel>();
            CreateMap<PatientViewModel, PatientModel>();
            CreateMap<PatientModel, PatientViewModel>();
            CreateMap<AppointmentModel, AppointmentViewModel>();
            CreateMap<AppointmentViewModel, AppointmentModel>();

            //BL

            CreateMap<DoctorModel, Doctor>();
            CreateMap<Doctor, DoctorModel>();
            CreateMap<MedicalProfessionModel, MedicalProfession>();
            CreateMap<MedicalProfession, MedicalProfessionModel>();
            CreateMap<PatientModel, Patient>();
            CreateMap<Patient, PatientModel>();
            CreateMap<Appointment, AppointmentModel>();
            CreateMap<AppointmentModel, Appointment>();
        }
    }
}
