using RecipeWebsite.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebsite.Models
{
    public class Post
    {
        // Post
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string Recipe { get; set; }
        public string Image { get; set; }
        
        // Category
        public PostCategory PostCategory { get; set; }


        // App User
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
