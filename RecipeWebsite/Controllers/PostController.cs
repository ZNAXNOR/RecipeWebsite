using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;
using RecipeWebsite.Data;
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
        private readonly IMemoryCache _cache;

        public PostController(IPostInterface postInterface, IPhotoInterface photoInterface, ApplicationDbContext context, IMemoryCache cache)
        {
            _postInterface = postInterface;
            _photoInterface = photoInterface;
            _context = context;
            _cache = cache;
        }


        // Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cached = _cache.TryGetValue("post", out var post);
            if (cached)
            {
                return View(post);
            }
            return View(await _context.Posts.ToListAsync());
        }


        // Searchbar
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var post = from p in _context.Posts select p;

            // Searchbar
            if (!string.IsNullOrEmpty(searchString))
            {
                TempData["searchString"] = searchString;

                post = post.Where(t => t.Title!.Contains(searchString));
            }

            return View(await post.ToListAsync());
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
                    // Post
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = result.Url.ToString(),

                    // Addition
                    Date = DateTime.Now,
                    View = 0,
                    Like = 0,
                    Dislike = 0,

                    // Category
                    PostCategory = postVM.PostCategory
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


        // Details
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Post post = await _postInterface.GetByIdAsync(id);

            post.View++;

            _context.Update(post);
            await _context.SaveChangesAsync();

            return View(post);
        }

        // Like
        public async Task<IActionResult> Like(int id)
        {
            Post post = await _postInterface.GetByIdAsync(id);

            post.Like++;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }

        // Dislike
        public async Task<IActionResult> Dislike(int id)
        {
            Post post = await _postInterface.GetByIdAsync(id);

            post.Dislike++;

            _context.Update(post);
            await _context.SaveChangesAsync();

            string url = Request.Headers["Referer"].ToString();

            return Redirect(url);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postInterface.GetByIdAsync(id);
            if (post == null) return View("Error");

            var postVM = new EditPostViewModel
            {
                // Post
                Title = post.Title,
                Description = post.Description,
                Link = post.Link,
                Ingredient = post.Ingredient,
                URL = post.Image,
                Recipe = post.Recipe,

                // Category
                PostCategory = post.PostCategory
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
                    // Post
                    Id = id,
                    Title = postVM.Title,
                    Description = postVM.Description,
                    Link = postVM.Link,
                    Ingredient = postVM.Ingredient,
                    Recipe = postVM.Recipe,
                    Image = photoResult.Url.ToString(),

                    // Category
                    PostCategory = postVM.PostCategory
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
