using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Customer;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public async Task<IEnumerable<CustomerView>> Gets()
        {
            return await SqlMapper.QueryAsync<CustomerView>(cnn: connection,
                                                     sql: "sp_GetCustomer",
                                                     commandType: CommandType.StoredProcedure);
        }
    }
}
