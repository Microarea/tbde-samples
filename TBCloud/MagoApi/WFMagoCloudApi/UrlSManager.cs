using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagoCloudApi
{
    internal class UrlSManager
    {
        public string RetriveUrl(UserData userData, DateTime operationDate, string urlName)
        {
            using (HttpClient client = new HttpClient())
            {
                //@@mmf
                string localUrl = "http://localhost:5000";
                if (userData.GwamUrl == string.Empty || userData.GwamUrl == "https://test-gwam.mago.cloud")
                    return localUrl;
                //@@mmf end
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + urlName);
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/TBSERVER");
                MagoCloudApiManager.PrepareHeaders(request, userData);

                HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                string resultVariable = "";
                if (jsonObject != null)
                {
                    resultVariable = jsonObject["Content"]?.ToString();
                }
                return  resultVariable;
            }
        }
       
        public static string TbServerUrl = System.String.Empty;
        // WebMethodsUrl = TbServerUrl (use the same service)
        public static string DataServiceUrl = System.String.Empty;
        public static string ReportingServiceUrl = System.String.Empty;
        public static string DmsServiceUrl = System.String.Empty;
    }
    
}
