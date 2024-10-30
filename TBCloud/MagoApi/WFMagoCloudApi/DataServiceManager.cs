
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagoCloudApi
{
    class DataServiceManager
    {
        public string requestDs { get; set; }
       
        ////// RetriveDataServiceUrl ///////

        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/be");
        ////////////////////////////////////
        ////// RetriveDataServiceUrl ///////
        ////////////////////////////////////
        //public string RetriveDataServiceUrl(UserData userData, DateTime operationDate)
        //{
        //     using (HttpClient client = new HttpClient())
        //     {
        //         HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/DATASERVICE");
        //         MagoCloudApiManager.PrepareHeaders(request, userData);
        //         HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
        //         string responseBody = response.Content.ReadAsStringAsync().Result;
        //         JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
        //         string resultVariable = "";
        //         if (jsonObject != null)
        //         {
        //             resultVariable = jsonObject["Content"]?.ToString();
        //         }
        //         return UrlSManager.DataServiceUrl = resultVariable;
        //     }
        //}
        public string PrepareDSParam(HttpRequestMessage request)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                
            });
            return (functionParams);
        }
        internal string GetData(UserData userData, string selectionType, string nameSpace, ref bool bOk, string filterVal = null, string argsVal = null)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DataServiceUrl == "")
                    {
                        UrlSManager.DataServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/DATASERVICE");
                    }

                    // Costruzione della URL base
                    StringBuilder GetUrl = new StringBuilder(UrlSManager.DataServiceUrl + "/data-service/getdata/" + nameSpace + '/' + selectionType);

                    // Aggiungi `filterVal` alla URL come parametro di query, se specificato
                    if (!string.IsNullOrEmpty(filterVal))
                    {
                        GetUrl.Append($"?filter={Uri.EscapeDataString(filterVal)}");
                    }

                    // Aggiungi `argsVal` alla URL come parametro di query, se specificato
                    if (!string.IsNullOrEmpty(argsVal))
                    {
                        GetUrl.Append(string.IsNullOrEmpty(filterVal) ? "?" : "&");
                        GetUrl.Append($"args={Uri.EscapeDataString(argsVal)}");
                    }

                    // Aggiungi `forcedRefresh` per forzare l'aggiornamento delle cache
                    GetUrl.Append((string.IsNullOrEmpty(filterVal) && string.IsNullOrEmpty(argsVal)) ? "?" : "&");
                    GetUrl.Append("forcedRefresh=true");

                    // Configura la richiesta HTTP
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetUrl.ToString());

                    MagoCloudApiManager.PrepareHeaderAutorization(request, userData);
                    requestDs = UrlSManager.DataServiceUrl + "/data-service/getdata/" + nameSpace + '/' + selectionType;
                   

                    // Esegui la richiesta
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        StringBuilder strings = new StringBuilder();
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
                            strings.AppendLine(jsonObject.ToString());
                            bOk = true;
                            return strings.ToString();
                        }
                        else
                        {
                            return "Data is no longer valid.";
                        }
                    }
                    else
                    {
                        return "Unable to retrieve the data.\nMake sure you have written the Namespace correctly.";
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return $"{nameSpace} - Unable to retrieve the data.";
            }
        }

        //------- GetEnumsTable is implemented in DmMMsManager

        internal string GetVersion(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DataServiceUrl == "") UrlSManager.DataServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/DATASERVICE");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UrlSManager.DataServiceUrl + "/data-service/api/assemblyversion");
                    MagoCloudApiManager.PrepareHeaderAutorization(request, userData);
                    requestDs = UrlSManager.DataServiceUrl + "/data-service/api/assemblyversion";
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            return jsonObject.ToString();
                        }
                        else
                            MessageBox.Show("data is no longer valid.");
                    }
                    else
                        MessageBox.Show("Unable to retrive the data.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return string.Empty;
            }
        }
    }
}
