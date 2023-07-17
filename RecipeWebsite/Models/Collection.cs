using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
