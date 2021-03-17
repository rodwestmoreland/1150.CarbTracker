using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class SyncUserAccount
    {
        private static string Username = string.Empty;
        private static string Password = string.Empty;
        private static string baseUrl = "https://localhost:44314/";

        public void RegisterAccount(string baseUrl, string userName, string password)
        {
            using (var client = new WebClient())
            {
                var newAccount = new UserAccount();
                newAccount.Email = userName;
                newAccount.Password = password;
                newAccount.ConfirmPassword = password;
                newAccount.LastName = "doe";
                newAccount.FirstName = "bill";
                newAccount.InsulinToCarbRatio = 1.0;
                newAccount.CorrectionFactor = 2.0;

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString(baseUrl + "api/account/register",
                                JsonConvert.SerializeObject(newAccount));

                Console.WriteLine(result);
            }
        }

        public void UserCheck()
        {
            Token token = null;

            Console.Write("Do you want to register as a first time user? y/n ");
            string userInput = Console.ReadLine().ToLower();

            // Consolidated code from here . . .
            if (userInput == "y") Console.WriteLine("Welcome. Please log in");
            
            Console.Write("Enter email address: ");
            Username = Console.ReadLine();
            DisplayPrompt();
            Password = Console.ReadLine();

            if (userInput == "y") RegisterAccount(baseUrl, Username, Password);
            // . . . to here.
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
            //}
        }

        public void DisplayPrompt()
        {
            Console.Write("Enter a password (10 characters, upper, lower and special character): ");
        }
    }
}
