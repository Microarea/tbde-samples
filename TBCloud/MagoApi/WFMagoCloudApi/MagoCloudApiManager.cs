using MagoCloudAPI;
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
        
        public MagoCloudApiManager()
        {
            
        }
        internal static void PrepareHeaders(HttpRequestMessage request, UserData userData)
        {
            var credential = new JObject
                    {
                        { "type", "JWT"},
                        { "AppId", "MagoAPI" },
                        { "securityValue", userData.Token }
                    };
            string credentialJsonInString = JsonConvert.SerializeObject(credential);
            request.Headers.TryAddWithoutValidation("Authorization", credentialJsonInString);

            var snapshotData = JsonConvert.SerializeObject(new
            {
                SubscriptionKey = userData.SubscriptionKey,
                Token = userData.Token
            });

            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Snapshot", snapshotData);
            MagoCloudApiManager.PrepareMagoAPIHeader(request, userData.Producer, userData.AppKey);
        }

        internal static void PrepareMagoAPIHeader(HttpRequestMessage request, string producerKey, string appKey)
        {
            var producerData = new JObject
                {
                    {"ProducerKey",producerKey},
                    {"AppKey",appKey },
                };
            string dJsonInString = JsonConvert.SerializeObject(producerData);
            request.Headers.TryAddWithoutValidation("MagoAPI", dJsonInString);
        }
    }
}