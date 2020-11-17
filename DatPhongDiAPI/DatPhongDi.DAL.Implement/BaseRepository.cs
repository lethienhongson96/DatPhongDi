using System.Data;
using System.Data.SqlClient;

namespace DatPhongDi.DAL.Implement
{
    public class BaseRepository
    {
        protected IDbConnection connection;
        public BaseRepository()
        {
            connection = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=DatPhongDiDb;Integrated Security=True");
        }
    }
}
