using Onion.CleanArchitecture.Net.Application.Interfaces;
using System.Security.Claims;

namespace Onion.CleanArchitecture.Net.WebApp.Server.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}
