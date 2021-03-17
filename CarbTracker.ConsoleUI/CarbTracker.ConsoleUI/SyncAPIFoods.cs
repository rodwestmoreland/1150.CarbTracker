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
                
                Console.WriteLine("APIResponse : " + JsonContent.ToString());
                
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

            payload.Name =          "hotdog";
            payload.Carbs =         "3";
            payload.ServingInOunces = "7.2";
            payload.Description =   "bun and weenie";

            
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
