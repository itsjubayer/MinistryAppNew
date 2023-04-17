using MinistryApp.Models;
using MinistryApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MinistryApp.Seeds
{
    public static class DefaultUsers
    {
        //public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    var defaultUser = new ApplicationUser
        //    {
        //        UserName = "client@gmail.com",
        //        Email = "client@gmail.com",
        //        Country="Bangladesh",
        //        WorkFor="TTZ",
        //        IsActive=true,
        //        EmailConfirmed = true
        //    };
        //    if (userManager.Users.All(u => u.Id != defaultUser.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(defaultUser, "111111");
        //            await userManager.AddToRoleAsync(defaultUser, Roles.Client.ToString());
        //        }
        //    }


        //    var defaultUser2 = new ApplicationUser
        //    {
        //        UserName = "resource@gmail.com",
        //        Email = "resource@gmail.com",
        //        WorkFor = "TTZ",
        //        IsActive =true,
        //        Country = "Bangladesh",
        //        EmailConfirmed = true
        //    };
        //    if (userManager.Users.All(u => u.Id != defaultUser2.Id))
        //    {
        //        var user = await userManager.FindByEmailAsync(defaultUser2.Email);
        //        if (user == null)
        //        {
        //            await userManager.CreateAsync(defaultUser2, "111111");
        //            await userManager.AddToRoleAsync(defaultUser2, Roles.Resource.ToString());
        //        }
        //    }

        //}

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultAdminUser = new ApplicationUser
            {
                UserName = "admin@ttz.com",
                Email = "admin@ttz.com",
                FirstName = "TTZ",
                LastName = "TTZ",
                UserRole= "Supervisor",
                ProfilePicture = "no_image.png",
                Mobile="01686780827",
                IsActive =true,
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultAdminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultAdminUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultAdminUser, "111111");
                    await userManager.AddToRoleAsync(defaultAdminUser, EnumRoleLists.Admin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }
        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Products");
        }
        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            
        }


    }
}
