using DatPhongDi.Domain.Request.Customer;
using DatPhongDi.Domain.Response.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerView>> Gets();
        Task<CustomerView> Get(int id);
        Task<SaveCustomerRes> Save(SaveCustomerReq req);
    }
}
