using Onion.CleanArchitecture.Net.Application.Filters;
using System.Collections.Generic;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Features.Role.Queries.GetPagingRole
{
    public class GetPagingRoleParameter : RequestParameter
    {
        public List<string> id { get; set; }
    }
}
