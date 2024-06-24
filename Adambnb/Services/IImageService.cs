using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken);
        Task<Image> GetImageById(int id, CancellationToken cancellationToken);
        Task AddImage(Image image, CancellationToken cancellationToken);
        Task UpdateImage(Image image, CancellationToken cancellationToken);
        Task DeleteImage(int id, CancellationToken cancellationToken);
        bool ImageExists(int id);
    }
}
