using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class UI
    {
        //private static string Username = string.Empty;
        //private static string Password = string.Empty;
        //private static string baseUrl = "https://localhost:44314/";

        public void Run()
        {
            var userCheck = new SyncUserAccount();
            userCheck.UserCheck();
        } 
    }
}

