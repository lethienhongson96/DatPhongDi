using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Customer;
using DatPhongDi.Domain.Response.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CustomerView>> Gets()
        {
            return await repository.Gets();
        }

        public async Task<CustomerView> Get(int id)
        {
            return await repository.Get(id);
        }

        public async Task<SaveCustomerRes> Save(SaveCustomerReq req)
        {
            return await repository.Save(req);
        }
    }
}
