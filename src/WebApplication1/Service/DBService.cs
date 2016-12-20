using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WebApplication1.Service
{
    public class DBService : DBServiceBase
    {
        private DbConnection _connection;

        public DBService()
        {
        }

        public DBService(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<ZJFI_TempVM> GetTemp()
        {


            IEnumerable<ZJFI_TempVM> model;

            using (_connection = base.GetOpenConnection())
            {
                model = _connection.Query<ZJFI_TempVM>("SELECT * FROM ZJFI_Temp");
            }

            return model;

        }
    }
}
