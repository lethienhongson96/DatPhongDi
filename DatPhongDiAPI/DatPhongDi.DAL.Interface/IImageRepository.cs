using DatPhongDi.Domain.Request.Image;
using DatPhongDi.Domain.Response.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IImageRepository
    {
        Task<SaveImageRes> Save(SaveImageReq saveImageReq);
        Task<IEnumerable<ImageView>> GetImagesByTypeOfRoomId(int id);
        Task<DeleteRes> Delete(int imageId);
    }
}
