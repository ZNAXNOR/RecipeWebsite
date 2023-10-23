using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.ViewModels.Account
{
    public class LoginViewModel
    {
        // User Name
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }


        // Email
        [EmailAddress]
        public string? Email { get; set; }


        // Password
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        // Remember Me
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


        // ReturnUrl
        public string? ReturnUrl { get; set; }


        // Error Message
        [TempData]
        public string? ErrorMessage { get; set; }
    }
}
