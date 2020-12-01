using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Image;
using DatPhongDi.Domain.Response.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<DeleteRes> Delete(int imageId)
        {
            return await imageRepository.Delete(imageId);
        }

        public async Task<IEnumerable<ImageView>> GetImagesByTypeOfRoomId(int id)
        {
            return await imageRepository.GetImagesByTypeOfRoomId(id);
        }

        public async Task<SaveImageRes> Save(SaveImageReq saveImageReq)
        {
            return await imageRepository.Save(saveImageReq);
        }
    }
}
