using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class Delete
    {
        public static void DeleteMethod()
        {
            string deleteSql = "DELETE FROM StudentDB WHERE id = @id";
            var conn = Configuration.ConMethod();
            conn.Open();
            var cmd = new NpgsqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("id", 2);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}