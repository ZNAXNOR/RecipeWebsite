using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.ViewModels.Searchbar;

namespace RecipeWebsite.Controllers
{
    public class SearchbarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchbarController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Posts == null || _context.Collections == null)
            {
                return Problem("Search Result does not exist.");
            }

            var posts = from p in _context.Posts select p;
            var collections = from c in _context.Collections select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(ps => ps.Title!.Contains(searchString));
                collections = collections.Where(cs => cs.Title!.Contains(searchString));
            }

            var searchbarVM = new SearchbarViewModel
            {
                Posts = await posts.ToListAsync(),
                Collections = await collections.ToListAsync()
            };

            return View(searchbarVM);
        }
    }
}
