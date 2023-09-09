using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Interface;
using RecipeWebsite.Models;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;

        public PostController(IPostInterface postInterface)
        {
            _postInterface = postInterface;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> posts = await _postInterface.GetAll();
            return View(posts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Post post = await _postInterface.GetByIdAsync(id);
            return View(post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            _postInterface.Add(post);
            return RedirectToAction("Index");
        }
    }
}