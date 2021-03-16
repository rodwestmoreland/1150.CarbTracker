using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class HttpHandler
    {
        public static HttpClientHandler handler = new HttpClientHandler();
        public static HttpClient client = new HttpClient(handler);
    }
}
