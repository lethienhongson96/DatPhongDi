﻿using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
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
