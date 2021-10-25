using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DoctorsController> Get()
        {
            return null;
        }
    }
}
