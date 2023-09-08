using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;
using RecipeWebsite.ViewModels;

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

        public async Task<IActionResult> Index()
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
    }
}