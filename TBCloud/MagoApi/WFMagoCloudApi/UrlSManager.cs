using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextManager.Interop;

namespace MagoCloudApi
{
    internal class UrlSManager
    {

        public string WebUrl = string.Empty;
        public string LocalUrl = string.Empty;
        public string MMSlocalUrl = "http://localhost:5058/mymagostudio-service/";
        //public string MMSlocalUrl = "http://localhost:5058/mymagostudio-service/";
        public string RetriveUrl(UserData userData, DateTime operationDate, string urlName, bool isMMS = false)
        {
            using (HttpClient client = new HttpClient())
            {
                //@@mmf
                LocalUrl = (isMMS) ? MMSlocalUrl : "http://localhost:5000";
                if (userData.GwamUrl == string.Empty || userData.GwamUrl == "https://test-gwam.mago.cloud")
                    return LocalUrl;
                //@@mmf end
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + urlName);
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/TBSERVER");
                MagoCloudApiManager.PrepareHeaders(request, userData, DateTime.Now);

                HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                string resultVariable = "";
                if (jsonObject != null)
                {
                    resultVariable = jsonObject["Content"]?.ToString();
                }
                return resultVariable;
            }
        }

        public static string TbServerUrl = System.String.Empty;
        // WebMethodsUrl = TbServerUrl (use the same service)
        public static string DataServiceUrl = System.String.Empty;
        public static string ReportingServiceUrl = System.String.Empty;
        public static string DmsServiceUrl = System.String.Empty;
        public static string TbFsServiceUrl = System.String.Empty;
        public static string DmMMSUrl = System.String.Empty;
        public static string EnumsTableUrl = System.String.Empty;

    }

}
