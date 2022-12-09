using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace MagoCloudApi
{
    class TbServerManager
    {
        /////////////////////////////
        /////// Get xml data ////////
        public string GetXmlData(UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new JObject
                {
                    {"ProducerKey",userData.Producer},
                    {"AppKey",userData.AppKey },
                };
                string dJsonInString = JsonConvert.SerializeObject(data);

                try
                {
                    string dir = "C:\\FirstDev\\tbde-samples\\TBCloud\\MagoApi\\MyApp";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Path.Combine(dir, "Customers.xml"));
                    string xml = doc.InnerXml.ToString();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://beta.mago.cloud/13/be/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData.Token, userData.SubscriptionKey);
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
                    string jsonInString = PrepareGetTb(request, xml, userData.UserName);
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                         JObject jsonObject = JsonConvert.DeserializeObject<JObject>(functionParams);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["result"]?.ToString();
                            JToken[] result = jsonObject["result"].ToArray();
                            List<string> strings = new List<string>();
                            foreach (JToken item in result)
                            {
                                var bytes = Convert.FromBase64String(item.ToString());
                                var decodedString = Encoding.UTF8.GetString(bytes);
                                strings.Add(decodedString.ToString());
                                return responseBody;
                            }
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
                return string.Empty;
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

        /* public string SetXmlData(UserData userData, DateTime operationDate)
         {
             using (HttpClient client = new HttpClient())
             {
                 var data = new JObject
                 {
                     {"ProducerKey",userData.Producer},
                     {"AppKey",userData.AppKey },
                 };
                 string dJsonInString = JsonConvert.SerializeObject(data);

                 try
                 {
                     string dir = "C:\\FirstDev\\tbde-samples\\TBCloud\\MagoApi\\MyApp";
                     XmlDocument doc = new XmlDocument();
                     doc.Load(Path.Combine(dir, "Customers.xml"));
                     string xml = doc.InnerXml.ToString();
                     HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://beta.mago.cloud/13/be/tbserver/api/tb/document/runRestFunction/");
                     MagoCloudApiManager.PrepareHeaders(request, userData.Token, userData.SubscriptionKey);
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
                     string jsonInString = PrepareSetTb(request, xml, action, userName);
                     request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                     HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                     
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                         JObject jsonObject = JsonConvert.DeserializeObject<JObject>(functionParams);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["result"]?.ToString();
                            JToken[] result = jsonObject["result"].ToArray();
                            List<string> strings = new List<string>();
                            foreach (JToken item in result)
                            {
                                var bytes = Convert.FromBase64String(item.ToString());
                                var decodedString = Encoding.UTF8.GetString(bytes);
                                strings.Add(decodedString.ToString());
                                return responseBody;
                            }
                        }
                         else
                             MessageBox.Show("Unable to retrive the TbServer.");
                     }
                 }
                 catch (HttpRequestException e)
                 {
                     Console.WriteLine("\nException Caught!");
                     Console.WriteLine("Message :{0} ", e.Message);
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
             return JsonConvert.SerializeObject(functionParams);
         }
         private object Base64Encoder(string base64String)
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
         }*/
    }
}
