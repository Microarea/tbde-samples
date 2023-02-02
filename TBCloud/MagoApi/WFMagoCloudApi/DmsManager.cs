using MagoCloudApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagoCloudApi
{
    class DmsManager
    {
        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/dms/be");

        ////////////////////////////////////
        ////// RetriveDataServiceUrl ///////
        ////////////////////////////////////
        public string RetriveDmsUrl(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/MICRODMS");
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
        internal string GetHome(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.DmsServiceUrl == "") UrlSManager.DmsServiceUrl = RetriveDmsUrl(userData, DateTime.Now);
                    UrlSManager.DmsServiceUrl = RetriveDmsUrl(userData, DateTime.Now);
                    
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UrlSManager.DmsServiceUrl + "/dms/api/");
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
                    }
                    else
                        MessageBox.Show("Unable to retrive the DMS Home.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return string.Empty;
            }
        }

        internal string PostDmsSetting(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmsServiceUrl + "/dms/api/dmssettings/get/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
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
                            return strings.ToString();
                        }
                        else
                            MessageBox.Show("Unable to retrive the DmsSetting");
                    }
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
