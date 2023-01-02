using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace MagoCloudApi
{
    public class MagoCloudApiManager
    {
        internal AuthenticationManager authenticationManager = new AuthenticationManager();
        internal DataServiceManager dataServiceManager = new DataServiceManager();
        internal TbServerManager tbServerManager = new TbServerManager();

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
                    {"AppKey",appKey }
                };
            string dJsonInString = JsonConvert.SerializeObject(producerData);
            request.Headers.TryAddWithoutValidation("MagoAPI", dJsonInString);

        }
    }
}