using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;
using Dapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IConfiguration Configuration;

        public HelloWorldController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            string DBConnectString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
            IDbConnection _connection = new SqlConnection(DBConnectString);
            _connection.Open();


            IEnumerable<ZJFI_TempVM> model = _connection.Query<ZJFI_TempVM>("SELECT * FROM ZJFI_Temp");

            return View(model);
        }
    }
}
