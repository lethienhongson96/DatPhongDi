using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IServiceService
    {
        Task<SaveServiceRes> Save(SaveServiceReq req);
        Task<IEnumerable<ServiceView>> Gets();
        Task<ServiceView> Get(int id);
    }
}
