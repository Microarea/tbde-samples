
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagoCloudApi
{
    class DataServiceManager
    {
        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/be");
        ////////////////////////////////////
        ////// RetriveDataServiceUrl ///////
        ////////////////////////////////////
        public string RetriveDataServiceUrl(UserData userData, DateTime operationDate)
        {

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/REPORTSERVICE");
                MagoCloudApiManager.PrepareHeaders(request, userData);
                HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                string resultVariable = "";
                if (jsonObject != null)
                {
                    resultVariable = jsonObject["Content"]?.ToString();
                   
                }
                return UrlSManager.DataServiceUrl = resultVariable;
            }
        }
        public string PrepareDSParam(HttpRequestMessage request)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                
            });
            return (functionParams);
        }
        internal string GetData(UserData userData, string selectionType, string nameSpace, ref bool bOk)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.DataServiceUrl == "") UrlSManager.DataServiceUrl = RetriveDataServiceUrl(userData, DateTime.Now);
                    UrlSManager.DataServiceUrl = RetriveDataServiceUrl(userData, DateTime.Now);
                    StringBuilder builder = new StringBuilder();
                    string GetUrl = UrlSManager.DataServiceUrl + "/data-service/getdata/" + nameSpace + '/' + selectionType;
                    //if (reloadCaches)
                    GetUrl += "?forcedRefresh=true";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, GetUrl );
                    MagoCloudApiManager.PrepareHeaders(request,userData);
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
                            return "data is no longer valid.";
                    }
                    else
                        return "Unable to retrive the data.\nMake sure you have written the Namespace correctly.";
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return nameSpace + "Unable to retrive the data.";
            }
        }
       
        internal string GetVersion(UserData userData)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UrlSManager.DataServiceUrl + "/data-service/api/assemblyversion");
                        MagoCloudApiManager.PrepareHeaders(request, userData);
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
