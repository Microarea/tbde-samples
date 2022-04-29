
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
using System.Threading.Tasks;
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
            public Dictionary<string, object> TbWebMethodArguments { get; set; }
        }

        // response
        public class MyResponse : ITbResponse
        {
            public object ReturnValue { get; set; }
            public bool Success { get; set; }
            public int StatusCode { get; set; }
            public string PlainResult { get; set; }
        }

        public static async Task<bool> Execute(string instance, string user, string pwd, string subkey)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // it constructs a new Mago API Client identifying instance to connect and customization author
            /////////////////////////////////////////////////////////////////////////////////////////////////
            using (MagoAPIClient magocloudClient = new MagoAPIClient(instance, new ProducerInfo("MyProdKey", "MyAppId")))
            {
                ITbUserData userData = null;
                try
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    // ACCUNTMANAGER: authentication process (Login/Logout/IsValid)
                    /////////////////////////////////////////////////////////////////////////////////////////////////
                    ///
                    IAccountManagerResult result = await magocloudClient.AccountManager?.Login(user, pwd, subkey);

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
                        ITbServerMagicLinkResult tbResult = await magocloudClient.TbServer?.GetXmlData(userData, doc.InnerXml.ToString(), DateTime.Now);
                        doc.Load(Path.Combine(dir, "Customers1.xml"));
                        tbResult = await magocloudClient.TbServer?.SetXmlData(userData, doc.InnerXml.ToString(), 0, DateTime.Now);
                        bool imported = result.Success;
                        doc = null;

                        // tbwebmethod
                        MyReuqest parameters = new MyReuqest();
                        parameters.OperationDate = DateTime.Now;
                        MyResponse myResp = await magocloudClient.TbServer?.InvokeTbMethod<MyResponse>(userData, "ERP.Company.Dbl.CurrentOpeningDate", parameters);


                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // DATA SERVICE communication
                        // In this sample we will get accounting reasons data using default hotlink query and in the second
                        // call we will use radar query to get same data. 
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        var data = await magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "default");
                        data = await magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "radar");

                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        // MagoAPIClient class expose Mago Services Hub backend url too, but for a detailed list of api please refer
                        // esp development team
                        /////////////////////////////////////////////////////////////////////////////////////////////////
                        string espUrl = magocloudClient.MagoServicesHub.ServiceUrl;

                        // authentication end
                        IAccountManagerResult myRes = await magocloudClient.AccountManager.IsValid(result.UserData);
                        if (myRes.Success)
                            result = await magocloudClient.AccountManager.Logout(result.UserData);
                        return result.Success;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    if (userData != null)
                    {
                        IAccountManagerResult myRes1 = await magocloudClient.AccountManager.IsValid(userData);
                        return myRes1.Success;
                    }
                }
            }
            return true;
        }
    }

}
