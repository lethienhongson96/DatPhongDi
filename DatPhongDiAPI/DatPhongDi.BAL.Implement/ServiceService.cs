using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Service;
using DatPhongDi.Domain.Response.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public async Task<SaveServiceRes> ChangeStatusService(ChangeStatusServiceReq req)
        {
            return await serviceRepository.ChangeStatusService(req);
        }

        public async Task<ServiceView> Get(int id)
        {
            return await serviceRepository.Get(id);
        }

        public async Task<IEnumerable<ServiceView>> Gets()
        {
            return await serviceRepository.Gets();
        }

        public async Task<SaveServiceRes> Save(SaveServiceReq req)
        {
            return await serviceRepository.Save(req);
        }
    }
}
