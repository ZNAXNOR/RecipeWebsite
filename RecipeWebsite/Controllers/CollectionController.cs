using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels.Collection;

namespace RecipeWebsite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionInterface _collectionInterface;
        private readonly IPhotoInterface _photoInterface;

        public CollectionController(ICollectionInterface collectionInterface, IPhotoInterface photoInterface)
        {
            _collectionInterface = collectionInterface;
            _photoInterface = photoInterface;
        }

        public async Task <IActionResult> Index()
        {
            IEnumerable<Collection> collections = await _collectionInterface.GetAll();
            return View(collections);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Collection collection = await _collectionInterface.GetByIdAsync(id);
            return View(collection);
        }

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

        public async Task<IActionResult> Edit(int id)
        {
            var collection = await _collectionInterface.GetByIdAsync(id);
            if (collection == null) return View("Error");
            var collectionVM = new EditCollectionViewModel
            {
                Title = collection.Title,
                Description = collection.Description,
                URL = collection.Image,
                CollectionCategory = collection.CollectionCategory
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
    }
}
