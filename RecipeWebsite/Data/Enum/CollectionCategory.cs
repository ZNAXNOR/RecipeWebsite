using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Data.Enum
{
    public enum CollectionCategory
    {
        [Display(Name = "Veg")]
        Veg = 0,

        [Display(Name = "NonVeg")]
        NonVeg = 1,

        [Display(Name = "Breakfast")]
        Breakfast = 2,

        [Display(Name = "Lunch")]
        Lunch = 3,

        [Display(Name = "Dinner")]
        Dinner = 4,

        [Display(Name = "Special")]
        Special = 5
    }
}
