using RecipeWebsite.Data.Enum;

namespace RecipeWebsite.ViewModels.Collection
{
    public class CreateCollectionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public CollectionCategory CollectionCategory { get; set; }
    }
}