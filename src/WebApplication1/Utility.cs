using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Utility
    {
        private static string DBConnectString;

        public Utility(IConfiguration configuration)
        {
            DBConnectString = configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
        }

        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(DBConnectString);
            connection.Open();
            return connection;
        }
    }
}
