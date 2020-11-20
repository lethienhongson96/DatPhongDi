﻿using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomRepository : BaseRepository,ITypeOfRoomRepository
    {
        public async Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq changeStatusTypeOfRoomReq)
        {
            ChangeStatusTypeOfRoomRes Result = new ChangeStatusTypeOfRoomRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Status", changeStatusTypeOfRoomReq.Status);
                parameters.Add("@Id", changeStatusTypeOfRoomReq.Id);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<ChangeStatusTypeOfRoomRes>(cnn: connection,
                                                                    sql: "sp_ChangeTypeOfRoomStatus",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return Result;
            }
            catch (Exception)
            {
                return Result;
            }
        }

        public async Task<TypeOfRoomView> Get(int TypeOfRoomId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", TypeOfRoomId);

            return await SqlMapper.QueryFirstOrDefaultAsync<TypeOfRoomView>(cnn: connection,
                                                        sql: "sp_GetTypeOfRoomById",
                                                        dynamicParameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<TypeOfRoomView> Gets()
        {
            return await SqlMapper.QueryFirstOrDefaultAsync<TypeOfRoomView>(cnn: connection,
                                                   sql: "sp_GetAllTypeOfRoom",
                                                   commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq saveTypeOfRoomReq)
        {
            SaveTypeOfRoomRes Result = new SaveTypeOfRoomRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", saveTypeOfRoomReq.Name);
                parameters.Add("@Id", saveTypeOfRoomReq.Id);
                parameters.Add("@Status", saveTypeOfRoomReq.Status);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveTypeOfRoomRes>(cnn: connection,
                                                                    sql: "sp_SaveTypeOfRoom",
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
