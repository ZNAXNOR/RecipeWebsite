using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }

        public IActionResult Detail(int id)
        {
            Post post = _context.Posts.FirstOrDefault(c => c.Id == id);
            return View(post);
        }
    }
}
