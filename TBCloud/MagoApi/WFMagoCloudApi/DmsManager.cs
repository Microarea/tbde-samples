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
        public string requestDms { get; set; }
        public class DmsAttachmentsResponse
        {
            public int Result { get; set; }
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public List<DmsAttachmentItem> Content { get; set; } = new();
        }

        public class DmsAttachmentItem
        {
            public string Name { get; set; }
            public string ERPPrimaryKeyValue { get; set; }
            public string ERPDocNamespace { get; set; }
            public string ERPTBGuid { get; set; }
            public string ArchivedDocId { get; set; }


        }
        internal string GetHome(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmsServiceUrl == "") UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, UrlSManager.DmsServiceUrl + "/dms/api/");
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    requestDms = $"{request.Method} {request.RequestUri}"; ;
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
                    if (UrlSManager.DmsServiceUrl == "") UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmsServiceUrl + "/dms/api/dmssettings/get/");
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    requestDms = $"{request.Method} {request.RequestUri}";
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
                    if (string.IsNullOrEmpty(UrlSManager.DmsServiceUrl))
                        UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/attach/getbinary";


                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    var requestBody = new { archivedocid = archiveDocId };
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                    requestDms = $"{request.Method} {request.RequestUri}";
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
                    if (string.IsNullOrEmpty(UrlSManager.DmsServiceUrl))
                        UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/attach/binarycontent";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
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
                    requestDms = $"{request.Method} {request.RequestUri}";
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
                    if (string.IsNullOrEmpty(UrlSManager.DmsServiceUrl))
                        UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/archive/binarycontent";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    requestDms = $"{request.Method} {request.RequestUri}";
                    // Nomi campi ESATTAMENTE come li legge il server
                    var jData = new JObject
                    {
                        ["fileName"] = fileName,
                        ["content"] = contentBase64,
                        ["Description"] = fileName,
                        ["CollectionId"] = 1,
                        ["FreeTags"] = "",
                        ["BookmarkList"] = JValue.CreateNull()
                    };

                    string json = jData.ToString(Formatting.None);
                    Console.WriteLine("JSON inviato al DMS:");
                    Console.WriteLine(json);

                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.SendAsync(
                        request,
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None);

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
        public async Task<List<DmsAttachmentItem>> GetAttachmentsAsync(UserData userData,string docnamespace,string strdockey, int filterType)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();

                    if (string.IsNullOrEmpty(UrlSManager.DmsServiceUrl))
                        UrlSManager.DmsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MICRODMS/");

                    string requestUrl = UrlSManager.DmsServiceUrl + "/dms/api/attach/getattachments";

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    requestDms = $"{request.Method} {request.RequestUri}";
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    var requestBody = new
                    {
                        docnamespace = docnamespace,
                        strdockey = strdockey,
                        filterType = filterType
                    };

                    request.Content = new StringContent(
                        JsonConvert.SerializeObject(requestBody),
                        Encoding.UTF8,
                        "application/json");

                    HttpResponseMessage response = await client.SendAsync(
                        request,
                        HttpCompletionOption.ResponseContentRead,
                        CancellationToken.None);

                    string raw = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"DMS error {response.StatusCode}: {raw}");
                    }

                    var parsed = JsonConvert.DeserializeObject<DmsAttachmentsResponse>(raw);

                    if (parsed == null)
                        throw new Exception("Impossibile deserializzare la risposta del DMS.");

                    if (parsed.ErrorCode != 0)
                        throw new Exception($"DMS business error {parsed.ErrorCode}: {parsed.ErrorMessage}");

                    return parsed.Content ?? new List<DmsAttachmentItem>();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Errore in GetAttachmentsAsync: {ex.Message}", ex);
                }
            }
        }
    }
}


