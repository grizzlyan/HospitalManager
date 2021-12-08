using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PostModels
{
    public class PatientPostModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string UserId {get;set;}
    }
}
