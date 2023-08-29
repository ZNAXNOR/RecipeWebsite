using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Data;
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

        public async Task<IActionResult> IndexAsync()
        {            
            IEnumerable<Post> posts = await _postInterface.GetAll();
            return View(posts);
        }

        public async Task<IActionResult> DetailAsync(int id)
        {            
            Post post = await _postInterface.GetByIdAsync(id);
            return View(post);
        }
    }
}
