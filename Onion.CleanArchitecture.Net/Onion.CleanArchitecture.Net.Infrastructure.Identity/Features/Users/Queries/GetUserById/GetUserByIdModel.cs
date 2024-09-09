using Onion.CleanArchitecture.Net.Infrastructure.Identity.Models;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Users.Queries.GetUserById
{
    public class GetUserByIdModel : ApplicationUser
    {
        public UserAvatarClaim Avatar { get; set; }
    }
}
