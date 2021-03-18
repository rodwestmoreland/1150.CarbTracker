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
                string verifyInput;
                bool numCheck = true;
                Console.Write("Enter your last name: ");
                newAccount.LastName = Console.ReadLine();
                Console.Write("Enter your first name: ");
                newAccount.FirstName = Console.ReadLine();
                do
                {
                    Console.Write("Enter your Insulin to Carb Ratio: ");
                    verifyInput = Console.ReadLine();
                    if (double.TryParse(verifyInput, out double userInput))
                    {
                        newAccount.InsulinToCarbRatio = userInput;
                        numCheck = false;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Needs to be a number.\n\n");
                        numCheck = true; 
                    }

                } while (numCheck);

                
                do
                {
                    Console.Write("Enter your Correction factor: ");
                    verifyInput = Console.ReadLine();
                    if (double.TryParse(verifyInput, out double userInput))
                    {
                        newAccount.CorrectionFactor = userInput;
                        numCheck = false;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Needs to be a number.\n\n");
                        numCheck = true;
                    }

                } while (numCheck);

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");

                try
                {
                var result =    client.UploadString(baseUrl+"api/account/register",
                                JsonConvert.SerializeObject(newAccount));

                Console.WriteLine(result);

                }catch (WebException e)
                {
                    string response = e.Message.ToString();
                    Console.WriteLine($"\n\nServer returned an error: {response}\n");
                    Console.WriteLine("\n\nThe username might be in use or your password did not meet the strength requirements. \nPlease try again");
                    
                    Console.WriteLine("\nClick any key to continue");

                    Console.ReadKey();
                    Console.Clear();
                    UserCheck();
                }
            }
        }

        public void UserCheck()
        {
            Token token = null;
            string welcome = "\n\nWelcome to the Blood Sugar Tracker";
            Console.WriteLine(welcome);
            Console.Write("\n\nDo you want to register as a first time user? y/n ");

            string userInput = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine();
            // Consolidated code from here . . .
            if (userInput == "y") Console.WriteLine(welcome + " Please register as a user.\n\n");
            
            Console.Write("Enter email address: ");
            Username = Console.ReadLine();
            DisplayPrompt();
            Password = Console.ReadLine();

            if (userInput == "y") RegisterAccount(baseUrl, Username, Password);
            // . . . to here.

            token = Token.GetAccessToken(baseUrl, Username, Password);

            if (!string.IsNullOrEmpty(token.AccessToken))
            {
                Console.WriteLine($"{Username} logged in...\n\n");
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

        public void DisplayPrompt()
        {
            Console.Write("Enter a password (10 characters, upper, lower and special character): ");
        }
    }
}
