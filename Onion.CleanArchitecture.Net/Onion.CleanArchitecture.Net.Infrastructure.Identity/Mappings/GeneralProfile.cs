using AutoMapper;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Users.Queries.GetPagingUser;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Users.Queries.GetUserById;
using Onion.CleanArchitecture.Net.Infrastructure.Identity.Models;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<ApplicationUser, GetPagingUserViewModel>().ReverseMap();
        CreateMap<ApplicationUser, GetUserByIdModel>().ReverseMap();
    }
}
