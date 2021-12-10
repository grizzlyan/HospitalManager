﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PathToPhoto { get; set; }

        public string UserId { get; set; }

        public int SpecializationId { get; set; }
        public SpecializationModel Specialization { get; set; }
    }
}
