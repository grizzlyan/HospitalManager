﻿using HospitalManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data.Abstractions
{
    public interface IDoctorRepository
    {
        Task Create(Doctor model);
        Task<Doctor> Get(int id);
        Task Update(Doctor model);
        Task Delete(int id);
    }
}