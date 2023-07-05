using BlazorAppWSAM.Server.Models;
using BlazorAppWSAM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWSAM.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageLibraryController : ControllerBase
    {
        private readonly IImageLibraryRepository _imageLibraryRepository;
        public ImageLibraryController(IImageLibraryRepository imageLibraryRepository)
        {
            this._imageLibraryRepository = imageLibraryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllImageList()
        {
            try
            {
                return Ok(await _imageLibraryRepository.GetImageListAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed retrieving data from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ImageLibrary>> GetImageListById(int id)
        {
            try
            {
                var result = await _imageLibraryRepository.GetImageById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed retrieving data from DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ImageLibrary>> CreateImage(ImageLibrary imageLibrary)
        {
            try
            {
                if (imageLibrary == null) return BadRequest();

                var createImage = await _imageLibraryRepository.AddImage(imageLibrary);
                return CreatedAtAction(nameof(GetImageListById), new { id = createImage.Id }, createImage);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed creating record");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ImageLibrary>> UpdateImageById([FromQuery] int id, ImageLibrary imageLibrary)
        {
            try
            {
                //if (id == imageLibrary.Id) return BadRequest();
                var imageUpdate = await _imageLibraryRepository.GetImageById(id);
                if (imageUpdate == null)
                {
                    return NotFound($"To do item not found");
                }

                return await _imageLibraryRepository.UpdateImage(imageLibrary);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed updating record");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteImageById([FromQuery] int id)
        {
            try
            {
                var imageDelete = await _imageLibraryRepository.GetImageById(id);
                if (imageDelete == null)
                {
                    return NotFound($"To do item not found");
                }

                await _imageLibraryRepository.DeleteImage(id);

                return Ok("Successfully deleted record");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed deleting record");
            }
        }



    }
}
