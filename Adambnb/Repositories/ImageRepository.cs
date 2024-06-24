using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adambnb.Data;
using Adambnb.Models;

namespace Adambnb.Repositories
{
    public class ImageRepository
    {
        private readonly AdambnbContext _context;

        public ImageRepository(AdambnbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetAllImages(CancellationToken cancellationToken)
        {
            return await _context.Images.ToListAsync(cancellationToken);
        }

        public async Task<Image> GetImageById(int id, CancellationToken cancellationToken)
        {
            return await _context.Images.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<bool> ImageExists(int id)
        {
            return await _context.Images.AnyAsync(e => e.Id == id);
        }

        public async Task<Image> CreateImage(Image image, CancellationToken cancellationToken)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync(cancellationToken);
            return image;
        }

        public async Task<Image> UpdateImage(int id, Image image, CancellationToken cancellationToken)
        {
            if (id != image.Id)
            {
                return null;
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return image;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ImageExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteImage(int id, CancellationToken cancellationToken)
        {
            var image = await _context.Images.FindAsync(new object[] { id }, cancellationToken);
            if (image == null)
            {
                return false;
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
