using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.AuthModels
{
    public class AccessAndRefreshToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
