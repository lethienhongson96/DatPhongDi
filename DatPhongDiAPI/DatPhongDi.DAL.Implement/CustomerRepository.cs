using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Customer;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
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

