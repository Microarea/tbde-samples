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

namespace TbApiTester
{
    class DmsManager
    {
        ////// RetriveDataServiceUrl ///////
        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/dms/be");

        ////////////////////////////////////
        ////// RetriveDataServiceUrl ///////
        ////////////////////////////////////
        //public string RetriveDmsUrl(UserData userData, DateTime operationDate)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/MICRODMS");
        //        TbApiTesterManager.PrepareHeaders(request, userData);

        //        HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
        //        string responseBody = response.Content.ReadAsStringAsync().Result;
        //        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
        //        string resultVariable = "";
        //        if (jsonObject != null)
        //        {
        //            resultVariable = jsonObject["Content"]?.ToString();

        //        }
        //        return UrlSManager.DataServiceUrl = resultVariable;
        //    }
        //}
        internal string GetHome(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmsServiceUrl == "") UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS");
                    //if (UrlSManager.DmsServiceUrl == "") UrlSManager.DmsServiceUrl = RetriveDmsUrl(userData, DateTime.Now);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UrlSManager.DmsServiceUrl + "/dms/api/");
                    //TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
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
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");
                    //UrlSManager.DmsServiceUrl = RetriveDmsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmsServiceUrl + "/dms/api/dmssettings/get/");
                    //TbApiTesterManager.PrepareHeaders(request, userData,DateTime.Now);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
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

        internal async Task<string> GetBinary(UserData userData, string archiveDocId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (string.IsNullOrEmpty(UrlSManager.TbServerUrl))
                        UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/attach/getbinary";
                    string localrequestUrl = "http://localhost:5000/dms/api/attach/getbinary";
                    string localrequestUrlWeb = userData.GwamUrl+"/dms/api/attach/getbinary";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, localrequestUrlWeb);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    // Corpo della richiesta con il valore dinamico
                    var requestBody = new { archivedocid = archiveDocId };
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);

                    if (response.IsSuccessStatusCode)
                    {
                        string contentBase64 = await response.Content.ReadAsStringAsync();
                        return contentBase64;
                    }
                    else
                    {
                        return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                    }
                }
                catch (Exception e)
                {
                    return $"Exception: {e.Message}";
                }
            }
        }

        internal async Task<string> AttachBinarycontent(UserData userData, string contentBase64, string fileName, string erpTbGuid, string erpDocNs, string erpPKV)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (string.IsNullOrEmpty(UrlSManager.TbServerUrl))
                        UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/attach/binarycontent";
                    string localrequestUrl = userData.GwamUrl + "/dms/api/attach/binarycontent";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, localrequestUrl);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    var requestBody = new
                    {
                        content = contentBase64,
                        Name = fileName,
                        CollectionId = 1,
                        Description = fileName,
                        FreeTags = "",
                        ERPTBGuid = erpTbGuid,
                        ERPDocNamespace = erpDocNs,
                        ERPPrimaryKeyValue = erpPKV,
                        BookmarkList = ""
                    };

                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                    }
                }
                catch (Exception e)
                {
                    return $"Exception: {e.Message}";
                }
            }
        }


        internal async Task<string> ArchiveBinarycontent(UserData userData, string contentBase64, string fileName)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (string.IsNullOrEmpty(UrlSManager.TbServerUrl))
                        UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/archive/binarycontent";
                    //string localrequestUrl = "http://localhost:5020/dms/api/archive/binarycontent";
                    string localrequestUrl = userData.GwamUrl + "/dms/api/archive/binarycontent";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, localrequestUrl);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    var requestBody = new
                    {
                        CollectionId = 1,
                        Description = fileName,//Modificare
                        FreeTags = "",
                        BookmarkList = ""
                    };

                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return $"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
                    }
                }
                catch (Exception e)
                {
                    return $"Exception: {e.Message}";
                }
            }
        }
    }
}


