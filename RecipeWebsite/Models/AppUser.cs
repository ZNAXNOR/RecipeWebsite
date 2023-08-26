using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;

namespace RecipeWebsite.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public string? Category { get; set; }        
        public ICollection<Collection> Collections { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
