using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Image;
using DatPhongDi.Domain.Response.Image;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class ImageRepository : BaseRepository, IImageRepository
    {
        public async Task<DeleteRes> Delete(int imageId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ImageId", imageId);

            return await SqlMapper.QueryFirstOrDefaultAsync<DeleteRes>(cnn: connection,
                                                      sql: "sp_DeleteImageByImageId",
                                                      param: parameters,
                                                      commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ImageView>> GetImagesByTypeOfRoomId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await SqlMapper.QueryAsync<ImageView>(cnn: connection,
                                                      sql: "sp_GetImagesByTypeOfRoomId",
                                                      param: parameters,
                                                      commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveImageRes> Save(SaveImageReq saveImageReq)
        {
            SaveImageRes Result = new SaveImageRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ImageId", saveImageReq.ImageId);
                parameters.Add("@ImagePath", saveImageReq.ImagePath);
                parameters.Add("@TypeOfRoomId", saveImageReq.TypeOfRoomId);
                

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveImageRes>(cnn: connection,
                                                                    sql: "sp_SaveImage",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return Result;
            }
            catch (Exception)
            {
                return Result;
            }
        }
    }
}
