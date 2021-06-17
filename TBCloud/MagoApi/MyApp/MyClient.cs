
using System;

using System.Xml;
using System.IO;
using Microarea.Tbf.Model.API;
using Microarea.Tbf.Model.Interfaces.API;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MyApp
{
    public class MyClient
    {
        /// <summary>
        /// request implementation for parameters
        /// </summary>
        public class MyReuqest : ITbRequest
        {
            public object RequestId { get; set; }
            public DateTime OperationDate { get; set; }
        }

        // response
        public class MyResponse : ITbResponse
        {
            public object ReturnValue { get; set; }
            public bool Success { get; set; }
            public int StatusCode { get; set; }
        }

        public static bool Execute(string instance, string user, string pwd, string subkey)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // it constructs a new Mago API Client identifying instance to connect and customization author
            /////////////////////////////////////////////////////////////////////////////////////////////////
            using (MagoAPIClient magocloudClient = new MagoAPIClient(instance, new ProducerInfo("MyProdKey", "MyAppID")))
            {
                ITbUserData userData = null;
                try
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    // ACCUNTMANAGER: authentication process (Login/Logout/IsValid)
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                    IAccountManagerResult result = magocloudClient.AccountManager?.Login(user, pwd, subkey).Result;

                    if (result.Success && result?.UserData != null && result.UserData.IsLogged)
                    {
                        userData = result.UserData;

                        //@@TODO SUBSTITUTE WITH PROJECT DIRECTORY OR MOVE DATA XMLS TO THE BIN FOLDER
                        string dir = Environment.CurrentDirectory; 

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // TBSERVER communication. It loads old magic link payload from file system and get and sets a
                        // customer master. It invokes CurrentOpeningDate TBWebMethod.
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Path.Combine(dir, "Customers.xml"));
                        ITbServerMagicLinkResult tbResult = magocloudClient.TbServer?.GetXmlData(userData, doc.InnerXml.ToString(), DateTime.Now).Result;
                        doc.Load(Path.Combine(dir, "Customers1.xml"));
                        tbResult = magocloudClient.TbServer?.SetXmlData(userData, doc.InnerXml.ToString(), 0, DateTime.Now).Result;
                        bool imported = result.Success;
                        doc = null;

                        // tbwebmethod
                        MyReuqest parameters = new MyReuqest();
                        parameters.OperationDate = DateTime.Now;
                        MyResponse myResp = magocloudClient.TbServer?.InvokeTbMethod<MyResponse>(userData, "ERP.Company.Dbl.CurrentOpeningDate", parameters).Result;


                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // ERPWEBAPI communication 
                        // it invokes some get methods that allows to inspect table catalog used by microservices but
                        // please use /swagger/index.html for available api list and details). In this example we will
                        // call Currencies/CurrencyManager/IsPeriodBeforeEuro API
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        var schema = magocloudClient.ErpWebAPI.Schema(userData).Result;
                        var tableSchema = magocloudClient.ErpWebAPI.SchemaTable(userData, "MA_Titles").Result;
                        var colSchema = magocloudClient.ErpWebAPI.SchemaColumn(userData, "Item").Result;

                        using (var msg = new HttpRequestMessage(HttpMethod.Post, new Uri(magocloudClient.ErpWebAPI.ServiceUrl + "Currencies/CurrencyManager/IsPeriodBeforeEuro")))
                        {
                            var funParam = JsonConvert.SerializeObject(new
                            {
                                operationDate = "2020-12-10T08:25:51.808Z",
                                testconvertedcompany = false
                             
                            });
                            msg.Content = new StringContent(content: funParam, encoding: Encoding.UTF8, "application/json");
                            msg.Headers.AddMagoCloudBaseHeaders(userData.Token, userData.SubscriptionKey, magocloudClient.ProducerInfo);

                            HttpClient httpClient = new HttpClient();

                            using (var response =  httpClient.SendAsync(msg).Result)
                            {
                                string funResponse = response.Content.ReadAsStringAsync().Result;

                                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(funResponse))
                                {
                                    JObject jResult = JsonConvert.DeserializeObject<JObject>(funResponse);
                                    if (jResult != null)
                                    {
                                        JToken jretVal = jResult["retVal"];
                                        bool retVal = jretVal == null ? false : jretVal.Value<bool>();
                                        JToken jSucc = jResult["success"];
                                        bool success = jSucc == null ? false : jSucc.Value<bool>();
                                    }
                                }
                            }
                        }

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // DATA SERVICE communication
                        // In this sample we will get accounting reasons data using default hotlink query and in the second
                        // call we will use radar query to get same data. 
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        var data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "default").Result;
                        data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "radar").Result;

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // MagoAPIClient class expose ESP backend url too, but for a detailed list of api please refer
                        // esp development team
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        string espUrl = magocloudClient.ESP.ServiceUrl;

                        // authentication end
                        if (magocloudClient.AccountManager.IsValid(result.UserData).Result.Success)
                            result = magocloudClient.AccountManager.Logout(result.UserData).Result;
                        return result.Success;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    if (userData != null && magocloudClient.AccountManager.IsValid(userData).Result.Success)
                        return magocloudClient.AccountManager.Logout(userData).Result.Success;
                }
            }
            return true;
        }
    }

}
