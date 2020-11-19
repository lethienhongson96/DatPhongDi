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
                                                     sql: "sp_GetCustomers",
                                                     commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerView> Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await SqlMapper.QueryFirstAsync<CustomerView>(cnn: connection,
                                                        sql: "sp_GetCustomerById",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}

