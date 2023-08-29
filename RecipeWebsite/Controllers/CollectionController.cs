using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Interface;
using RecipeWebsite.Models;

namespace RecipeWebsite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionInterface _collectionInterface;

        public CollectionController(ICollectionInterface collectionInterface)
        {
            _collectionInterface = collectionInterface;
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
    }
}
