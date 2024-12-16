using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace TbApiTester
{
   
    internal class UrlSManager
    {
        public string WebUrl { get; set; } = string.Empty;
        public string DevEnvUrl { get; set; } = string.Empty;
        public string MMSWebUrl { get; set; } = "http://localhost:60000/";
        public string MMSDevUrl { get; set; } = "http://localhost:5058/";

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
                WebUrl = isMMS ? MMSWebUrl : "http://localhost:60000";
                switch (buttonState)
                {
                    case GlobalSettings.ButtonState.DevEnv:
                        // Caso DevEnv: verifica GwamUrl e ritorna LocalUrl se necessario
                        if (userData.GwamUrl == string.Empty || userData.GwamUrl == "https://test-gwam.mago.cloud")
                        {
                            return DevEnvUrl;
                        }
                        break;

                    case GlobalSettings.ButtonState.Web:
                        // Caso Cloud: ritorna WebUrl se GwamUrl è uguale a "https://gwam.mago.cloud"
                        if (userData.GwamUrl == "https://gwam.mago.cloud")
                        {
                            return WebUrl;
                        }
                        break;

                    case GlobalSettings.ButtonState.Cloud:
                        if (userData.GwamUrl == "https://test-gwam.mago.cloud" || userData.GwamUrl == "https://gwam.mago.cloud")
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
                        return "Stato del bottone non riconosciuto";
                }

                return "Stato del bottone non gestito";
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
