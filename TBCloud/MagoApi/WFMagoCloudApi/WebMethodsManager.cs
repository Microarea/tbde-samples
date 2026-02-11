using TbApiTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TbApiTester
{
    class WebMethodsManager
    {

        public string requestTb { get; set; }
        public List<string> requestTbList = new List<string>();
        public List<string> responseTbList = new List<string>();
    

        //////Attention: if using Multicompany add CompanyId and Storecode in header Server-Info."
       /////"subscription":"{{subscription-key}}","gmtOffset":-60,"date":{ "day":26,"month":11,"year":2025},"companyId": 1,"StoreCode":""}


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
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                    TbApiTesterManager.PrepareHeaderServerInfo(request, userData, operationDate);
                    requestTb = $"{request.Method} {request.RequestUri}";
                    string jsonInString = PrepareOpeningDate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    requestTbList.Add($"CurrentOpeningDate_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {jsonInString}");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");
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
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                    TbApiTesterManager.PrepareHeaderServerInfo(request, userData, operationDate);
                    requestTb = $"{request.Method} {request.RequestUri}";
                    string jsonInString = PrepareCloseDate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    requestTbList.Add($"ClosingDateFiscalYear_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {jsonInString}");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");
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
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    requestTb = $"{request.Method} {request.RequestUri}";
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);

                    string jsonInString = PrepareDefSPCreate(request);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    requestTbList.Add($"DefaultSalesPricesCreate_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {jsonInString}");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");
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
        public string GetDefaultPrice(UserData userData, DateTime operationDate, long handle, string customer, string item, string uom, double quantity)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    requestTb = $"{request.Method} {request.RequestUri}";
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                    string jsonInString = PrepareGetDefaultPx(request, handle, customer, item, uom, quantity);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");

                    requestTbList.Add($"GetDefaultPrice_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {jsonInString}");

                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");
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

        public string PrepareGetDefaultPx(HttpRequestMessage request, long CurrHandle, string customer, string item, string uom, double quantity)
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
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveWebMethodsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    requestTb = $"{request.Method} {request.RequestUri}";
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                    string jsonInString = PrepareDefSPDispose(request, handle);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    requestTbList.Add($"DefaultSalesPricesDispose_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {jsonInString}");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");
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

        public bool UseLoginContext(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "")
                        UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/useLoginContext/");
                    requestTb = $"{request.Method} {request.RequestUri}";
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    TbApiTesterManager.PrepareHeaderServerInfo(request, userData, operationDate);
                    TbApiTesterManager.PrepareHeaderSnapshot(request, userData);

                    request.Content = new StringContent("{}", Encoding.UTF8, "application/json");
                    requestTbList.Add($"UseLoginContext_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {request.Content}");

                    var response = client.SendAsync(request).Result;
                    var responseBody = response.Content.ReadAsStringAsync().Result;

                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");

                    if (response.IsSuccessStatusCode)
                    {
                        return true; // oppure JObject.Parse(responseBody).ToString()
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (HttpRequestException e)
                {
                    return false;
                }
            }
        }
        public bool ReleaseLoginContext(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "")
                        UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/releaseLoginContext/");
                    requestTb = $"{request.Method} {request.RequestUri}";

                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    TbApiTesterManager.PrepareHeaderServerInfo(request, userData, operationDate);
                    TbApiTesterManager.PrepareHeaderSnapshot(request, userData);

                    request.Content = new StringContent("{}", Encoding.UTF8, "application/json");
                    requestTbList.Add($"UseLoginContext_[{DateTime.Now}] {request.Method} {request.RequestUri}\nBody: {request.Content}");

                    var response = client.SendAsync(request).Result;
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    responseTbList.Add($"[{DateTime.Now}] Status: {response}\n");

                    if (response.IsSuccessStatusCode)
                    {
                        var jObj = JObject.Parse(responseBody);
                        bool hasErrors = jObj["hasErrors"]?.Value<bool>() ?? false;
                        string message = jObj["messages"]?.FirstOrDefault()?["text"]?.ToString();

                        if (hasErrors)
                        {
                            MessageBox.Show(
                                message ?? "An unknown error occurred while releasing the login context.",
                                "Login Context Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return false;
                        }

                        return true;
                    }
                    else
                    {
                        MessageBox.Show(
                            $"HTTP error: {response.StatusCode}",
                            "Request Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return false;
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(
                        $"Network error: {e.Message}",
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }
        }
    }

}



