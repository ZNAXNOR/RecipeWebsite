using RecipeWebsite.Data.Enum;

namespace RecipeWebsite.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? Ingredient { get; set; }
        public string Recipe { get; set; }
        public IFormFile Image { get; set; }
        public PostCategory PostCategory { get; set; }
    }
}
