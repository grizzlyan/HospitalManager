using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Services.Models.AuthModels
{
    public class UserDetails
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PathToPhoto { get; set; }

        [Required]
        public int SpecializationId { get; set; }

        public RolesEnum Role { get; set; }
    }
}
