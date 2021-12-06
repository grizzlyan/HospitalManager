using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Models.PostModels
{
    public class DoctorPostModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PathToPhoto { get; set; }

        public int SpecializationId { get; set; }

        public string UserID { get; set; }
    }
}
