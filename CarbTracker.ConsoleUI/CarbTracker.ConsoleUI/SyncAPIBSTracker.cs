using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CarbTracker.ConsoleUI
{
    class SyncAPIBSTracker:HttpHandler
    {
        public void GetBS(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var apiResponse = client.GetAsync(baseAddress + "api/BloodSugarTracker").Result;

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

        public void AddBS(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var serializer = new JavaScriptSerializer();
            var payload = new BSType();

            payload.BSLevel = 100;
            payload.CarbsConsumed = 130;

            var serializedResult = serializer.Serialize(payload);

            var apiResponse = client.PostAsync(baseAddress + "api/BloodSugarTracker",
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

        public void UpdateBS(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var serializer = new JavaScriptSerializer();
            var payload = new BSType();

            payload.BSLevel = 110;
            payload.CarbsConsumed = 220;
           

            var serializedResult = serializer.Serialize(payload);

            var apiResponse = client.PutAsync(baseAddress + "api/BloodSugarTracker",
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
        public void DeleteBS(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var toDelete = 11;

            var apiResponse = client.DeleteAsync(baseAddress + "api/BloodSugarTracker/?BsLevelID=" + toDelete).Result;

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
