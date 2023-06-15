﻿using MagoCloudApi;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagoCloudApi
{
    public class MA_CustSupp
    {
        public static string TableName = "MA_CustSupp";

        public int CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string CompanyName { get; set; }
        public string ISOCountryCode { get; set; }
    }

    public class TableData
    {
        public string TableName { get; set; } = string.Empty;
        public object[] Keys { get; internal set; }
        public object Data { get; set; } = null;
    }

    class DmMMSManager
    {
        internal string GetDmMMSServiceVersion(UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + "DataManager/version");
                    MagoCloudApiManager.PrepareHeaders(request, userData);

                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    TbResponse tbResponse = new TbResponse();
                    if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(responseBody))
                    {
                        JObject data = JsonConvert.DeserializeObject<JObject>(responseBody);
                        tbResponse.ReturnValue = data["Build"]?.ToString();
                        tbResponse.PlainResult = responseBody;
                        tbResponse.Success = true;
                    }
                    return (string)tbResponse.ReturnValue;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return string.Empty;
            }
        }
        public async Task<TbResponse> Schema(UserData userData, string tableName) => await PostOnlyTableName(userData, DateTime.Now, tableName, "schema");
        public async Task<TbResponse> Prototype(UserData userData, string tableName) => await PostOnlyTableName(userData, DateTime.Now, tableName, "prototype");
        public async Task<TbResponse> PostOnlyTableName(UserData userData, DateTime operationDate, string tableName, string call)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + $"DataManager/{call}?tableName={tableName}");
                    MagoCloudApiManager.PrepareHeaders(request, userData);

                    TbResponse tbResponse = new TbResponse();
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string funResponse = await response.Content.ReadAsStringAsync();
                   
                    tbResponse.StatusCode = (int)response.StatusCode;
                    if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(funResponse))
                    {
                        JObject data = JsonConvert.DeserializeObject<JObject>(funResponse);
                        tbResponse.ReturnValue = data["data"]["Name"]?.ToString();
                        tbResponse.PlainResult = funResponse;
                        
                        tbResponse.Success = true;
                        return tbResponse;
                    }
                    //using (var response = await client.SendAsync(request))
                    //{
                    //    AssignTbResponse(response, tbResponse);
                    //}
                    //return tbResponse;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return null;
            }
        }
        //// it returns number of record contained accoringly query parameter_______________________________________________
        public async Task<TbResponse> Count(UserData userData, Query query) => await PostWithQuery(userData, query, "count");
        //// It selects data from database acconrdingly a particular query____________________________________________________
        public async Task<TbResponse> Select(UserData userData, Query query) => await PostWithQuery(userData, query, "select");

        public async Task<TbResponse> PostWithQuery(UserData userData, Query query, string call)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + $"DataManager/{call}");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                  
                    var queryParam = JsonConvert.SerializeObject(query);
                    request.Content = new StringContent(content: queryParam, encoding: Encoding.UTF8, mediaType: "application/json");
                    TbResponse tbResponse = new TbResponse();
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    
                    await AssignTbResponse(response, tbResponse);
                    return tbResponse;

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return null;
            }
        }
        //// it returns number of record contained accoringly query parameter________________________________________________________________
        public async Task<TbResponse> SelectAllByKey(UserData userData,  TableData tableData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + $"DataManager/selectAllByKey");

                    return await CallWithTableData(userData, tableData, request);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return null;
            }
        }

        public async Task<bool> Exists(UserData userData, TableData tableData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + $"DataManager/exists");

                    TbResponse response = await CallWithTableData(userData, tableData, request);
                    return response.Success == true && (response.ReturnValue.ToString().Equals("true", StringComparison.InvariantCultureIgnoreCase));
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return false;
            }
        }

        //// It adds a new record into table________________________________________________________________________________________
        public async Task<TbResponse> Add(UserData userData, TableData tableData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, UrlSManager.DmMMSUrl + $"DataManager/add");

                    TbResponse response = await CallWithTableData(userData, tableData, request);

                    return response;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }

                return null;
            }
        }



        public async Task<TbResponse> Update(UserData userData, TableData tableData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, UrlSManager.DmMMSUrl + $"DataManager/update");
                    
                    return await CallWithTableData(userData, tableData, request);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return null;
            }

        }
        //// It gets next id and returns it___________________________________________________________________________________________
        public async Task<TbResponse> GetNextID(UserData userData, string numbererKey, bool consumeIt = false)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.DmMMSUrl + $"DataManager/getNextId");
                    MagoCloudApiManager.PrepareHeaders(request, userData);

                    var nrData = JsonConvert.SerializeObject(new
                    {
                        numbererKey = numbererKey,
                        consumeIt = consumeIt
                    });
                    request.Content = new StringContent(content: nrData, encoding: Encoding.UTF8, mediaType: "application/json");
                    TbResponse tbResponse = new TbResponse();
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    await AssignTbResponse(response, tbResponse);
                    return tbResponse;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return null;
            }
        }

        //// It deletes a record from table______________________________________________________________________________________________
        public async Task<bool> Delete(UserData userData, TableData tableData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.DmMMSUrl == "")
                        UrlSManager.DmMMSUrl = Urls.RetriveUrl(userData, DateTime.Now, "/MYMAGOSTUDIO", true);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, UrlSManager.DmMMSUrl + $"DataManager/delete");
                    TbResponse response = await CallWithTableData(userData, tableData, request);
                    return response.Success == true && (response.ReturnValue.ToString().Equals("true", StringComparison.InvariantCultureIgnoreCase));
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0}", e.Message);
                }
                return false;
            }
        }

        public async Task<TbResponse> CallWithTableData(UserData userData, TableData tableData, HttpRequestMessage request)
        {
            using (HttpClient client = new HttpClient())
            {
                var param = JsonConvert.SerializeObject(tableData);
                request.Content = new StringContent(content: param, encoding: Encoding.UTF8, mediaType: "application/json");
                MagoCloudApiManager.PrepareHeaders(request, userData);

                TbResponse tbResponse = new TbResponse();
                HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                await AssignTbResponse(response, tbResponse);

                return tbResponse;
            }
        }

        private async Task AssignTbResponse(HttpResponseMessage response, TbResponse tbResponse)
        {
            string funResponse = await response.Content.ReadAsStringAsync();
            tbResponse.StatusCode = (int)response.StatusCode;
            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(funResponse))
            {
                JObject data = JsonConvert.DeserializeObject<JObject>(funResponse);
                tbResponse.ReturnValue = data["data"]?.ToString();
                tbResponse.PlainResult = funResponse;
                tbResponse.Success = true;
            }
        }
    }
}


