using RecipeWebsite.Models;

namespace RecipeWebsite.Interface
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
