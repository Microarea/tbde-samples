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
        public string folderPath { get; set; }
        public string outFileName { get; set; }

        //////  RetriveTbServerUrl  ///////

        ///////////////////////////////////
        //////  RetriveTbServerUrl  ///////
        ///////////////////////////////////
        //public string RetriveTbServerUrl(UserData userData, DateTime operationDate)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + "/gwam_mapper/api/services/url/" + userData.SubscriptionKey + "/TBSERVER");
        //        MagoCloudApiManager.PrepareHeaders(request, userData);

        //        HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;
        //        string responseBody = response.Content.ReadAsStringAsync().Result;
        //        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

        //        string resultVariable = "";
        //        if (jsonObject != null)
        //        {
        //            resultVariable = jsonObject["Content"]?.ToString();
        //        }
        //        return UrlSManager.TbServerUrl = resultVariable;
        //    }
        //}
        public (bool, string) LoadMagicLinkFile(string xmlFileName)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            folder.Refresh();
            try
            {
                xmlFileName = folderPath + "\\" + xmlFileName;
                if (!File.Exists(xmlFileName))
                    return (false, "File " + xmlFileName + " not found");

                using (XmlTextReader reader = new XmlTextReader(xmlFileName))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);

                    return (true, doc.InnerXml.ToString());
                }
            }
            catch (HttpRequestException e)
            {
                return (false, "Exception loading " + xmlFileName + " : " + e.Message);
            }
        }

        public bool SaveFile(string content)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            folder.Refresh();
            try
            {
                File.AppendAllText(outFileName, content);
                return true;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("SaveFile: " + e.Message);
                return false;
            }
        }
        /////////////////////////////
        /////// Get xml Params ////////
        public async Task<string> GetXmlParams(UserData userData, DateTime operationDate, string xmlContent)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveTbServerUrl(userData,DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
                    string jsonInString = PrepareGetParams(request, xmlContent, userData.UserName);
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.SendAsync(request);

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(functionParams);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["result"]?.ToString();
                            var bytes = Convert.FromBase64String(resultVariable.ToString());
                            var decodedString = Encoding.UTF8.GetString(bytes);
                            outFileName = folderPath + "\\GetFull.xml";
                            SaveFile(decodedString);
                            return decodedString;
                        }
                        else
                            return "GetXmlParams error: unable to retrive the result";
                    }
                    else
                        return "GetXmlParams error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "GetXmlParams exception Caught: Message: " + e.Message;
                }
            }
        }
        public string PrepareGetParams(HttpRequestMessage request, string xmlParams, string userName)
        {
            var functionParams = JsonConvert.SerializeObject(new
            {
                ns = "Extensions.XEngine.TBXmlTransfer.GetXMLParametersRest",
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

        /////////////////////////////
        /////// Get xml data ////////
        public string GetXmlData(UserData userData, DateTime operationDate, string xmlContent)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    //if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = RetriveTbServerUrl(userData,DateTime.Now);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);

                    string jsonInString = PrepareGetTb(request, xmlContent, userData.UserName);
                    request.Method = HttpMethod.Post;
                    request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request).Result;

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string functionParams = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(functionParams);

                        if (jsonObject != null)
                        {
                            JToken[] result = jsonObject["result"].ToArray();
                            StringBuilder strings = new StringBuilder();
                            short idx = 0;
                            foreach (JToken item in result)
                            {
                                idx++;
                                var bytes = Convert.FromBase64String(item.ToString());
                                var decodedString = Encoding.UTF8.GetString(bytes);
                                strings.AppendLine(decodedString.ToString());
                                outFileName = folderPath + "\\InvRsnSet" + idx.ToString() + ".xml";
                                SaveFile(decodedString);
                            }
                            return strings.ToString();
                        }
                        else
                            return "GetXmlData error: unable to retrieve the TbServer.";
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
                    UrlSManager Urls = new UrlSManager();
                    if (UrlSManager.TbServerUrl == "") UrlSManager.TbServerUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBSERVER");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbServerUrl + "/tbserver/api/tb/document/runRestFunction/");
                    MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);

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
                            var decodedString = Encoding.UTF8.GetString(bytes);
                            return decodedString;
                        }
                        else
                            return "SetXmlData error: unable to retrive the TbServer.";
                    }
                    else
                        return "SetXmlData error. Response message : " + responseBody;
                }
                catch (HttpRequestException e)
                {
                    return "SetXmlData exception Caught: Message: " + e.Message;
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
