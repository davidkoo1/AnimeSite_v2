using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace BLL.Interfaces
{
    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicUrl);

        Task<VideoUploadResult> AddVideoAsync(IFormFile file);
    }
}
