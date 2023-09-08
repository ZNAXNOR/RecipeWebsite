using RecipeWebsite.Models;

namespace RecipeWebsite.Interfaces
{
    public interface IPostInterface
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetByIdAsync(int id);
        bool Add(Post post);
        bool Update(Post post);
        bool Delete(Post post);
        bool Save();
    }
}
