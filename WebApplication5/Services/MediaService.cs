using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using WebApplication5.Helpers;
using WebApplication5.Interfaces;

namespace WebApplication5.Services
{
    public class MediaService : IMediaService
    {
        private readonly Cloudinary _cloundinary;

        public MediaService(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloundinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()/*.Height(500).Width(500)*/.Crop("fill").Gravity("face")
                };
                uploadResult = await _cloundinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()/*.Height(500).Width(500)*/.Crop("fill").Gravity("face")
                };
                uploadResult = await _cloundinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        /*        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            
            var uploadResult = new VideoUploadResult();
            if (file.Length > 0 && file.Length <= 90 * 1024 * 1024)
            {
                using var stream = file.OpenReadStream();

                // Загрузка видео без проверки длительности
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Crop("fill").Gravity("face")
                };
                uploadResult = await _cloundinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }*/

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await _cloundinary.DestroyAsync(deleteParams);
        }
    }
}
