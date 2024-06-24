using System.Collections.Generic;
using System.Threading;
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

        public async Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken)
        {
            return await _imageRepository.GetAllImages(cancellationToken);
        }

        public async Task<Image> GetImageById(int id, CancellationToken cancellationToken)
        {
            return await _imageRepository.GetImageById(id, cancellationToken);
        }

        public async Task AddImage(Image image, CancellationToken cancellationToken)
        {
            await _imageRepository.CreateImage(image, cancellationToken);
        }

        public async Task UpdateImage(Image image, CancellationToken cancellationToken)
        {
            await _imageRepository.UpdateImage(image.Id, image, cancellationToken);
        }

        public async Task DeleteImage(int id, CancellationToken cancellationToken)
        {
            await _imageRepository.DeleteImage(id, cancellationToken);
        }

        public bool ImageExists(int id)
        {
            return _imageRepository.ImageExists(id).Result;
        }
    }
}
