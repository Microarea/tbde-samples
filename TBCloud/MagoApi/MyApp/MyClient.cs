
using System;

using System.Xml;
using System.IO;
using Microarea.Tbf.Model.API;
using Microarea.Tbf.Model.Interfaces.API;
using System.Collections.Generic;
using Microarea.Tbf.Model.Interfaces.DataManager;
using Newtonsoft.Json;

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


        public class MA_CustSupp
        {
            public static string TableName = "MA_CustSupp";

            public int CustSuppType { get; set; } = 3211264;
            public string CustSupp { get; set; }
            public string CompanyName { get; set; }
            public string ISOCountryCode { get; set; }
        }

        public static bool Execute(string instance, string user, string pwd, string subkey, bool loginByAccountManager)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // it constructs a new Mago API Client identifying instance to connect and customization author
            /////////////////////////////////////////////////////////////////////////////////////////////////
            using (MagoAPIClient magocloudClient = new MagoAPIClient(instance, new ProducerInfo("MyProdKey", "MagoApi")))
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
                        //UseMagicLink(magocloudClient, userData);
                        //UseDataService(magocloudClient, userData);
                        //UseReportingServices(magocloudClient, userData);
                        UseMyMagoStudioService(magocloudClient, userData);
                        //UseOthersMicroservices(magocloudClient, userData);

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
        }

        private static void UseMyMagoStudioService(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////
            // MyMagoStudio class expose MyMagoStudio backend url
            /////////////////////////////////////////////////////////////////////////////////////////////////
            string mmsUrl = magocloudClient.MyMagoStudio.GetServiceUrl(userData.SubscriptionKey);

            // MyMagoStudioService Data Manager APIs
            UseMMSDataManager(magocloudClient, userData);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        // MYMAGOSTUDIO SERVICE communication. It executes some query in order to extract schema
        // and data from database
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private static void UseMMSDataManager(MagoAPIClient magocloudClient, ITbUserData userData)
        {
            // data manager version
            ITbResponse versionResponse = magocloudClient.MyMagoStudio?.DataManagerVersion(userData).Result;
            // sample table
            string sampleTableName = MA_CustSupp.TableName;

            //////////////////////////////////////////////////////////////////////
            /// TABLE SCHEMA APIs
            // returns a table schema
            ITbResponse schemaResponse = magocloudClient.MyMagoStudio?.Schema(userData, sampleTableName).Result;

            // returns a record prototype as payload
            ITbResponse protoResponse = magocloudClient.MyMagoStudio?.Prototype(userData, sampleTableName).Result;

            //////////////////////////////////////////////////////////////////////
            /// TABLE SELECT APIs
            // it returns record count and then selects data
            // it selects data by primary key 
            TableData tableData = new TableData();
            tableData.TableName = sampleTableName;
            tableData.Keys = new object[] { 3211264, "0001" };

            ITbResponse selectByKeyResponse = magocloudClient.MyMagoStudio?.SelectAllByKey(userData, tableData).Result;

            Query query = new Query();
            query.TableName = sampleTableName;
            query.SelectedFields = new string[] { "*" };

            ITbResponse countResponse = magocloudClient.MyMagoStudio?.Count(userData, query).Result;
            ITbResponse selectResponse = magocloudClient.MyMagoStudio?.Select(userData, query).Result;

            //////////////////////////////////////////////////////////////////////
            /// NUMBERER APIs
            /// get next id on inventory entries, but it does not consume
            ITbResponse idResponse = magocloudClient.MyMagoStudio?.GetNextID(userData, "3801093").Result;
            //idResponse = magocloudClient.MyMagoStudio?.GetNextID(userData, "MyMagoStudio.Tools.DynamicDocuments.MyDoc.Id").Result;


            //////////////////////////////////////////////////////////////////////
            /// TABLE UPDATE APIs
            /// 
            MA_CustSupp custSupp = new MA_CustSupp();
            custSupp.CustSupp = "NEWC";
            custSupp.CompanyName = "NEWC SRL";
            custSupp.ISOCountryCode = "IT";

            // insert data
            TableData crudData = new TableData();
            crudData.TableName = sampleTableName;
            crudData.Keys = new object[] { };
            crudData.Data = custSupp;
            ITbResponse addResponse = magocloudClient.MyMagoStudio?.Add(userData, crudData).Result;

            // updates data
            custSupp.CompanyName = "NEWC S.R.L";
            custSupp.ISOCountryCode = "ES";
            crudData.Keys = new object[] { 3211264, "NEWC" };
            crudData.Data = custSupp;
            ITbResponse updateResponse = magocloudClient.MyMagoStudio?.Update(userData, crudData).Result;


            // delete operation
            crudData.Data = null;
            bool? bDeleted = magocloudClient.MyMagoStudio?.Delete(userData, crudData).Result;

            //////////////////////////////////////////////////////////////////////
            /// BUSINESS OBJECT DATA APIs
            // returns a business object 
            BusinessObjectData boData = new BusinessObjectData();
            string boUpdated = "{ \"MA_CustSupp\": [{ \"data\": \"{\\\"CustSuppType\\\": 3211264, \\\"CustSupp\\\": \\\"0001\\\",\\\"Draft\\\": false,  \\\"CompanyName\\\": \\\"Biciclette Colombo Srl 111\\\", \\\"ISOCountryCode\\\": \\\"IT\\\", \\\"TaxIdNumber\\\": \\\"03099170109\\\", \\\"FiscalCode\\\": \\\"03099170109\\\",  \\\"CustSuppKind\\\": 7733248,  \\\"Account\\\": \\\"01011000\\\",  \\\"Address\\\": \\\"Via Pierino Negrotto Cambiaso 8\\\",  \\\"ZIPCode\\\": \\\"16159\\\",  \\\"City\\\": \\\"Genova\\\",  \\\"County\\\": \\\"GE\\\",  \\\"Country\\\": \\\"\\\",  \\\"Telephone1\\\": \\\"010-659.12.35\\\",  \\\"Telephone2\\\": \\\"\\\",  \\\"Telex\\\": \\\"\\\",  \\\"Fax\\\": \\\"010-650.12.40\\\",  \\\"Internet\\\": \\\"\\\",  \\\"EMail\\\": \\\"\\\",  \\\"SIACode\\\": \\\"\\\",  \\\"ContactPerson\\\": \\\"\\\",  \\\"TitleCode\\\": \\\"\\\",  \\\"NaturalPerson\\\": false,  \\\"IsAnEUCustSupp\\\": false,  \\\"Language\\\": \\\"\\\",  \\\"PriceList\\\": \\\"OFF\\\",  \\\"CustSuppBank\\\": \\\"BCRL01GE\\\",  \\\"Payment\\\": \\\"RD\\\",  \\\"CACheck\\\": \\\"\\\",  \\\"IBAN\\\": \\\"\\\",  \\\"IBANIsManual\\\": false,  \\\"CA\\\": \\\"\\\",  \\\"CIN\\\": \\\"\\\",  \\\"Currency\\\": \\\"EUR\\\",  \\\"SendDocumentsTo\\\": \\\"\\\",  \\\"PaymentAddress\\\": \\\"\\\",  \\\"ShipToAddress\\\": \\\"\\\",  \\\"Disabled\\\": false,  \\\"Notes\\\": \\\"\\\",  \\\"WorkingTime\\\": \\\"\\\",  \\\"CompanyBank\\\": \\\"\\\",  \\\"Discount1\\\": 0,  \\\"Discount2\\\": 0,  \\\"DiscountFormula\\\": \\\"\\\",  \\\"ExternalCode\\\": \\\"\\\",  \\\"CompanyCA\\\": \\\"\\\",  \\\"Presentation\\\": 1376256,  \\\"CustomerCompanyCA\\\": \\\"\\\",  \\\"DDCustSupp\\\": \\\"\\\",  \\\"PrivacyStatement\\\": false,  \\\"LinkedCustSupp\\\": \\\"0023\\\",  \\\"DocumentSendingType\\\": 11337728,  \\\"IsDummy\\\": false,  \\\"InTaxLists\\\": false,  \\\"ChambOfCommRegistrNo\\\": \\\"\\\",  \\\"WorkingPosition\\\": \\\"\\\",  \\\"TaxOffice\\\": \\\"\\\",  \\\"Storage\\\": \\\"\\\",  \\\"CostCenter\\\": \\\"\\\",  \\\"Job\\\": \\\"\\\",  \\\"InsertionDate\\\": \\\"1799-12-30T23:00:00.000Z\\\",  \\\"PrivacyStatementPrintDate\\\": \\\"2021-12-30T23:00:00.000Z\\\",  \\\"Region\\\": \\\"Liguria\\\",  \\\"MailSendingType\\\": 12451840,  \\\"OldCustSupp\\\": \\\"\\\",  \\\"CompanyRegistrNo\\\": \\\"\\\",  \\\"FactoringCA\\\": \\\"\\\",  \\\"InCurrency\\\": false,  \\\"NoBlackList\\\": false,  \\\"BlackListCustSupp\\\": \\\"\\\",  \\\"SkypeID\\\": \\\"\\\",  \\\"CBICode\\\": \\\"\\\",  \\\"InvoiceAccTpl\\\": \\\"\\\",  \\\"CreditNoteAccTpl\\\": \\\"\\\",  \\\"Latitude\\\": \\\"\\\",  \\\"Longitude\\\": \\\"\\\",  \\\"IsCustoms\\\": false,  \\\"CertifiedEMail\\\": \\\"\\\",  \\\"NoTaxComm\\\": false,  \\\"NoSendPostaLite\\\": false,  \\\"GenRegNo\\\": \\\"\\\",  \\\"GenRegEntity\\\": \\\"\\\",  \\\"FedStateReg\\\": \\\"\\\",  \\\"TaxpayerType\\\": 30212096,  \\\"MunicipalityReg\\\": \\\"\\\",  \\\"SUFRAMA\\\": \\\"\\\",  \\\"Address2\\\": \\\"\\\",  \\\"StreetNo\\\": \\\"\\\",  \\\"District\\\": \\\"\\\",  \\\"FederalState\\\": \\\"\\\",  \\\"PaymentPeriShablesWithin60\\\": \\\"\\\",  \\\"PaymentPeriShablesOver60\\\": \\\"\\\",  \\\"FiscalCtg\\\": \\\"\\\",  \\\"ActivityCode\\\": \\\"\\\",  \\\"FantasyName\\\": \\\"\\\",  \\\"PymtAccount\\\": \\\"\\\",  \\\"UsedForSummaryDocuments\\\": false,  \\\"LeasingLetter\\\": \\\"\\\",  \\\"ChambOfCommCounty\\\": \\\"\\\",  \\\"SplitTax\\\": false,  \\\"FiscalName\\\": \\\"\\\",  \\\"TaxIdType\\\": 33226752,  \\\"PrivacyAgreed\\\": false,  \\\"MarketingAgreed\\\": false,  \\\"SplitTaxIBAN\\\": \\\"\\\",  \\\"GLN\\\": \\\"\\\",  \\\"GLNDataExchange\\\": \\\"\\\",  \\\"GroupTaxIdNumber\\\": \\\"\\\",  \\\"EUTaxIdNumber\\\": \\\"\\\",  \\\"SubsidizedCustomer\\\": false,  \\\"InLiquidation\\\": false,  \\\"VSLCode\\\": 0,  \\\"TbCreated\\\": \\\"2023-04-26T13:38:31.193Z\\\",  \\\"TbModified\\\": \\\"2023-04-26T13:38:31.193Z\\\",  \\\"TbCreatedId\\\": 0,  \\\"TbModifiedId\\\": 0,  \\\"OMNIASubAccount\\\": \\\"\\\",  \\\"ProductLine\\\": \\\"\\\"}\", \"MA_CustSuppCustomerOptions\": [ {  \"CustSuppType\": 3211264,   \"Customer\": \"0001\",  \"CommissionCtg\": \"\",   \"Area\": \"UK\",   \"Salesperson\": \"CD\",\r\n    \"AreaManager\": \"CD\"\r\n  }\r\n],\r\n      \"MA_CustSuppBalances\": [\r\n {\r\n    \"CustSuppType\": 3211264,\r\n    \"CustSupp\": \"0001\",\r\n    \"FiscalYear\": 2018,\r\n    \"BalanceYear\": 2019,\r\n    \"BalanceType\": 3145730,\r\n    \"BalanceMonth\": 1,\r\n    \"Nature\": 9306112,\r\n    \"Currency\": \"EUR\",\r\n    \"TBCompanyID\": 0,\r\n    \"Debit\": 13609.71,\r\n    \"Credit\": 0,   \"TbCreated\": \"2023-04-26T13:38:48.436Z\",   \"TbModified\": \"2023-04-26T13:38:48.436Z\",    \"TbCreatedId\": 0,    \"TbModifiedId\": 0  }]  } ]}";
            boData.BONamespace = "ERP.CustomersSuppliers.Documents.Customers";
            boData.FindFields.Add("CustSuppType", 3211264);

            boData.FindFields.Add("CustSupp", "0001");
            boData.Data = JsonConvert.DeserializeObject(boUpdated);
            ITbResponse boUpdtResponse = magocloudClient.MyMagoStudio?.UpdateBusinessObject(userData, boData).Result;

            boData.FindFields.Clear();
            boData.FindFields.Add("CustSuppType", 3211264);
            boData.FindFields.Add("CompanyName", "Bici%");
           
            // search by company name or by other master table fields. % field enables like operator
           

            boData.OrderByFields = new string[] { "CompanyName" };

            boData.RequestedTables = new List<RequestedTable>();
            boData.RequestedTables.Add(new RequestedTable("MA_CustSupp"));
            boData.RequestedTables.Add(new RequestedTable("MA_CustSuppCustomerOptions", new string[] { "CustSuppType", "Customer", "CommissionCtg", "Area", "Salesperson", "AreaManager" }));
            boData.RequestedTables.Add(new RequestedTable("MA_CustSuppBalances"));

            ITbResponse boResponse = magocloudClient.MyMagoStudio?.GetBusinessObject(userData, boData).Result;

        }
    }

}
