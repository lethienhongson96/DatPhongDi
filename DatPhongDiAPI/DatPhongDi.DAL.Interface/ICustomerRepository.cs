using DatPhongDi.Domain.Response.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerView>> Gets();
        Task<CustomerView> Get(int id);
    }
}
