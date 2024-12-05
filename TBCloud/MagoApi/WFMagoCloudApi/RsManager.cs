
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TbApiTester
{
    internal class RsManager
    {
        public static string PdfDirectory { get; } = Path.Combine(Application.StartupPath, "Reports");
        public string requestRs { get; set; }
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
        //        TbApiTesterManager.PrepareHeaders(request, userData);

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
        public string GetXmlData(UserData userData, DateTime operationDate, int btn = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/REPORTSERVICE");
                    //if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = RetriveRsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.ReportingServiceUrl + "/rs/xmldata");
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);

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
                            requestRs = UrlSManager.ReportingServiceUrl + "/rs/xmldata";
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


        public string GetReportPdf(UserData userData, DateTime operationDate, int btn = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/REPORTSERVICE");
                    //if (UrlSManager.ReportingServiceUrl == "") UrlSManager.ReportingServiceUrl = RetriveRsUrl(userData, DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.ReportingServiceUrl + "/rs/getReportPdf");
                    TbApiTesterManager.PrepareHeaders(request, userData, operationDate);

                    string jsonInString = "";
                    if (btn == 0)
                        jsonInString = PreparePdf(request);
                   
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // Create a Folder
                        if (!Directory.Exists(PdfDirectory))
                            Directory.CreateDirectory(PdfDirectory);

                        // Read the response content as a byte array to save the PDF
                        var pdfData = response.Content.ReadAsByteArrayAsync().Result;

                        // Save the PDF in a specific directory
                        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                        var pdfFilePath = Path.Combine(PdfDirectory, $"report_{timestamp}.pdf");
                        File.WriteAllBytes(pdfFilePath, pdfData);

                        // Open the PDF immediately after saving
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = pdfFilePath,
                            UseShellExecute = true
                        });
                        requestRs = UrlSManager.ReportingServiceUrl + "/rs/getReportPdf";
                        return $"The PDF has been successfully saved at:\n{pdfFilePath}\nAnd opened.";
                       
                    }
                    else
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        return "ReportingService-getReportPdf error. Response message : " + responseBody;
                    }
                }
                catch (HttpRequestException e)
                {
                    return "ReportingService-getReportPdf exception Caught: Message: " + e.Message;
                }

            }
        }
        public string PrepareItems(HttpRequestMessage request)
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
                namespaces = new[] { "ERP.CustomersSuppliers.CustomersAddressBook.wrm" },
                arguments = new[]
                { new { name = "w_FromCustomer", value = "0001" },
                  new { name = "w_ToCustomer", value = "0009" }
                }
            });
            //var functionParams = "{\"namespaces\":[\"ERP.CustomersSuppliers.CustomersAddressBook.wrm\"],\"arguments\":[{ \"name\":\"w_FromCustomer\",\"value\":\"0001\"},{ \"name\":\"w_ToCustomer\",\"value\":\"0009\"}]}";
            return (functionParams);
        }

        public string PreparePdf(HttpRequestMessage request)
        {
            string functionParams = JsonConvert.SerializeObject(new
            {
                rsInfo = new
                {
                    copiesNumber = 1,
                    concatPDF = false,
                    actionType = 1
                },
                namespaces = new[] { "Report.ERP.Company.Titles" },
                outputNames = new string[] { },
                arguments = new string[] { }
            });
            return functionParams;
        }

    }
}
