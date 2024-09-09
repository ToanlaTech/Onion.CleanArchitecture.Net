using Microsoft.AspNetCore.Identity;
using Onion.CleanArchitecture.Net.CoreWorker.Contexts;
using Onion.CleanArchitecture.Net.CoreWorker.Models;

namespace Onion.CleanArchitecture.Net.CoreWorker.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task AddUserRangeAsync(this UserManager<ApplicationUser> userManager, IdentityContext identityContext, List<ApplicationUser> users)
        {
            await identityContext.Users.AddRangeAsync(users);
            await identityContext.SaveChangesAsync();
        }

        public static async Task UpdateUserRangeAsync(this UserManager<ApplicationUser> userManager, IdentityContext identityContext, List<ApplicationUser> users)
        {
            identityContext.Users.UpdateRange(users);
            await identityContext.SaveChangesAsync();
        }
    }
}
