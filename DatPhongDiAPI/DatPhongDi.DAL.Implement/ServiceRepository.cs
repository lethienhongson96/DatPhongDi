using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public async Task<SaveServiceRes> ChangeStatusService(ChangeStatusServiceReq req)
        {
            var result = new SaveServiceRes()
            {
                Id = 0,
                Message = "Có gì đó sai, vui lòng thử lại sau!"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", req.Id);
                parameters.Add("@Status", req.Status);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveServiceRes>(cnn: connection,
                                                                                  sql: "sp_ChangeStatusService",
                                                                                  param: parameters,
                                                                                  commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        public async Task<ServiceView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var result = await SqlMapper.QueryFirstOrDefaultAsync<ServiceView>(cnn: connection,
                                                                                sql: "sp_GetServiceById",
                                                                                param: parameters,
                                                                                commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<IEnumerable<ServiceView>> Gets()
        {
            return await SqlMapper.QueryAsync<ServiceView>(cnn: connection,
                                                       sql: "sp_GetsService",
                                                       commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveServiceRes> Save(SaveServiceReq req)
        {
            var result = new SaveServiceRes()
            {
                Id = 0,
                Message = "Có gì đó sai, vui lòng thử lại sau!"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", req.Id);
                parameters.Add("@Name", req.Name);
                parameters.Add("@Icon", req.Icon);
                parameters.Add("@Status", req.Status);
                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveServiceRes>(cnn: connection,
                                                                                  sql: "sp_SaveService",
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
