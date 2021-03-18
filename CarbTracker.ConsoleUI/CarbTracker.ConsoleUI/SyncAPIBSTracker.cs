using Newtonsoft.Json;
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
    class SyncAPIBSTracker : HttpHandler
    {
        // Code for get all Blood Sugar from Database
        public void GetBS(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", accessToken);

            var apiResponse = client.GetAsync(baseAddress + "api/BloodSugarTracker").Result;

            if (apiResponse.IsSuccessStatusCode)
            {
                var JsonContent = apiResponse.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(JsonContent);
                int count = json.Count;

                Console.WriteLine("\n\n");
                Console.WriteLine($"{"     Food",-25}" +
                    $"{"Serving In Ounces",-20}" +
                    $"{"Carbs",5}");
                Console.Write(new String(' ', 5));
                Console.WriteLine(new String('-', 45));
                for (int i = 0; i < count; i++)
                    Console.WriteLine(String.Format("     {0,-17} |        {1:F}       | {2, 5}",
                        json[i].Name, json[i].ServingInOunces, json[i].Carbs));
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

            //InsulinToCarbRatio
            //Correction Factor
            var settingsApiResponse = client.GetAsync(baseAddress + "api/settings").Result;

            if (settingsApiResponse.IsSuccessStatusCode)
            {
                var JsonContent = settingsApiResponse.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(JsonContent);

                var insulinToCarbRatio = Convert.ToDouble(json.InsulinToCarbRatio);
                var correctionFactor = Convert.ToDouble(json.CorrectionFactor);



                Console.WriteLine($"Insulin to carb ratio: {insulinToCarbRatio}\n" +
                    $"Corrective Factor: {correctionFactor}" +
                    "\nPlease enter current blood sugar level: ");
                payload.BSLevel = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPlease enter total carbohydrates for meal: ");
                payload.CarbsConsumed = Convert.ToInt32(Console.ReadLine());


                var serializedResult = serializer.Serialize(payload);

                var apiResponse = client.PostAsync(baseAddress + "api/BloodSugarTracker",
                                    new StringContent(serializedResult,
                                                        Encoding.UTF8, "application/json"))
                                                        .Result;
                string rtn = "";
                double insulinForMeal = 0.0;
                if (apiResponse.IsSuccessStatusCode)
                {
                    double insulinForCarbs = payload.CarbsConsumed / insulinToCarbRatio;
                    if (payload.BSLevel <= 90)
                    {
                        rtn = "Blood Sugar is low, consume glucose to raise to appropriate range.\n";
                    }
                    else if(payload.BSLevel <=120)
                    {
                        rtn = "Blood Sugar is fine, no insulin needed for blood sugar correction at this time. Don't forget your insulin for carbs though.\n";
                    }
                    else
                    {
                        insulinForMeal = (payload.BSLevel - 120) / insulinToCarbRatio;
                        rtn = $"Blood Sugar is high. Take {insulinForMeal} units for Corrective Dose\n";
                    }

                    Console.WriteLine($"Insulin needed for meal is: {insulinForCarbs}\n" +
                        $" (Total Carbs in Meal / Insulin to Carb Ratio)\n" +
                        $"Total Meal Carbohydrates: {payload.CarbsConsumed}\n" +
                        $"Insulin to Carb Ratio: {insulinToCarbRatio}\n\n" +
                        $"{rtn}" +
                        $" (Blood Sugar Level - 120)/Correction Factor\n" +
                        $"Blood Sugar: {payload.BSLevel}\n" +
                        $"Correction Factor: {correctionFactor}");

                }
                else
                {
                    Console.WriteLine("APIResponse, Error : " + apiResponse.StatusCode);
                }
            }
            else
            {
                Console.WriteLine("API/Settings - APIResponsError : " + settingsApiResponse.StatusCode);
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

        public void GetSettings(string accessToken, string baseAddress)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var apiResponse = client.GetAsync(baseAddress);
        }
    }
}
