using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Image;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost, HttpPatch]
        [Route("api/image/save")]
        public async Task<OkObjectResult> SaveImage(SaveImageReq saveImageReq)
        {
            var result = await imageService.Save(saveImageReq);
            return Ok(result);
        }

        [HttpGet("api/image/getImagesByTypeOfRoomId/{id}")]
        public async Task<OkObjectResult> GetImagesByTypeOfRoomId(int id)
        {
            var result = await imageService.GetImagesByTypeOfRoomId(id);
            return Ok(result);
        }

        [HttpPost, HttpPatch]
        [Route("api/image/delete/{imageId}")]
        public async Task<OkObjectResult> Delete(int imageId)
        {
            var result = await imageService.Delete(imageId);
            return Ok(result);
        }
    }
}
