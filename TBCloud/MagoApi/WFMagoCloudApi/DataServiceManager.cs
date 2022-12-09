
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace MagoCloudApi
{
    class DataServiceManager
    {
        internal string GetData(UserData userData, string selectionType, string nameSpace)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new JObject
                {
                    {"ProducerKey",userData.Producer },
                    {"AppKey",userData.AppKey }
                };
                string dJsonInString = JsonConvert.SerializeObject(data);
          
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://beta.mago.cloud/13/be/data-service/getdata/" + nameSpace + '/' + selectionType);
                    MagoCloudApiManager.PrepareHeaders(request, userData.Token, userData.SubscriptionKey);
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
                            return responseBody;
                        }
                        else
                            MessageBox.Show("data is no longer valid.");
                    }
                    else
                        MessageBox.Show("Unable to retrive the data.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return string.Empty;
            }
        }
    }
}
