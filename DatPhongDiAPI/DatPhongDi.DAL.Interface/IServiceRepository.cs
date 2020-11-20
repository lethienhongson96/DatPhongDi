using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IServiceRepository 
    {
        Task<SaveServiceRes> Save(SaveServiceReq req);
        Task<IEnumerable<ServiceView>> Gets();
        Task<ServiceView> Get(int id);
        Task<SaveServiceRes> ChangeStatusService(ChangeStatusServiceReq req);
    }
}
