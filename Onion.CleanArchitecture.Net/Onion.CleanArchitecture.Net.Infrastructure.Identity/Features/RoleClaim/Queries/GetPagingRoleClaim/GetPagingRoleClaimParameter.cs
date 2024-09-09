using Onion.CleanArchitecture.Net.Application.Filters;
using System.Collections.Generic;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity
{
    public class GetPagingRoleClaimParameter : RequestParameter
    {
        public List<int> id { get; set; }
    }
}
