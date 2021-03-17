using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace CarbTracker.ConsoleUI
{
    public class SyncAPIMeals : HttpHandler
    {
        public void GetMeals(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var apiResponse = client.GetAsync(baseAddress + "api/meal").Result;

            if (apiResponse.IsSuccessStatusCode)
            {
                var JsonContent = apiResponse.Content.ReadAsStringAsync().Result;

                dynamic json = JsonConvert.DeserializeObject(JsonContent);

                int count = json.Count;

                Console.WriteLine("\n\n");
                Console.WriteLine($"{"     Meal ID",-20}" +
                    $"{"Meal Name",-16}" +
                    $"{"Total Carbs",15}");
                Console.Write(new String(' ', 5));
                Console.WriteLine(new String('-', 46));

                for (int i = 0; i < count; i++)
                {
                    if (json[i].TotalCarbs < 10)
                        Console.WriteLine(String.Format("     {0,-8} | {1,-25}   |  {2:F}",
                           json[i].MealId, json[i].MealName, json[i].TotalCarbs));
                    else
                        Console.WriteLine(String.Format("     {0,-8} | {1,-25}   | {2:F}",
                           json[i].MealId, json[i].MealName, json[i].TotalCarbs));
                }

                //Console.WriteLine("APIResponse : " + JsonContent.ToString());
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }
        }

        public void AddMeal(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var serializer = new JavaScriptSerializer();
            var payload = new MealType();

            Console.Write("Please enter the meal name: ");
            payload.MealName = Console.ReadLine();

            Console.Write("Please enter the number of carbs (whole number): ");
            payload.TotalCarbs = Convert.ToInt32(Console.ReadLine());

            var serializedResult = serializer.Serialize(payload);

            var apiResponse = client.PostAsync(baseAddress + "api/meal",
                                new StringContent(serializedResult,
                                                    Encoding.UTF8, "application/json"))
                                                    .Result;

            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("post = 200");
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }
        }


        public void UpdateMeal(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);
            var serializer = new JavaScriptSerializer();
            var payload = new MealType();
            payload.MealId = 11;
            payload.MealName = "yet another corndog";
            payload.TotalCarbs = 90;
            var serializedResult = serializer.Serialize(payload);
            var apiResponse = client.PutAsync(baseAddress + "api/meal",
                                new StringContent(serializedResult,
                                                    Encoding.UTF8, "application/json"))
                                                    .Result;
            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("post = 200");
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }
        }
        public void GetByName(string accessToken, string baseAddress)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            Console.WriteLine("Enter meal name");
            string name = Console.ReadLine();
            var apiResponse = client.GetAsync(baseAddress + "api/meal/?name=" + name).Result;
            if (apiResponse.IsSuccessStatusCode)
            {
                var JsonContent = apiResponse.Content.ReadAsStringAsync().Result;
                //Token Message = JsonConvert.DeserializeObject<Token>(JsonContent);
                Console.WriteLine("APIResponse : " + JsonContent.ToString());
                //Console.WriteLine("APIResponse : " + Message.ToString());
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }
        }

    
        public void DeleteMeal(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            GetMeals(accessToken, baseAddress);

            Console.WriteLine("\n\nEnter the meal ID you wish to delete: ");
            int toDelete = Convert.ToInt32(Console.ReadLine());

            var apiResponse = client.DeleteAsync(baseAddress + "api/meal/?meal="+toDelete).Result;

            if (apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Item deleted");
                Console.WriteLine("post = 200");
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }

        }
    }
}
