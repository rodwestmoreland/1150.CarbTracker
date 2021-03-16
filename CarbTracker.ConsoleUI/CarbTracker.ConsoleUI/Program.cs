using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UI();
            ui.Run();
        }

    }
}
