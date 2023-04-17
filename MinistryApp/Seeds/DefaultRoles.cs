using MinistryApp.Models;
using MinistryApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(EnumRoleLists.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(EnumRoleLists.Supervisor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(EnumRoleLists.Chamber.ToString()));
        }
    }
}
