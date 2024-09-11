using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.CleanArchitecture.Net.Domain.Models
{
    public class Customer : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
    }
}