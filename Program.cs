using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class Program
    {
        static void Main()
        {
            // Build configuration
            var config = new ConfigurationBuilder()//create a new configuration builder object 
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)//set base path to the current application directory so that it know whre to look for the json file(appsettings.json)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//telling the app to load settingsfrom appsettings.json and its compulsory(not optional)
                .Build();//finalize the configuration and loads it to memory

            // using the above Build configuration, Read the connection string in "appsettings.json"
            string connectionString = config.GetConnectionString("defaultConnection");
            using var conn = new NpgsqlConnection(connectionString);//now creating connection to the db using NpgsqlConnection


            // creating table on the database 

            /*
            string sql = @"
                CREATE TABLE IF NOT EXISTS StudentDB (
                id SERIAL PRIMARY KEY,
                fullname VARCHAR(100),
                email VARCHAR(100),
                age INT,
                gender VARCHAR(10),
                date_of_birth DATE,
                phone VARCHAR(15),
                address TEXT,
                department VARCHAR(100),
                level INT,
                matric_no VARCHAR(50),
                gpa DECIMAL(3,2),
                is_active BOOLEAN DEFAULT TRUE,
                created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
            )";
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.ExecuteNonQuery();//Executes the command without expecting any result (i.e., it’s not a SELECT).
            conn.Close();//closes the connection inorder to free the memory
            */

            /*
            string insertSql = @"INSERT INTO StudentDB (
            fullname, email, age, gender, date_of_birth, phone, address, department, level, matric_no, gpa, is_active) VALUES 
            (@fullname, @email, @age, @gender, @date_of_birth, @phone, @address, @department, @level, @matric_no, @gpa, @is_active)";
            //using var conn = new NpgsqlConnection(connectionString);//now creating connection to the db using NpgsqlConnection
            conn.Open();
            using var cmd = new NpgsqlCommand(insertSql, conn);
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
            */


            /*
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
            conn.Open();
            using var cmd = new NpgsqlCommand(selectSql, conn);
            using var reader = cmd.ExecuteReader();
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
            */

            /*
            string updateSql = "UPDATE StudentDB SET fullname=@fullname, email=@email WHERE age=@age";
            using var cmd = new NpgsqlCommand(updateSql, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("fullname", "Updated Updated");
            cmd.Parameters.AddWithValue("email", "Corrected@newmail.com");
            cmd.Parameters.AddWithValue("age", 18);
            cmd.ExecuteNonQuery();
            conn.Close();
            */

            /*
            string deleteSql = "DELETE FROM StudentDB WHERE id = @id";
            conn.Open();
            using var cmd = new NpgsqlCommand(deleteSql, conn);
            cmd.Parameters.AddWithValue("id", 2);
            cmd.ExecuteNonQuery();
            conn.Close();
            */



        }
    }
}