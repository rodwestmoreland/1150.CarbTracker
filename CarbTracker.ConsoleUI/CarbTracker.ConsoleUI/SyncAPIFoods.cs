using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    
    public class SyncAPIFoods:HttpHandler
    {
        public void GetFoods(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var apiResponse = client.GetAsync(baseAddress + "api/food").Result; 

            if (apiResponse.IsSuccessStatusCode)
            {
                var JsonContent = apiResponse.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(JsonContent);
                int count = json.Count;

                Console.WriteLine("\n\n");
                Console.WriteLine($"{"     Food",-25}" +
                    $"{"Serving In Ounces",-20}" +
                    $"{"Carbs", 5}");
                Console.Write(new String(' ',5));
                Console.WriteLine(new String('-',45));
                for(int i = 0; i < count; i++)
                    Console.WriteLine(String.Format("     {0,-17} |        {1:F}       | {2, 5}", 
                        json[i].Name, json[i].ServingInOunces, json[i].Carbs));
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }
        }

        public void AddFood(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization = 
                   new AuthenticationHeaderValue("Bearer", accessToken);
            
            var serializer = new JavaScriptSerializer();
            var payload = new FoodType();

            Console.Write("\nEnter the name of the meal: ");
            payload.Name = Console.ReadLine();

            Console.Write("\nEnter the number of carbohydrates: ");
            payload.Carbs = Console.ReadLine();

            Console.Write("\nEnter the serving size in ounces: ");
            payload.ServingInOunces = Console.ReadLine();

            Console.Write("\nEnter a short description of the meal: ");
            payload.Description = Console.ReadLine();


            var serializedResult = serializer.Serialize(payload);

            var apiResponse =   client.PostAsync(   baseAddress + "api/food", 
                                new StringContent(  serializedResult, 
                                                    Encoding.UTF8,"application/json"))
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
    }
}
