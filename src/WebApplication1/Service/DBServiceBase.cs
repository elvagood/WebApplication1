using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Service
{
    public class DBServiceBase
    {
        private readonly IConfiguration Configuration;
        public readonly string DBConnectString;

        public DBServiceBase(IConfiguration configuration)
        {
            Configuration = configuration;

            //DBConnectString = "Server=210.126.180.96;Database=SyteLine_KENDEV_App;uid=sa;pwd=ERProqkf*2016^";
            DBConnectString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
        }

        public DBServiceBase()
        {
            //Configuration = configuration;

            DBConnectString = "Server=210.126.180.96;Database=SyteLine_KENDEV_App;uid=sa;pwd=ERProqkf*2016^";
            //DBConnectString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
        }

        public SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(DBConnectString);
            connection.Open();
            return connection;
        }
    }
}
