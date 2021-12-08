using HospitalManager.Data.Entities;
using HospitalManager.Extensions;
using HospitalManager.Services.ConfigurationServices.Abstractions;
using HospitalManager.Services.Models.AuthModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManager.Services.ConfigurationServices
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await CreateRoles();
            await CreateAdmin();
        }

        private async Task CreateAdmin()
        {
            var roleName = RolesEnum.Manager.GetEnumDescription();
            var roleFromDb = await _roleManager.FindByNameAsync(roleName);

            if (roleFromDb != null)
            {
                var manager = new User()
                {
                    UserName = "Manager",
                    Email = "manager@manager.com"
                };

                var password = "ManagerPassword123#@";

                var existingManager = await _userManager.FindByNameAsync(manager.UserName);
                if (existingManager == null)
                {
                    await _userManager.CreateAsync(manager, password);
                    await _userManager.AddToRoleAsync(manager, roleName);
                }
            }
        }

        private async Task CreateRoles()
        {
            try
            {
                string[] rolesArray = { "Manager", "Doctor", "Patient" };
                foreach (var role in rolesArray)
                {
                    var findRole = await _roleManager.FindByNameAsync(role);
                    if (findRole == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
