using MagoCloudApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagoCloudApi
{
    class WebMethodsManager
    {
        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/be");
        public string RetriveWebMethodsUrl(UserData userData, DateTime operationDate)
        {
           
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/TBSERVER");
                MagoCloudApiManager.PrepareHeaders(request, userData);

                HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                string resultVariable = "";
                if (jsonObject != null)
                {
                    resultVariable = jsonObject["Content"]?.ToString();
                }
                return UrlSManager.TbServerUrl = resultVariable;
            }
        }
        ////////////////////////////////////
        ////// Current Opening Date ////////
        ////////////////////////////////////

        public string CurrentOpeningDate(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    var server_info = JsonConvert.SerializeObject(new
                    {
                        subscription = userData.SubscriptionKey,
                        gmtOffset = -60,
                        date = new
                        {
                            day = operationDate.Day,
                            month = operationDate.Month,
                            year = operationDate.Year
                        }
                    });
                    request.Headers.TryAddWithoutValidation("Server-Info", server_info);
                    string jsonInString = PrepareOpeningDate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["retVal"]?.ToString();
                            return resultVariable;
                        }
                        else
                            return "CurrentOpeningDate error: unable to retrive the TbServer.";
                    }
                    else
                        return "CurrentOpeningDate error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "CurrentOpeningDate exception Caught: Message: " + e.Message;
                }
            }
        }
        public string PrepareOpeningDate(HttpRequestMessage request)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "ERP.Company.Dbl.CurrentOpeningDate",
                args = new
                {
                }
            });
            return (functionParams);
        }

          /////////////////////////////////////
         //// Closing Date of Fiscal Year ////
        /////////////////////////////////////
        public string ClosingDateFiscalYear(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    var server_info = JsonConvert.SerializeObject(new
                    {
                        subscription = userData.SubscriptionKey,
                        gmtOffset = -60,
                        date = new
                        {
                            day = operationDate.Day,
                            month = operationDate.Month,
                            year = operationDate.Year
                        }
                    });
                    request.Headers.TryAddWithoutValidation("Server-Info", server_info);
                    string jsonInString = PrepareCloseDate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["retVal"]?.ToString();
                            return resultVariable;
                        }
                        else
                            return "ClosingDateFiscalYear error: unable to retrive the TbServer.";
                    }
                    else
                        return "ClosingDateFiscalYear error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "ClosingDateFiscalYear exception Caught: Message: " + e.Message;
                }
            }
        }
        public string PrepareCloseDate(HttpRequestMessage request)
        {
            DateTime mydate = new DateTime(2021);
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "ERP.Company.Dbl.ClosingDateOfFiscalYear",
                args = new
                {
                        data = mydate,
                        result = "data"
                }
            });
            return (functionParams);
        }

          ////////////////////////////////////
         //// Default Sale PricesCreate  ////
        ////////////////////////////////////
        public long DefaultSalesPricesCreate(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    var server_info = JsonConvert.SerializeObject(new
                    {
                        subscription = userData.SubscriptionKey,
                        gmtOffset = -60,
                        date = new
                        {
                            day = operationDate.Day,
                            month = operationDate.Month,
                            year = operationDate.Year
                        }
                    });
                    request.Headers.TryAddWithoutValidation("Server-Info", server_info);
                    string jsonInString = PrepareDefSPCreate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            long resultVariable = jsonObject["retVal"].Value<long>();
                            return resultVariable;
                        }
                        else
                            return -1;
                    }
                    else
                        return -2;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                    return -3;
                }
            }
        }
        public string PrepareDefSPCreate(HttpRequestMessage request)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "ERP.PricePolicies.Components.DefaultSalePrices_Create",
                args = new
                {
                }
            });
            return (functionParams);
        }

          ////////////////////////////////////
         /////// Get Default Prices /////////
        ////////////////////////////////////
        public string GetDefaultPrice(UserData userData, DateTime operationDate, long handle , string customer , string item, string uom, double quantity )
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    var server_info = JsonConvert.SerializeObject(new
                    {
                        subscription = userData.SubscriptionKey,
                        gmtOffset = -60,
                        date = new
                        {
                            day = operationDate.Day,
                            month = operationDate.Month,
                            year = operationDate.Year
                        }
                    });
                    request.Headers.TryAddWithoutValidation("Server-Info", server_info);
                    string jsonInString = PrepareGetDefaultPx(request, handle, customer, item, uom, quantity);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["retVal"]?.ToString();
                            return resultVariable;
                        }
                        else
                            return "ClosingDateFiscalYear error: unable to retrive the TbServer.";
                    }
                    else
                        return "ClosingDateFiscalYear error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "ClosingDateFiscalYear exception Caught: Message: " + e.Message;
                }
            }
        }

        public string PrepareGetDefaultPx(HttpRequestMessage request, long CurrHandle, string customer , string item, string uom, double quantity)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "ERP.PricePolicies.Components.DefaultSalePrices_GetDefaultPrice",
                args = new
                {
                    handle = CurrHandle,
                    Customer = customer, 
                    Item = item,
                    UoM = uom,
                    Quantity = quantity 
                }
            });
            return (functionParams);
        }

          //////////////////////////////////////
         //// Default Sale Prices Dispose  ////
        //////////////////////////////////////
        public bool DefaultSalesPricesDispose(UserData userData, DateTime operationDate, long handle)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    var server_info = JsonConvert.SerializeObject(new
                    {
                        subscription = userData.SubscriptionKey,
                        gmtOffset = -60,
                        date = new
                        {
                            day = operationDate.Day,
                            month = operationDate.Month,
                            year = operationDate.Year
                        }
                    });
                    request.Headers.TryAddWithoutValidation("Server-Info", server_info);
                    string jsonInString = PrepareDefSPDispose(request, handle);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            bool resultVariable = false;
                            bool resOk = (bool)jsonObject["success"];
                            if (resOk)
                               resultVariable = (bool)jsonObject["retVal"];
                            return resultVariable;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        public string PrepareDefSPDispose(HttpRequestMessage request, long CurrHandle)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "ERP.PricePolicies.Components.DefaultSalePrices_Dispose",
                args = new
                {
                    handle = CurrHandle,
                }
            });
            return (functionParams);
        }
    }

}

