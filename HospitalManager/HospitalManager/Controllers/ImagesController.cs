using HospitalManager.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IDoctorsService _doctorsService;
        public ImagesController(
            IWebHostEnvironment appEnvironment,
            IDoctorsService doctorsService)
        {
            _appEnvironment = appEnvironment;
            _doctorsService = doctorsService;
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<string> AddPhoto([FromForm] IFormFile image, int id)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName);
                var imagePath = $"{Guid.NewGuid()}{fileExtension}";

                await _doctorsService.UpdatePathToPhotoAsync(id, imagePath);

                using var readStream = image.OpenReadStream();
                var buffer = new byte[image.Length];
                await readStream.ReadAsync(buffer, 0, buffer.Length);
                await System.IO.File.WriteAllBytesAsync(imagePath, buffer);

                return imagePath;
            }

            return "";
        }
    }
}
