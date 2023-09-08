using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;
        private readonly IPhotoInterface _photoInterface;

        public PostController(IPostInterface postInterface, IPhotoInterface photoInterface)
        {
            _postInterface = postInterface;
            _photoInterface = photoInterface;
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
        public async Task<IActionResult> Create(CreatePostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoInterface.AddPhotoAsync(postVM.Image);

                var post = new Post
                {
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Recipe = postVM.Recipe,
                    Image = result.Url.ToString()
                };
                _postInterface.Add(post);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(postVM);
        }
    }
}