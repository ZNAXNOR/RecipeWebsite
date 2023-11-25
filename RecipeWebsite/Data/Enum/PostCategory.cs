using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Data.Enum
{
    public enum PostCategory
    {
        [Display(Name = "Veg")]
        [Description("Veg")]
        Veg,

        [Display(Name = "NonVeg")]
        [Description("NonVeg")]
        NonVeg
    }
}
