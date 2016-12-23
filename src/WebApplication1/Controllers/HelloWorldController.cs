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
using System.Data.Common;
using WebApplication1.Service;
using Serilog;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {
        private readonly IConfiguration Configuration;
        private DbConnection _connection;
        private readonly DBService _dbService;


        readonly ILogger _log = Log.ForContext<HelloWorldController>();

        //public HelloWorldController(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public HelloWorldController(DBService dbService)
        {
            _dbService = dbService;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            string DBConnectString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
            IDbConnection _connection = new SqlConnection(DBConnectString);
            _connection.Open();


            IEnumerable<ZJFI_TempVM> model = _connection.Query<ZJFI_TempVM>("SELECT * FROM ZJFI_Temp");

            _connection.Close();

            return View(model);
        }

        public IActionResult Index2()
        {
            //DBService service = new DBService(Configuration);
            //DBService service = new DBService();


            IEnumerable<ZJFI_TempVM> model= _dbService.GetTemp();

            


            return View(model);
        }

        public IActionResult Create()
        {
            return View(new ZJFI_TempVM());

        }

        [HttpPost]
        public IActionResult Create(ZJFI_TempVM vm)
        {

            if (ModelState.IsValid)
            {

                string DBConnectString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
                IDbConnection _connection = new SqlConnection(DBConnectString);
                _connection.Open();



                //_connection.Execute(@"INSERT INTO ZJFI_Temp
                //                        (
                //                            site_ref,
                //                            [Desc],
                //                            WDate
                //                        )
                //                        VALUES
                //                        (
                //                            @site_ref,
                //                            @Desc,
                //                         @WDate
                //                        )", new { site_ref = vm.site_ref, Desc = "1", WDate = "2016-12-19" });


                vm.site_ref = "KENDEV";
                vm.Desc = "테스트";

                _connection.Execute(@"INSERT INTO ZJFI_Temp
                                    (
                                        site_ref,
                                        [Desc]
                                    )
                                    VALUES
                                    (
                                        @site_ref,
                                        @Desc
                                    )", vm);

                _connection.Close();
            }

            return RedirectToAction("index");

        }
    }
}
