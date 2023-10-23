using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;

namespace RecipeWebsite.Models
{
    public class AppUser : IdentityUser
    {
        // Applcation
        [Key]
        public string Id { get; set; }
        public string? Category { get; set; }        
        public ICollection<Collection> Collections { get; set; }
        public ICollection<Post> Posts { get; set; }

        // Account
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
