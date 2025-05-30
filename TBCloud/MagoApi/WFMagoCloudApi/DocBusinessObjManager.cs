//using EnvDTE;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlTypes;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Policy;
using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml;
//using System.Xml.Linq;

namespace TbApiTester
{
   
    public class DocBusinessObjManager
    {
        public bool unattended = true;
        public string BONamespace = "ERP.SaleOrders";
        public string callerId = "12";
        public string interfaceToken;
        internal async Task<TClass> RunDocumentAsync<TClass>(UserData userData, string nameSpace, bool unattended, string callerId) where TClass : class, new()
        {
            JObject jObject = new JObject
            {
                ["ns"] = nameSpace,
                ["viewMode"] = unattended ? "BackGround" : "Foreground"
            };

            if (string.IsNullOrEmpty(UrlSManager.TbServerUrl))
            {
                UrlSManager urls = new UrlSManager();
                UrlSManager.TbServerUrl = urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER", true);
            }

            string requestUrl = "http://localhost:5000" + "/tbserver/api/tb/document/runDocument/";
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl))
            {
                request.Content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
                TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                TbApiTesterManager.PrepareHeaderServerInfo(request, userData, DateTime.Now);
                TbApiTesterManager.PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                try
                {
                    HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject responseObject = JObject.Parse(responseBody);

                        if (responseObject["success"]?.Value<bool>() == true && responseObject["component"] is JObject componentObj)
                        {
                            TClass val = new TClass();
                            dynamic dynamicVal = val; 
                            dynamicVal.NameSpace = nameSpace;
                            dynamicVal.Authorization = userData.Token;
                            dynamicVal.ServerInfo = "fvef";
                            dynamicVal.Id = componentObj["id"]?.ToString();
                            dynamicVal.Url = requestUrl;
                            dynamicVal.CallerId = callerId;
                            dynamicVal.Unattended = unattended;
                            dynamicVal.OnInitDocument();
                            dynamicVal.StartListening();
                            await dynamicVal.Ready; 

                            return val;
                        }
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Errore HTTP: {response.StatusCode}, Contenuto: {errorResponse}");
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error HTTP.", ex);
                }
            }
            return null;
        }
    }
}
    

