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
        public void RegisterAccount(string baseUrl, string userName, string password)
        {
            using (var client = new WebClient())
            {
                var newAccount = new UserAccount();
                newAccount.Email = userName;
                newAccount.Password = password;
                newAccount.ConfirmPassword = password;
                newAccount.LastName = "doe";
                newAccount.FirstName = "bill";
                newAccount.InsulinToCarbRatio = 1.0;
                newAccount.CorrectionFactor = 2.0;

                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result =    client.UploadString(baseUrl+"/api/account/register",
                                JsonConvert.SerializeObject(newAccount));
              
                Console.WriteLine(result);
            }
        }
    }
}
