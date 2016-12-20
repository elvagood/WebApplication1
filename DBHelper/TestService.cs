using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication1.Models;


namespace DBHelper
{
    public class TestService
    {
        private readonly string DBConnectString;

        public TestService()
        {
            DBConnectString = "Server=210.126.180.96;Database=SyteLine_KENDEV_App;uid=sa;pwd=ERProqkf*2016^";
        }

        public List<ZJFI_TempVM> GetTemp()
        {

        }
    }
}