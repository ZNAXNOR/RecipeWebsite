using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }
}
