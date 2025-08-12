using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class Select
    {
        public static void SelectMethod()
        {
             string selectSql = @"SELECT 
            id, 
            fullname, 
            email, 
            age, 
            gender, 
            date_of_birth, 
            phone, 
            address, 
            department, 
            level, 
            matric_no, 
            gpa, 
            is_active 
            FROM StudentDB";
            var conn = Configuration.ConMethod();
            conn.Open();
            var cmd = new NpgsqlCommand(selectSql, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} " + // id
                    $"| {reader.GetString(1)} " +             // fullname
                    $"| {reader.GetString(2)} " +             // email
                    $"| {reader.GetInt32(3)} " +              // age (was GetString(1) in your code — incorrect)
                    $"| {reader.GetString(4)} " +             // gender
                    $"| {reader.GetDateTime(5).ToShortDateString()} " + // date_of_birth
                    $"| {reader.GetString(6)} " +             // phone
                    $"| {reader.GetString(7)} " +             // address
                    $"| {reader.GetString(8)} " +             // department
                    $"| {reader.GetInt32(9)} " +              // level
                    $"| {reader.GetString(10)} " +            // matric_no
                    $"| {reader.GetDecimal(11)} " +           // gpa
                    $"| {reader.GetBoolean(12)}");            // is_active
            }

            conn.Close();
        }
    }
}