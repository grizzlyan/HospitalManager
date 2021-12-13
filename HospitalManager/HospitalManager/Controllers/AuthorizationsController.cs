using AutoMapper;
using HospitalManager.Configuration;
using HospitalManager.Data;
using HospitalManager.Data.Entities;
using HospitalManager.Models.ViewModels;
using HospitalManager.Services.Abstractions;
using HospitalManager.Services.Models.AuthModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : ControllerBase
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<User> _userManager;
        private readonly IPatientsService _patientsService;
        private readonly IDoctorsService _doctorsService;



        public AuthorizationsController(
            IOptions<JwtBearerTokenSettings> jwtTokenOptions,
            UserManager<User> userManager,
            IPatientsService patientsService,
            IDoctorsService doctorsService
           )
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _userManager = userManager;
            _patientsService = patientsService;
            _doctorsService = doctorsService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCredentials credentials)
        {
            User identityUser;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUserAsync(credentials)) == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }


            var roles = await _userManager.GetRolesAsync(identityUser);
            var role = roles.First();

            var token = GenerateToken(identityUser, role);

            var id = 0;
            var fullName = string.Empty;

            if (role.Equals("Patient"))
            {
                var patient = await _patientsService.GetByUserIdAsync(identityUser.Id);
                id = patient.Id;
                fullName = $"{patient.FirstName} {patient.LastName}";
            }

            else if (role == "Doctor")
            {
                var doctor = await _doctorsService.GetByUserIdAsync(identityUser.Id);
                id = doctor.Id;
                fullName = $"{doctor.FirstName} {doctor.LastName}";
            }

            else if (role == "Manager")
            {
                return Ok(

                    new
                    {
                        AccessToken = token.Token,
                        UserName = identityUser.UserName,
                        Role = role,
                        UserId = identityUser.Id,
                        IsLoggedIn = true
                    });
            }

            return Ok(
                new
                {
                    AccessToken = token.Token,
                    UserName = identityUser.UserName,
                    Role = role,
                    UserId = identityUser.Id,
                    Id = id,
                    FullName = fullName,
                    IsLoggedIn = true
                });
        }

        private async Task<User> ValidateUserAsync(LoginCredentials credentials)
        {
            var identityUser = await _userManager.FindByNameAsync(credentials.UserName);

            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(
                    identityUser,
                    identityUser.PasswordHash,
                    credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }


        private AccessToken GenerateToken(IdentityUser identityUser, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, identityUser.Email),
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                    new Claim(ClaimTypes.Role, role)
                }),

                Expires = DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.ExpiryTimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AccessToken
            {
                Token = tokenHandler.WriteToken(token),
            };

        }
    }
}
