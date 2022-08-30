
using System;

using System.Xml;
using System.IO;
using Microarea.Tbf.Model.API;
using Microarea.Tbf.Model.Interfaces.API;
using System.Collections.Generic;

namespace MyApp
{
    public class MyClient
    {
        /// <summary>
        /// request implementation for parameters
        /// </summary>
        public class MyRequest : ITbRequest
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

                    if (userData != null)
                    {
                        UseMagicLink(magocloudClient, userData);
                        UseDataService(magocloudClient, userData);
                        UseReportingServices(magocloudClient, userData);
                        UseOthersMicroservices(magocloudClient, userData);

                        // authentication end
                        if (loginByAccountManager && magocloudClient.AccountManager.IsValid(userData).Result.Success)
                            return magocloudClient.AccountManager.Logout(userData).Result.Success;

                        else if (magocloudClient.GwamClient.IsValid(userData).Result.Success)
                            return magocloudClient.GwamClient.Logout(userData).Result.Success;
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

        /////////////////////////////////////////////////////////////////////////////////////////////////
        // DATA SERVICE communication
        // In this sample we will get accounting reasons data using default hotlink query and in the second
        // call we will use radar query to get same data. 
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private static void UseDataService(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            // getting microservice product version
            ITbResponse versionResponse = magocloudClient.DataService?.GetVersion(userData).Result;

            var data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "default", true).Result;
            data = magocloudClient.DataService.GetData(userData, "ERP.Accounting.Dbl.AccountingReasons", "radar").Result;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        // TBSERVER communication. It loads old magic link payload from file system and get and sets a
        // customer master. It invokes CurrentOpeningDate TBWebMethod.
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private static void UseMagicLink(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            // getting microservice product version
            ITbResponse versionResponse = magocloudClient.TbServer?.GetVersion(userData).Result;

            //@@TODO SUBSTITUTE WITH PROJECT DIRECTORY OR MOVE DATA XMLS TO THE BIN FOLDER
            string dir = Environment.CurrentDirectory;

            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(dir, "Customers.xml"));
            ITbServerMagicLinkResult tbResult = magocloudClient.TbServer?.GetXmlData(userData, doc.InnerXml.ToString(), DateTime.Now).Result;
            doc.Load(Path.Combine(dir, "Customers1.xml"));
            tbResult = magocloudClient.TbServer?.SetXmlData(userData, doc.InnerXml.ToString(), 0, DateTime.Now).Result;
            bool imported = tbResult.Success;
            doc = null;

            // tbwebmethod
            MyRequest parameters = new MyRequest();
            parameters.OperationDate = DateTime.Now;
            MyResponse myResp = magocloudClient.TbServer?.InvokeTbMethod<MyResponse>(userData, "ERP.Company.Dbl.CurrentOpeningDate", parameters).Result;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        // REPORTING SERVICES communication. It executes a report with json payload and extracts its
        // data in old MagicLink/EasyLook format
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private static void UseReportingServices(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            // getting microservice product version
            ITbResponse versionResponse = magocloudClient.ReportingServices?.GetVersion(userData).Result;

            // getting report data in xml format
            List<ReportArg> repArgs = new List<ReportArg>();
            repArgs.Add(new ReportArg("w_CodeStart", "A"));
            repArgs.Add(new ReportArg("w_CodeEnd", "B"));

            ReportRequest reportRequest = new ReportRequest(new ReportSelection("ERP.Items.Items.wrm", repArgs));

            ITbResponse rsResult = magocloudClient.ReportingServices?.GetXmlData(userData, DateTime.Now, reportRequest).Result;
        }

        private static void UseOthersMicroservices(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // MagoAPIClient class expose Mago Service Hub backend url too, but for a detailed list of api please refer
            // Mago Service Hub development team
            /////////////////////////////////////////////////////////////////////////////////////////////////
            string espUrl = magocloudClient.MagoServicesHub.GetServiceUrl(userData.SubscriptionKey);
            ITbResponse versionResponse = magocloudClient.MagoServicesHub.GetVersion(userData).Result;

            /////////////////////////////////////////////////////////////////////////////////////////////////
            // MyMagoStudio class expose MyMagoStudio backend url
            /////////////////////////////////////////////////////////////////////////////////////////////////
            string mmsUrl = magocloudClient.MyMagoStudio.GetServiceUrl(userData.SubscriptionKey);

        }

    }

}
