using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Collection> collections = _context.Collections.ToList();
            return View(collections);
        }

        public IActionResult Detail(int id)
        {
            Collection collection = _context.Collections.FirstOrDefault(c => c.Id == id);
            return View(collection);
        }
    }
}
