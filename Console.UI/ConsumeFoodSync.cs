using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class ConsumeFoodSync
    {
        public void GetFoods()
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("https://localhost:44314/api/food"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
