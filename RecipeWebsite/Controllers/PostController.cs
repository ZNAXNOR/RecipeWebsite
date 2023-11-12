using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RecipeWebsite.Data;
using RecipeWebsite.Data.Enum;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.Post;

namespace RecipeWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostInterface _postInterface;
        private readonly IPhotoInterface _photoInterface;
        private readonly ApplicationDbContext _context;

        public PostController(IPostInterface postInterface, IPhotoInterface photoInterface, ApplicationDbContext context)
        {
            _postInterface = postInterface;
            _photoInterface = photoInterface;
            _context = context;
        }


        // Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Post> post = await _postInterface.GetAll();
            return View(post);
        }
                

        // Filter
        [HttpPost]
        public async Task<IActionResult> Index(string searchString, PostCategory? postCategory)
        {
            var post = from p in _context.Posts select p;

            // Searchbar
            if (!string.IsNullOrEmpty(searchString))
            {
                post = post.Where(t => t.Title!.Contains(searchString));
            }

            // Category Dropdown
            if (postCategory != null)
            {
                post = _context.Posts.Where(c => c.PostCategory == postCategory);
            }

            return View(await post.ToListAsync());
        }


        // Details
        public async Task<IActionResult> Detail(int id)
        {
            Post post = await _postInterface.GetByIdAsync(id);
            return View(post);
        }


        // Create
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
                    Link = postVM.Link,
                    PostCategory = postVM.PostCategory,
                    Ingredient = postVM.Ingredient,
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


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postInterface.GetByIdAsync(id);
            if (post == null) return View("Error");

            var postVM = new EditPostViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Link = post.Link,
                PostCategory = post.PostCategory,
                Ingredient = post.Ingredient,
                URL = post.Image,
                Recipe = post.Recipe
            };
            return View(postVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPostViewModel postVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit post");
                return View("Edit", postVM);
            }

            var userPost = await _postInterface.GetByIdAsyncNoTracking(id);

            if (userPost != null)
            {
                try
                {
                    await _photoInterface.DeletePhotoAsync(userPost.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(postVM);
                }
                var photoResult = await _photoInterface.AddPhotoAsync(postVM.Image);

                var post = new Post
                {
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    PostCategory = postVM.PostCategory,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = photoResult.Url.ToString()
                };

                _postInterface.Update(post);

                return RedirectToAction("Index");
            }
            else
            {
                return View(postVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);
            if (postDetails == null) return View("Error");
            return View(postDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var postDetails = await _postInterface.GetByIdAsync(id);
            if (postDetails == null) return View("Error");

            _postInterface.Delete(postDetails);
            return RedirectToAction("Index");
        }
    }
}
