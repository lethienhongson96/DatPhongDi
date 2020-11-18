using DatPhongDi.Domain.Reponse.Customer;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ICustomerRepository
    {
        Task<CustomerView> Get(int id);
    }
}
