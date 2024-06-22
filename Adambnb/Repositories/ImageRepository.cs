using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Image>> GetAllImages()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetImageById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<bool> ImageExists(int id)
        {
            return await _context.Images.AnyAsync(e => e.Id == id);
        }

        public async Task<Image> CreateImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> UpdateImage(int id, Image image)
        {
            if (id != image.Id)
            {
                return null;
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

        public async Task<bool> DeleteImage(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return false;
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
