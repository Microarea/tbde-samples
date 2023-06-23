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
using System.Xml;
using System.Xml.Linq;

namespace MagoCloudApi
{
    internal class RsManager
    {

        ////////     RetriveRsUr      ////////

        ////Uri RsUrl = new Uri("https://develop.mago.cloud/13/be");

        //////////////////////////////////////
        ////////     RetriveRsUr      ////////
        //////////////////////////////////////
        //public string RetriveRsUrl(UserData userData, DateTime operationDate)
        //{

        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/REPORTSERVICE");
        //        MagoCloudApiManager.PrepareHeaders(request, userData);
               
        //        HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
        //        string responseBody = response.Content.ReadAsStringAsync().Result;
        //        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
        //        string resultVariable = "";
        //        if (jsonObject != null)
        //        {
        //            resultVariable = jsonObject["Content"]?.ToString();
        //        }
        //        return UrlSManager.DmsServiceUrl = resultVariable;
        //    }
        //}
        public string GetXmlData( UserData userData, DateTime operationDate, int btn =0)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/REPORTSERVICE");
                    //if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = RetriveRsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.ReportingServiceUrl + "/rs/xmldata");
                    MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);

                    string jsonInString = "";
                    if (btn == 0)
                        jsonInString = PrepareItems(request);
                    else if (btn == 1)
                        jsonInString = PrepareAddressBook(request);

                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                       
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            if (!(responseBody.Length == 0))
                            {
                                XDocument doc = XDocument.Parse(responseBody);
                                return doc.ToString();
                            }
                            else
                            {
                                return "Response body is empty.";
                            }
                        }
                        else
                        return "ReportingService-GetXmlData error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "ReportingService-GetXmlData exception Caught: Message: " + e.Message;
                }

            }
        }
        public string PrepareItems(HttpRequestMessage request )
        {
            string functionParams = JsonConvert.SerializeObject(new
            {
                namespaces = new[] 
                {"ERP.Items.Items.wrm"},
                arguments = new[]
                { new { name = "w_CodeStart", value = "A"},
                  new { name = "w_CodeEnd", value = "B"} 
                }
            });
            //var functionParams = "{\"namespaces\":[\"ERP.Items.Items.wrm\"],\"arguments\":[{ \"name\":\"w_CodeStart\",\"value\":\"A\"},{ \"name\":\"w_CodeEnd\",\"value\":\"B\"}]}";
            return (functionParams);
        }

        public string PrepareAddressBook(HttpRequestMessage request)
        {
            string functionParams = JsonConvert.SerializeObject(new
            {
                namespaces = new[] {"ERP.CustomersSuppliers.CustomersAddressBook.wrm"},
                arguments = new[] 
                { new { name = "w_FromCustomer", value = "0001" },
                  new { name = "w_ToCustomer", value = "0009" }
                }
            });
            //var functionParams = "{\"namespaces\":[\"ERP.CustomersSuppliers.CustomersAddressBook.wrm\"],\"arguments\":[{ \"name\":\"w_FromCustomer\",\"value\":\"0001\"},{ \"name\":\"w_ToCustomer\",\"value\":\"0009\"}]}";
            return (functionParams);
        }

    }
}
