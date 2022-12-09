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
        internal DataServiceManager  dataServiceManager = new DataServiceManager();
        internal TbServerManager tbServerManager = new TbServerManager();

        public MagoCloudApiManager()
				{
				}
        public static void PrepareHeaders(HttpRequestMessage request, string token, string subscriptionKey)
        {
            var credential = new JObject
                    {
                        { "type", "jwt"},
                        { "AppId", "MagoAPI" },
                        { "securityValue", token }
                    };
            string credentialJsonInString = JsonConvert.SerializeObject(credential);
            request.Headers.TryAddWithoutValidation("Authorization", credentialJsonInString);

            var snapshotData = JsonConvert.SerializeObject(new
            {
                SubscriptionKey = subscriptionKey,
                Token = token
            });

            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Headers.TryAddWithoutValidation("Snapshot", snapshotData);
        }
      
    }
}