using Microsoft.AspNetCore.Identity;
using Onion.CleanArchitecture.Net.Application.Enums;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Models;
using System.Threading.Tasks;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
