using Microsoft.AspNetCore.Identity;
using Onion.CleanArchitecture.Net.Application.DTOs.Account;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.CleanArchitecture.Net.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
