﻿using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IServiceService
    {
        Task<SaveServiceRes> Save(SaveServiceReq req);
        Task<IEnumerable<ServiceView>> Gets();
        Task<ServiceView> Get(int id);
        Task<SaveServiceRes> ChangeStatusService(ChangeStatusServiceReq req);
    }
}
