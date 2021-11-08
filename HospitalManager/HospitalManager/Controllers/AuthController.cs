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
    public class AuthController : ControllerBase
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _ctx;

        public AuthController(
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
        public async Task<IActionResult> Register([FromBody] UserDetails userDetails)
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
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            User identityUser;

            if (!ModelState.IsValid
                || credentials == null
                || (identityUser = await ValidateUser(credentials)) == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var token = GenerateToken(identityUser);

            return Ok(
                new
                {
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    Username = "FIRST_NAME",
                    Roles = new[] { "ROLE_ADMIN", "ROLE_MODERATOR" },
                    Id = Guid.NewGuid().ToString()
                });
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(new { Token = "", Message = "Logged Out" });
        }

        [HttpPost]
        [Route("refreshtoken")]
        public AccessAndRefreshToken RefreshToken(string refreshToken)
        {
            SecurityToken validatedToken = null;
            var validationParameters = new TokenValidationParameters();
            var principal = new JwtSecurityTokenHandler().ValidateToken(refreshToken, validationParameters, out validatedToken);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _ctx.Users.Find(userId);

            var token = GenerateToken(user);

            return token;
        }


        private async Task<User> ValidateUser(LoginCredentials credentials)
        {
            var identityUser = await _userManager.FindByNameAsync(credentials.Username);
            var users = await _userManager.Users.ToListAsync();

            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }

            return null;
        }


        private AccessAndRefreshToken GenerateToken(IdentityUser identityUser)
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
                }),

                Expires = DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwtBearerTokenSettings.Audience,
                Issuer = _jwtBearerTokenSettings.Issuer
            };

            var refreshTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, identityUser.Id),
                }),

                Expires = DateTime.UtcNow.AddHours(_jwtBearerTokenSettings.RefreshTokenExpiryTimeHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var refreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshTokenValue = tokenHandler.WriteToken(refreshToken);

            _ctx.Tokens.Add(new RefreshToken
            {
                Value = refreshTokenValue,
                UserId = identityUser.Id
            });

            return new AccessAndRefreshToken
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshTokenValue
            };

        }
    }
}
