using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class Insert
    {
        public static void InsertMethod()
        {
            string insertSql = @"INSERT INTO StudentDB (
            fullname, email, age, gender, date_of_birth, phone, address, department, level, matric_no, gpa, is_active) VALUES 
            (@fullname, @email, @age, @gender, @date_of_birth, @phone, @address, @department, @level, @matric_no, @gpa, @is_active)";
            //using var conn = new NpgsqlConnection(connectionString);//now creating connection to the db using NpgsqlConnection
            var conn = Configuration.ConMethod();
            conn.Open();
            var cmd = new NpgsqlCommand(insertSql, conn);
            cmd.Parameters.AddWithValue("fullname", "John Doe");
            cmd.Parameters.AddWithValue("email", "john@example.com");
            cmd.Parameters.AddWithValue("age", 18);
            cmd.Parameters.AddWithValue("gender", "female");
            cmd.Parameters.AddWithValue("date_of_birth", new DateTime(2010, 10, 10));
            cmd.Parameters.AddWithValue("phone", "122222222");
            cmd.Parameters.AddWithValue("address", "no 12, john thomas street");
            cmd.Parameters.AddWithValue("department", "mathematics");
            cmd.Parameters.AddWithValue("level", 200);
            cmd.Parameters.AddWithValue("matric_no", "23343s");
            cmd.Parameters.AddWithValue("gpa", 2.3);
            cmd.Parameters.AddWithValue("is_active", true);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}