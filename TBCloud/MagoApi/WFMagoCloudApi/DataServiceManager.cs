
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
               
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://beta.mago.cloud/13/be/data-service/getdata/" + nameSpace + '/' + selectionType);
                    MagoCloudApiManager.PrepareHeaders(request,userData);
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
            internal string GetVersion(UserData userData)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://beta.mago.cloud/13/be/data-service/api/assemblyversion");
                        MagoCloudApiManager.PrepareHeaders(request, userData);
                        HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string responseBody = response.Content.ReadAsStringAsync().Result;
                            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                            if (jsonObject != null)
                            {
                                return jsonObject.ToString();
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
