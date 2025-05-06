//This file is created automatically by MMS
//maintenance of this file will be done by programmer
//HIGHLY RECOMMENDED: 
//DON'T TOUCH THE METHODS DECORATORS; The decorators are used for update of this file!!!
//DON'T TOUCH MMS REGION

using Microarea.Tbf.Model.MyMagoStudioBase;
using System.Threading.Tasks;
using Microarea.Generic.DataObj;
using Microarea.Tbf.Model.Remote;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using OttieniToken.MOToken.Model;
using OttieniToken.MOToken.Controllers;
using OttieniToken.MOToken.BO;
using Microarea.Tbf.Model.API;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace OttieniToken.MOToken.DocOttieniToken
{
    public partial class OttieniTokenMOTokenDocOttieniToken : MyMagoStudioDocument
    {
        //[MyMagoStudioMethodDecorator("Clicked", "PrendoIlToken", "DOCOTTIENITOKEN_toolbarTopButton_1", false)]
        //public async Task<PrendoIlTokenResponse> PrendoIlToken(PrendoIlTokenRequest request, ContextInfo contextInfo, string callerDocId)
        //{
        //    PrendoIlTokenResponse response = new PrendoIlTokenResponse();
        //    //...add your code here with some awaitable functions/methods ecc....
        //    var header = contextInfo.SAuthorization;
        //    JObject jsonObject = JObject.Parse(header);
        //    string token = (string)jsonObject["securityValue"];

        //    response.EsponiToken = token;

        //    return response;
        //}


        public (string,string) LeggoHeaders()
        {
            try
            {
                if (!System.IO.File.Exists("Headers.txt")) return ("NonEsiste", string.Empty);
                string authorization = string.Empty;
                string serverInfo = string.Empty;


                using (StreamReader reader = System.IO.File.OpenText("Headers.txt"))
                {
                    authorization = reader.ReadLine();
                    serverInfo = reader.ReadLine();

                }
                return (authorization,serverInfo);
            }
            catch (Exception e)
            {
                return (e.Message, string.Empty);
            }
        }


        [MyMagoStudioMethodDecorator("Clicked", "ScrivoIlToken", "DOCOTTIENITOKEN_toolbarTopButton_1")]
        public async Task<ScrivoIlTokenResponse> ScrivoIlToken(ScrivoIlTokenRequest request, ContextInfo contextInfo, string callerDocId)
        {
            ScrivoIlTokenResponse response = new ScrivoIlTokenResponse();
            //...add your code here with some awaitable functions/methods ecc....
            string autorization = contextInfo.SAuthorization;
            string serverInfo = contextInfo.SServerInfo;

            using (StreamWriter writer = System.IO.File.CreateText("Headers.txt"))
            {
                await writer.WriteLineAsync(autorization);
                await writer.WriteLineAsync(serverInfo);
                await writer.WriteLineAsync(callerDocId);
            }

            return response;
        }

        
              
        [MyMagoStudioMethodDecorator("DataInitialized", "ScrivoIlTokenDATAInit")]
        public async Task<ScrivoIlTokenDATAInitResponse> ScrivoIlTokenDATAInit(ScrivoIlTokenDATAInitRequest request, ContextInfo contextInfo, string callerDocId)
        {
            ScrivoIlTokenDATAInitResponse response = new ScrivoIlTokenDATAInitResponse();
            //...add your code here with some awaitable functions/methods ecc....
            return response;
        }

        
                [MyMagoStudioMethodDecorator("Clicked", "ApriSaleOrd", "DOCOTTIENITOKEN_toolbarTopButton_2")]
        public async Task<ApriSaleOrdResponse> ApriSaleOrd(ApriSaleOrdRequest request, ContextInfo contextInfo, string callerDocId)
        {
            ApriSaleOrdResponse response = new ApriSaleOrdResponse();
            //...add your code here with some awaitable functions/methods ecc....
            var header = contextInfo.SAuthorization;

            ERPSaleOrdersSaleOrd saleOrdDoc = await ERPSaleOrdersSaleOrd.CreateAttendedAsync(contextInfo, callerDocId);
            saleOrdDoc.MasterTable.Record.f_SaleOrdId.Value = 74;
            _ = saleOrdDoc.BrowseRecord(response);

            return response;
        }

        #region MMS AUTOMATICALLY ADDS NEW METHODS HERE
        #endregion





    }
}