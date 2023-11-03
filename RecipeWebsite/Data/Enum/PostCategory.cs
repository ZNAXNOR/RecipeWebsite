using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Data.Enum
{
    public enum PostCategory
    {
        [Display(Name = "Veg")]
        Veg = 0,

        [Display(Name = "NonVeg")]
        NonVeg = 1
    }
}
