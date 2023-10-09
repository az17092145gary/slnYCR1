using Dapper;
using System.Data.SqlClient;

namespace YCR1.Model
{
    public class UserFactorycs
    {
        public readonly string _connectionString = "Server=WORKNB;Database=ForYCR;Integrated Security=SSPI;";
        public User UserGet(SqlConnection connectionString, string id)
        {
            var result = connectionString.QueryFirst<User>("select * from [User] where id = @id", new { id });
            return result;
        }
        public int UserAdd(SqlConnection connectionString, User user)
        {
            var result = connectionString.Execute("Insert [User] VALUES(@id,@name,@age)", user);
            return result;
        }
        public int UserEdit(SqlConnection connectionString, User user)
        {
            var result = connectionString.Execute("Update [User] set name = @name, age =  @age where id = @id", user);
            return result;
        }
        public int UserDelete(SqlConnection connectionString, string id)
        {
            var result = connectionString.Execute("Delete [User] where id = @id", new { id });
            return result;
        }

    }
}
