using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Interfaces;
using RecipeWebsite.Models;

namespace RecipeWebsite.Repository
{
    public class CollectionRepository : ICollectionInterface
    {
        private readonly ApplicationDbContext _context;

        public CollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Collection collection)
        {
            _context.Add(collection);
            return Save();
        }

        public bool Delete(Collection collection)
        {
            _context.Remove(collection);
            return Save();
        }

        public async Task<IEnumerable<Collection>> GetAll()
        {
            return await _context.Collections.ToListAsync();
        }

        public async Task<Collection> GetByIdAsync(int id)
        {
            return await _context.Collections.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved  > 0 ? true : false;
        }

        public bool Update(Collection collection)
        {
            _context.Update(collection);
            return Save();
        }
    }
}
