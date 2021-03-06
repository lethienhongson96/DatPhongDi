﻿using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomRepository : BaseRepository, ITypeOfRoomRepository
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

        public async Task<IEnumerable<TypeOfRoomView>> CheckAvailable([FromBody] CheckAvailable req)
        {
            IEnumerable<TypeOfRoomView> result = new List<TypeOfRoomView>();
            try
            {
                //format datetime for 2 param CheckIn and CheckOut
                var CheckInStr = req.CheckIn.ToString("yyyy-MM-dd");
                var CheckOutStr = req.CheckOut.ToString("yyyy-MM-dd");

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AmountAdults", req.AmountAdults);
                parameters.Add("@AmountChild", req.AmountChild);
                parameters.Add("@CheckIn", CheckInStr);
                parameters.Add("@CheckOut", CheckOutStr);
                result = await SqlMapper.QueryAsync<TypeOfRoomView>(cnn: connection,
                                                                    sql: "sp_CheckAvailable",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return result;
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

        public async Task<RoomTypeDetailView> GetAvailableTypeOfRoom([FromBody] CheckTypeOfRoomAvailableReq req)
        {
            //format datetime for 2 param CheckIn and CheckOut
            var CheckInStr = req.CheckIn.ToString("yyyy-MM-dd");
            var CheckOutStr = req.CheckOut.ToString("yyyy-MM-dd");

            DynamicParameters dynamic = new DynamicParameters();
            dynamic.Add("@Id", req.Id);
            dynamic.Add("@CheckIn", CheckInStr);
            dynamic.Add("@CheckOut", CheckOutStr);
            return await SqlMapper.QueryFirstOrDefaultAsync<RoomTypeDetailView>(cnn: connection,




                                                                                sql: "sp_GetTypeOfRoomByIdAfterCheckAvailable",
                                                                                dynamic,
                                                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TypeOfRoomView>> Gets()
        {
            return await SqlMapper.QueryAsync<TypeOfRoomView>(cnn: connection,
                                                   sql: "sp_GetAllTypeOfRoom",
                                                   commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewServiceByRoomTypeId>> GetServiceByRoomTypeId(int TypeOfRoomId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", TypeOfRoomId);

            return await SqlMapper.QueryAsync<ViewServiceByRoomTypeId>(cnn: connection,
                                                   sql: "sp_GetServiceByTypeOfRoomId",
                                                   param: parameters,
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
                parameters.Add("@AmountAdults", saveTypeOfRoomReq.AmountAdults);
                parameters.Add("@AmountChild", saveTypeOfRoomReq.AmountChild);
                parameters.Add("@PricePerNight", saveTypeOfRoomReq.PricePerNight);

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
