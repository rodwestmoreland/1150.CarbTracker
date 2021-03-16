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
    
    public class SyncAPIMeals:HttpHandler
    {
        public void GetMeals(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

        var apiResponse = client.GetAsync(baseAddress + "api/meal").Result;

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

        public void AddMeal(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization = 
                   new AuthenticationHeaderValue("Bearer", accessToken);
            
            var serializer = new JavaScriptSerializer();
            var payload = new MealType();

            payload.MealName =  "another corndog";
            payload.TotalCarbs = 30;

            var serializedResult = serializer.Serialize(payload);

            var apiResponse =   client.PostAsync(   baseAddress + "api/meal", 
                                new StringContent(  serializedResult, 
                                                    Encoding.UTF8,"application/json"))
                                                    .Result;

            //var whatSent = serializer.Deserialize<FoodType>(serializedResult);

            if (apiResponse.IsSuccessStatusCode)
            {
                //var JsonContent = apiResponse.Content.ReadAsStringAsync().Result;
                Console.WriteLine("post = 200");
            }
            else
            {
                Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
            }

        }
    }
}
