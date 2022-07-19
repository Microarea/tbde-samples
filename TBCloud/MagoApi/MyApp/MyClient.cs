
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
using System.Collections.Generic;

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
            public Dictionary<string, object> TbWebMethodArguments { get ; set; }
        }

        // response
        public class MyResponse : ITbResponse
        {
            public object ReturnValue { get; set; }
            public bool Success { get; set; }
            public int StatusCode { get; set; }
            public string PlainResult { get; set; }
        }

        public static bool Execute(string instance, string user, string pwd, string subkey, bool loginByAccountManager)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // it constructs a new Mago API Client identifying instance to connect and customization author
            /////////////////////////////////////////////////////////////////////////////////////////////////
            using (MagoAPIClient magocloudClient = new MagoAPIClient(instance, new ProducerInfo("MyProdKey", "MyAppID")))
            {
                ITbUserData userData = null;
                try
                {
                    if (loginByAccountManager)
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // ACCUNTMANAGER: authentication process (Login/Logout/IsValid)
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        ///
                        IAccountManagerResult accManResult = magocloudClient.AccountManager?.Login(user, pwd, subkey).Result;

                        if (accManResult.Success && accManResult?.UserData != null && accManResult.UserData.IsLogged)
                            userData = accManResult.UserData;
                    }
                    else
                    {
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // GWAM LOGIN: authentication process by Gwam(Login/Logout/IsValid)
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        ///
                        IGwamResult gwamResult = magocloudClient.GwamClient?.Login(user, pwd, subkey).Result;

                        if (gwamResult.Success && gwamResult?.UserData != null && gwamResult.UserData.IsLogged)
                            userData = gwamResult.UserData;
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    // ACCUNTMANAGER: authentication process (Login/Logout/IsValid)
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                    IAccountManagerResult result = magocloudClient.AccountManager?.Login(user, pwd, subkey).Result;

                    if (userData != null)
                    {
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

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // Mago TB WEB METHODS
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        MyReuqest parameters = new MyReuqest();
                        parameters.OperationDate = DateTime.Now;
                        MyResponse myResp = magocloudClient.TbServer?.InvokeTbMethod<MyResponse>(userData, "ERP.Company.Dbl.CurrentOpeningDate", parameters).Result;


                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // DATA SERVICE communication
                        // In this sample we will get accounting reasons data using default hotlink query and in the second
                        // call we will use radar query to get same data. 
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        var data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "default").Result;
                        data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "radar").Result;

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // MagoAPIClient class expose Mago Service Hub backend url too, but for a detailed list of api please refer
                        // Mago Service Hub development team
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        string espUrl = magocloudClient.MagoServicesHub.GetServiceUrl(subkey);

                        // authentication end
                        if (loginByAccountManager && magocloudClient.AccountManager.IsValid(userData).Result.Success)
                            return magocloudClient.AccountManager.Logout(userData).Result.Success;

                        else if (magocloudClient.GwamClient.IsValid(userData).Result.Success)
                            return magocloudClient.GwamClient.Logout(userData).Result.Success; return result.Success;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    if (userData != null && userData.IsLogged)
                    {
                        if (loginByAccountManager && magocloudClient.AccountManager.IsValid(userData).Result.Success)
                            return magocloudClient.AccountManager.Logout(userData).Result.Success;

                        else if (magocloudClient.GwamClient.IsValid(userData).Result.Success)
                            return magocloudClient.GwamClient.Logout(userData).Result.Success;
                    }
                }
            }
            return true;
        }
    }

}
