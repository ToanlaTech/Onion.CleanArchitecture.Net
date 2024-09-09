using Onion.CleanArchitecture.Net.Application.Filters;
using System.Collections.Generic;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Users.Queries.GetPagingUser
{
    public class GetPagingUserParameter : RequestParameter
    {
        public List<string> id { get; set; }
    }
}
