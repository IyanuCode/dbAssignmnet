using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace dbAssignmnet
{
    public class CreateTable
    {
        public static void CreateTableMethod(string tableName)
        {
        
            // Prepare SQL with sanitized table name
            string sql = $@"
                CREATE TABLE IF NOT EXISTS ""{tableName}"" (
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

            // Open connection and execute command
            using (var conn = Configuration.ConMethod())
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Table '{tableName}' created successfully (if it did not already exist).");
            }
        }
    }
}