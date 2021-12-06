using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Services.ConfigurationServices.Abstractions
{
    public interface IDbInitializer
    {
        Task Seed();
    }
}
