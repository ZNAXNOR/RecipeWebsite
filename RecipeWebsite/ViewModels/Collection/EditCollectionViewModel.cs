using RecipeWebsite.Data.Enum;
using RecipeWebsite.Models;

namespace RecipeWebsite.ViewModels.Collection
{
    public class EditCollectionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public CollectionCategory CollectionCategory { get; set; }
    }
}
