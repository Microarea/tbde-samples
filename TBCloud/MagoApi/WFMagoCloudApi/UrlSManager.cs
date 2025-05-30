using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;
using static System.Net.WebRequestMethods;


namespace TbApiTester
{
   
    internal class UrlSManager
    {
        public string WebUrl { get; set; } = string.Empty;
        public string DevEnvUrl { get; set; } = string.Empty;
        public string MMSWebUrl { get; set; } = "http://localhost:60000/";
        public string MMSDevUrl { get; set; } = "http://localhost:5000/";

        //public UrlSManager(bool isCloud)
        //{
        //    m_IsCloud = isCloud;
        //}
        public string RetriveUrl(UserData userData, DateTime operationDate, string urlName, bool isMMS = false)
        {
            var buttonState = GlobalSettings.CurrentButtonState;

            using (HttpClient client = new HttpClient())
            {
                DevEnvUrl = isMMS ? MMSDevUrl : "http://localhost:5000";
                WebUrl = isMMS ? MMSWebUrl : MMSWebUrl.TrimEnd('/'); 
                switch (buttonState)
                {
                    case GlobalSettings.ButtonState.DevEnv:
                        if (userData.GwamUrl == string.Empty || userData.GwamUrl == "https://test-gwam.mago.cloud")
                        {
                            return DevEnvUrl;
                        }
                        break;

                    case GlobalSettings.ButtonState.Web:
                        if (userData.GwamUrl != null | userData.GwamUrl != string.Empty)
                        {
                            return WebUrl;
                        }
                        break;

                    case GlobalSettings.ButtonState.Cloud:
                        if (userData.GwamUrl != null | userData.GwamUrl != string.Empty)
                        {
                            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + urlName);
                            TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);   

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
                        break;

                    default:
                        return "I don't recognize the environment";
                }

                return "Error";
            }
        }

        // Proprietà statiche
        public static string TbServerUrl { get; set; } = string.Empty;
        public static string DataServiceUrl { get; set; } = string.Empty;
        public static string ReportingServiceUrl { get; set; } = string.Empty;
        public static string DmsServiceUrl { get; set; } = string.Empty;
        public static string TbFsServiceUrl { get; set; } = string.Empty;
        public static string AccountManagerUrl { get; set; } = string.Empty;
        public static string DmMMSUrl { get; set; } = string.Empty;
        public static string EnumsTableUrl { get; set; } = string.Empty;
        public static string CurrentButtonState { get; set; }
    }
}
