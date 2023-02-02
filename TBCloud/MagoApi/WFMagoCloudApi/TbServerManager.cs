using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MagoCloudApi
{
    internal class TbServerManager
    {
        //Uri RsUrl = new Uri("https://develop.mago.cloud/13/be");


          ///////////////////////////////////
         //////  RetriveTbServerUrl  ///////
        ///////////////////////////////////
        public string RetriveTbServerUrl(UserData userData, DateTime operationDate)
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
                return UrlSManager.TbServerUrl = resultVariable;
            }
        }
        public (bool, string) LoadMagicLinkFile(string xmlFileName)
        {
            try
            {
                if (!File.Exists(xmlFileName))
                    return (false, "File " + xmlFileName + " not found");

                XmlDocument doc = new XmlDocument();
                string fileName = Path.Combine(Application.StartupPath, xmlFileName);
                doc.Load(fileName);
                
                return (true, doc.InnerXml.ToString());
            }
            catch (HttpRequestException e)
            {
                return (false, "Exception loading " + xmlFileName + " : " + e.Message);
            }
        }

       
        /////////////////////////////
        /////// Get xml data ////////
        public async Task<string> GetXmlData(UserData userData, DateTime operationDate, string xmlContent)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveTbServerUrl(userData,DateTime.Now);
                    //UrlSManager.TbServerUrl = RetriveTbServerUrl(userData, DateTime.Now);

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
                    string jsonInString = PrepareGetTb(request, xmlContent, userData.UserName);
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    var response = await client.SendAsync(request);

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(functionParams);

                        if (jsonObject != null)
                        {
                            JToken[] result = jsonObject["result"].ToArray();
                            StringBuilder strings = new StringBuilder();
                            foreach (JToken item in result)
                            {
                                var bytes = Convert.FromBase64String(item.ToString());
                                var decodedString = Encoding.UTF8.GetString(bytes);
                                strings.AppendLine(decodedString.ToString());
                            }
                            return strings.ToString();
                        }
                        else
                            return "GetXmlData error: unable to retrive the TbServer.";
                    }
                    else
                        return "GetXmlData error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "GetXmlData exception Caught: Message: " + e.Message;
                }
            }
        }
           public string PrepareGetTb(HttpRequestMessage request, string xmlParams, string userName)
           {
                var functionParams = JsonConvert.SerializeObject(new
                {
                    ns = "Extensions.XEngine.TBXmlTransfer.GetDataRest",
                    args = new
                    {
                        param = Base64Encoder(xmlParams),
                        useApproximation = true,
                        loginName = userName,
                        result = "data"
                    }
                });
                return (functionParams);
           }
           private object Base64Encoder(string xml)
           {
                try
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(xml);
                    string encoded = System.Convert.ToBase64String(plainTextBytes);
                    return encoded;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
           }
        /// <summary>
        /// base decoder for xml strings
        /// </summary>
        /// <param name="base64String">data to decode</param>
        /// <returns></returns>
        /// 
            private string Base64Decoder(string base64String)
            {
                try
                {
                    byte[] data = Convert.FromBase64String(base64String);
                    return Encoding.UTF8.GetString(data);
                }
                catch (Exception)
                {
                    return base64String;
                }
            }

        /////////////////////////////
        /////// Set xml data ////////

        public string SetXmlData(UserData userData, DateTime operationDate, string xmlContent, int nAction = 0)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveTbServerUrl(userData, DateTime.Now);
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
                    string jsonInString = PrepareSetTb(request, xmlContent, nAction, userData.UserName);
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                                string resultVariable = jsonObject["result"]?.ToString();
                                var bytes = Convert.FromBase64String(resultVariable.ToString());
                                var decodedString= Encoding.UTF8.GetString(bytes);
                            return decodedString;
                        }
                        else
                            return "GetXmlData error: unable to retrive the TbServer.";
                    }
                    else
                        return "SetXmlData error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "GetXmlData exception Caught: Message: " + e.Message;
                }
                
            }
        }
        
        public string PrepareSetTb(HttpRequestMessage request, string xmlData, int action, string userName)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "Extensions.XEngine.TBXmlTransfer.SetDataRest",
                args = new
                {
                    data = Base64Encoder(xmlData),
                    saveAction = action, // insert or update
                    loginName = userName,
                    result = "data"
                }
            });
            return (functionParams);
        }
    }
}
