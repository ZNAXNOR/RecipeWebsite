using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.ViewModels.Account
{
    public class RegisterViewModel
    {
        // Name
        [Required]
        [StringLength(255, ErrorMessage = "The first name must be a maximim of 255 characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The last name must be a maximim of 255 characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        // User Name
        [Required]
        [StringLength(255, ErrorMessage = "The last name must be a maximim of 255 characters long.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        // Email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        // Password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        // Return Url
        public string? ReturnUrl { get; set; }
    }
}
