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
        private static string Username = string.Empty;
        private static string Password = string.Empty;
        private static string baseUrl = "https://localhost:44314/";

        public void Run()
        {
            Username = "new2@new.org";
            Password = "Password-1";
            var userAccount = new SyncUserAccount();
            // userAccount.RegisterAccount();
            Token token = null;

            token = Token.GetAccessToken(baseUrl, Username, Password);

            if (!string.IsNullOrEmpty(token.AccessToken))
            {
                var ops = new MenuOps(token.AccessToken, baseUrl);
                ops.AToken = token.AccessToken;
                ops.BaseUrl = baseUrl;
                MenuOps.MenuSelections();
            }
            else
            {
                Console.WriteLine(token.Error);
            }
            Console.WriteLine("nothing happened");

            Console.ReadLine();
        } 
    }
}

