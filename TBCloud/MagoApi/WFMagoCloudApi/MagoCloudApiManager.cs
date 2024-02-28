using MagoCloudAPI;
using Microsoft.VisualStudio.TextManager.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Text;
using System.Web.UI.WebControls;

namespace MagoCloudApi
{
    public class MagoCloudApiManager
    {
        internal AuthenticationManager authenticationManager = new AuthenticationManager();
        internal DataServiceManager dataServiceManager = new DataServiceManager();
        internal TbServerManager tbServerManager = new TbServerManager();
        internal WebMethodsManager webMethodsManager = new WebMethodsManager();
        internal RsManager rsManager = new RsManager();
        internal DmsManager dmsManager = new DmsManager();
        internal DmMMSManager dmMMSManager = new DmMMSManager();
        internal UrlSManager urlsManager = new UrlSManager();
        internal TbFsServiceManager tbFsServiceManager = new TbFsServiceManager();
        internal TbResponse tbResponse = new TbResponse();
        internal ExampleManager exampleManager = new ExampleManager();
        internal ServiceManager serviceManager = new ServiceManager();

        public MagoCloudApiManager()
        {

        }
        internal static void PrepareHeaders(HttpRequestMessage request, UserData userData, DateTime operationDate)
        {

            PrepareHeaderAutorization(request, userData);
            PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
            PrepareHeaderServerInfo(request, userData, operationDate);
            PrepareHeaderSnapshot(request, userData);

            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
        }

        internal static void PrepareHeaderSnapshot(HttpRequestMessage request, UserData userData)
        {
            var snapshotData = JsonConvert.SerializeObject(new
            {
                SubscriptionKey = userData.SubscriptionKey,
                Token = userData.Token
            });
            request.Headers.TryAddWithoutValidation("Snapshot", snapshotData);
        }

        internal static void PrepareHeaderMagoAPI(HttpRequestMessage request, string producerKey, string appKey)
        {
            var producerData = new JObject
                {
                    {"ProducerKey",producerKey},
                    {"AppKey",appKey },
                };
            string dJsonInString = JsonConvert.SerializeObject(producerData);
            request.Headers.TryAddWithoutValidation("MagoAPI", dJsonInString);
        }

        internal static void PrepareHeaderServerInfo(HttpRequestMessage request, UserData userData, DateTime operationDate)
        {
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
        }

        internal static void PrepareHeaderAutorization(HttpRequestMessage request, UserData userData)
        {
            var credential = new JObject
                    {
                        { "type", "JWT"},
                        { "AppId", "MagoAPI" },
                        { "securityValue", userData.Token }
                    };
            string credentialJsonInString = JsonConvert.SerializeObject(credential);
            request.Headers.TryAddWithoutValidation("Authorization", credentialJsonInString);
        }



    }
}