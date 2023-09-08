using CloudinaryDotNet.Actions;

namespace RecipeWebsite.Interfaces
{
    public interface IPhotoInterface
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);        
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
