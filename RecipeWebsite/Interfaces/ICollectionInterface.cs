using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface ICollectionInterface
    {
        Task<IEnumerable<Collection>> GetAll();
        Task<Collection> GetByIdAsync(int id);
        bool Add(Collection collection);
        bool Update(Collection collection);
        bool Delete(Collection collection);
        bool Save();
    }
}
