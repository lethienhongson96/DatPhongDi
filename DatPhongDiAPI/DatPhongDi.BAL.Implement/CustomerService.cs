using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Customer;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<CustomerView> Get(int id)
        {
            return await customerRepository.Get(id);
        }

    }
}
