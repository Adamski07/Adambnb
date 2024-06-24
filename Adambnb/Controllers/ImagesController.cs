using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Adambnb.Models;
using Adambnb.Services;
using Microsoft.EntityFrameworkCore;

namespace Adambnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages(CancellationToken cancellationToken)
        {
            var images = await _imageService.GetAllImages(cancellationToken);
            return Ok(images);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetImageById(id, cancellationToken);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, Image image, CancellationToken cancellationToken)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }

            try
            {
                await _imageService.UpdateImage(image, cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_imageService.ImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Images
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image, CancellationToken cancellationToken)
        {
            await _imageService.AddImage(image, cancellationToken);
            return CreatedAtAction("GetImage", new { id = image.Id }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetImageById(id, cancellationToken);
            if (image == null)
            {
                return NotFound();
            }

            await _imageService.DeleteImage(id, cancellationToken);
            return NoContent();
        }
    }
}
