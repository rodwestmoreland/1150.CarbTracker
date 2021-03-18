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
        public void Run()
        {
            Console.Title = "Blood Sugar Carb Tracker";
            var userCheck = new SyncUserAccount();
            userCheck.UserCheck();
        } 
    }
}

