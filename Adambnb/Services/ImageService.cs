using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;
using Adambnb.Repositories;

namespace Adambnb.Services
{
    public class ImageService : IImageService
    {
        private readonly ImageRepository _imageRepository;

        public ImageService(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _imageRepository.GetAllImages();
        }

        public async Task<Image> GetImageById(int id)
        {
            return await _imageRepository.GetImageById(id);
        }

        public async Task AddImage(Image image)
        {
            await _imageRepository.CreateImage(image);
        }

        public async Task UpdateImage(Image image)
        {
            await _imageRepository.UpdateImage(image.Id, image);
        }

        public async Task DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
        }

        public bool ImageExists(int id)
        {
            return _imageRepository.ImageExists(id).Result;
        }
    }
}
