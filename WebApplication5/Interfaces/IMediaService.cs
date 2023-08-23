using CloudinaryDotNet.Actions;

namespace WebApplication5.Interfaces
{
    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicUrl);

        Task<VideoUploadResult> AddVideoAsync(IFormFile file);
    }
}
