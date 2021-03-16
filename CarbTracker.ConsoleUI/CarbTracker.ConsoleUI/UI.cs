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
            //MenuOps.MenuSelections();

            if (!string.IsNullOrEmpty(token.AccessToken))
            {
                var ops = new MenuOps(token.AccessToken, baseUrl);
                ops.AToken = token.AccessToken;
                ops.BaseUrl = baseUrl;
                MenuOps.MenuSelections();

                //Console.WriteLine("token good");
                //Console.WriteLine("Get food = 1 \nPost food = 2\n");
                //var select = Console.ReadLine();

                //if (select == "1")
                //{
                //    var getFood = new SyncAPIFoods();
                //    getFood.GetFoods(token.AccessToken, baseUrl);

                //}
                //else
                //{

                //    var addFood = new SyncAPIFoods();
                //    addFood.AddFood(token.AccessToken, baseUrl);
                //}

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

