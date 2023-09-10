using RecipeWebsite.Data.Enum;
using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.Post
{
    public class EditPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public PostCategory PostCategory { get; set; }
    }
}
