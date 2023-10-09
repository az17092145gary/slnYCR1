using Dapper;
using System.Data.SqlClient;

namespace YCR1.Model
{
    public class UserFactorycs
    {
        private readonly string _connectionString = "Server=WORKNB;Database=ForYCR;Integrated Security=SSPI;";
        public User UserGet(SqlConnection connectionString, int id) 
        {
            var result = connectionString.QueryFirst<User>("select * from User where id = " + id);
            return result;
        }
        

    }
}
