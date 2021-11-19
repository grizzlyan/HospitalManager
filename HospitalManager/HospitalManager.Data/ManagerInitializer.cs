using HospitalManager.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManager.Data
{
    public static class ManagerInitializer
    {
        public static async Task SeedManagerAsync(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("manager@manager.com").Result == null)
            {
                var user = new User
                {
                    UserName = "Manager",
                    Email = "manager@manager.com"
                };

                var result = userManager.CreateAsync(user, "ManagerPassword").Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
