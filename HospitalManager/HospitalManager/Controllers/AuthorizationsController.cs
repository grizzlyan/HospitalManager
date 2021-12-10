using HospitalManager.Configuration;
using HospitalManager.Data;
using HospitalManager.Data.Entities;
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
        private readonly ApplicationDbContext _ctx;

        public AuthorizationsController(
            IOptions<JwtBearerTokenSettings> jwtTokenOptions,
            UserManager<User> userManager,
            ApplicationDbContext ctx)
        {
            _jwtBearerTokenSettings = jwtTokenOptions.Value;
            _userManager = userManager;
            _ctx = ctx;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserDoctorDetails userDetails)
        {
            if (!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new { Message = "User Registration Failed" });
            }

            var identityUser = new User() { UserName = userDetails.Username, Email = userDetails.Email };
            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (var error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
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

            //var b = _userManager.Users.Include(x => x.Patients).First(x => x.Id == userId);
            //var c = b.Patients.First(x => x.UserId == userId);
            //var id = identityUser.Patients.First().Id;

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

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            return Ok(new { Token = "", Message = "Logged Out" });
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

                Expires = DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
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
