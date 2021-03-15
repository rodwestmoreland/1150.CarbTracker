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
        private static string Username = string.Empty;
        private static string Password = string.Empty;
        private static string baseAddress = "https://localhost:44314/";
        static void Main(string[] args)
        {
            //Console.ReadKey()   ;
            //var newAccount = new SyncUserAccount();
            //newAccount.RegisterAccount();


            Token token = null;
           
            Username = "new@new.org";
            Password = "Password-1";

            token = GetAccessToken(Username, Password);

            if (!string.IsNullOrEmpty(token.AccessToken))
            {
              
            Console.WriteLine("Get food = 1 \nPost food = 2\n");
            var select = Console.ReadLine();
                
                    if (select == "1")
                    {
                        var getFood = new SyncAPIFoods();
                        getFood.GetFoods(token.AccessToken, baseAddress);

                    }
                    else
                    {

                        var addFood = new SyncAPIFoods();
                        addFood.AddFood(token.AccessToken, baseAddress);
                    }

            }
            else
            {
                Console.WriteLine(token.Error);
            }

            Console.ReadLine();
        }
        public static Token GetAccessToken(string username, string password)
        {
            Token token = new Token();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var RequestBody = new Dictionary<string, string>
                {
                {"grant_type", "password"},
                {"username", username},
                {"password", password},
                };
            var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(RequestBody)).Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var JsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<Token>(JsonContent);
                token.Error = null;
            }
            else
            {
                token.Error = "Not able to generate Access Token Invalid usrename or password";
            }
            return token;
        }
    }

    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string Error { get; set; }

    }
}
