using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using Npgsql;


namespace dbAssignmnet
{
    public class Configuration
    {
        public static NpgsqlConnection ConMethod()
        {
            var config = new ConfigurationBuilder()//create a new configuration builder object 
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)//set base path to the current application directory so that it know whre to look for the json file(appsettings.json)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//telling the app to load settingsfrom appsettings.json and its compulsory(not optional)
                .Build();//finalize the configuration and loads it to memory

            // using the above Build configuration, Read the connection string in "appsettings.json"
            string? connectionString = config.GetConnectionString("defaultConnection");
            if (connectionString == null)
            {
                Console.WriteLine("The string is empty or null");
            }
            var conn = new NpgsqlConnection(connectionString);//now creating connection to the db using NpgsqlConnection
            conn.Open();
            return conn;
        }


    }
}