using DatPhongDi.Domain.Response.Customer;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ICustomerService
    {
        Task<CustomerView> Get(int id);
    }
}
