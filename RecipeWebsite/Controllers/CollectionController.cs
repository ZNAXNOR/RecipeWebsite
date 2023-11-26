using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.Collection;

namespace RecipeWebsite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionInterface _collectionInterface;
        private readonly IPhotoInterface _photoInterface;
        private readonly ApplicationDbContext _context;

        public CollectionController(ICollectionInterface collectionInterface, IPhotoInterface photoInterface, ApplicationDbContext context)
        {
            _collectionInterface = collectionInterface;
            _photoInterface = photoInterface;
            _context = context;
        }


        // Index
        public async Task <IActionResult> Index()
        {
            IEnumerable<Collection> collections = await _collectionInterface.GetAll();
            return View(collections);
        }


        // Search Bar
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var collections = from c in _context.Collections select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                TempData["searchString"] = searchString;

                collections = collections.Where(s => s.Title!.Contains(searchString));
            }

            return View(await collections.ToListAsync());
        }

        // Detail
        public async Task<IActionResult> Detail(int id)
        {
            Collection collection = await _collectionInterface.GetByIdAsync(id);
            return View(collection);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionViewModel collectionVM)            
        {
            if (ModelState.IsValid)
            {
                var result = await _photoInterface.AddPhotoAsync(collectionVM.Image);

                var collection = new Collection
                {
                    Title = collectionVM.Title,
                    Description = collectionVM.Description,
                    CollectionCategory = collectionVM.CollectionCategory,
                    Image = result.Url.ToString()
                };
                _collectionInterface.Add(collection);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(collectionVM);
        }


        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var collection = await _collectionInterface.GetByIdAsync(id);
            if (collection == null) return View("Error");
            var collectionVM = new EditCollectionViewModel
            {
                Title = collection.Title,
                Description = collection.Description,
                CollectionCategory = collection.CollectionCategory,
                URL = collection.Image
            };
            return View(collectionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCollectionViewModel collectionVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit collection");
                return View("Edit", collectionVM);
            }

            var userCollection = await _collectionInterface.GetByIdAsyncNoTracking(id);

            if (userCollection != null)
            {
                try
                {
                    await _photoInterface.DeletePhotoAsync(userCollection.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(collectionVM);
                }
                var photoResult = await _photoInterface.AddPhotoAsync(collectionVM.Image);

                var collection = new Collection
                {
                    Id = id,
                    Title = collectionVM.Title,
                    Description = collectionVM.Description,
                    CollectionCategory = collectionVM.CollectionCategory,
                    Image = photoResult.Url.ToString()
                };

                _collectionInterface.Update(collection);

                return RedirectToAction("Index");
            }
            else
            {
                return View(collectionVM);
            }
        }


        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var collectionDetails = await _collectionInterface.GetByIdAsync(id);
            if (collectionDetails == null) return View("Error");
            return View(collectionDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collectionDetails = await _collectionInterface.GetByIdAsync(id);
            if (collectionDetails == null) return View("Error");

            _collectionInterface.Delete(collectionDetails);
            return RedirectToAction("Index");
        }
    }
}
