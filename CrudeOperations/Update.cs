using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class Update
    {
        public static void UpdateMethod()
        {
            string updateSql = "UPDATE StudentDB SET fullname=@fullname, email=@email WHERE age=@age";
            var conn = Configuration.ConMethod();
            var cmd = new NpgsqlCommand(updateSql, conn);  
            conn.Open();
            cmd.Parameters.AddWithValue("fullname", "Updated Updated");
            cmd.Parameters.AddWithValue("email", "Corrected@newmail.com");
            cmd.Parameters.AddWithValue("age", 18);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}