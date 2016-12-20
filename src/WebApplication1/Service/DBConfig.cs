using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Service
{
    public class DBConfig
    {
        private readonly IConfiguration _Configuration;

        public DBConfig(IConfiguration configuration)
        {
            _Configuration = configuration;

        }
    }
}
