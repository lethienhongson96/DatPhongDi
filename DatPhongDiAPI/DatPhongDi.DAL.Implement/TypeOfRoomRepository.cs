﻿using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Reponse;
using DatPhongDi.Domain.Request;
using System;
using System.Data;
using System.Threading.Tasks;


namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomRepository : BaseRepository, ITypeOfRoomRepository
    {
        public async Task<TypeOfRoomView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await SqlMapper.QueryFirstAsync<TypeOfRoomView>(cnn: connection,
                                                        sql: "sp_GetTypeOfRoomById",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request)
        {
            var result = new SaveTypeOfRoomRes()
            { 
                Id = 0,
                Message = "Đã xảy ra lỗi, vui lòng thử lại sau !!!"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                parameters.Add("@Name", request.Name);              
                parameters.Add("@Status", request.Status);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveTypeOfRoomRes>(cnn: connection,
                                                                    sql: "sp_UpdateTypeOfRoom",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}
