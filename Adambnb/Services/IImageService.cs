using System.Collections.Generic;
using System.Threading.Tasks;
using Adambnb.Models;

namespace Adambnb.Services
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetAllImages();
        Task<Image> GetImageById(int id);
        Task AddImage(Image image);
        Task UpdateImage(Image image);
        Task DeleteImage(int id);
        bool ImageExists(int id);
    }
}
