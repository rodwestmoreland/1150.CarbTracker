using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class Token:HttpHandler
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string Error { get; set; }

        public static Token GetAccessToken(string baseUrl, string userName, string password)
        {
            Token token = new Token();
            var RequestBody = new Dictionary<string, string>
                {
                {"grant_type", "password"},
                {"username", userName},
                {"password", password},
                };
            var tokenResponse = client.PostAsync(baseUrl + "token", 
                                new FormUrlEncodedContent(RequestBody)).Result;

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
}
