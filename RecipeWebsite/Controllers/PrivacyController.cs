using Microsoft.AspNetCore.Mvc;

namespace RecipeWebsite.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
