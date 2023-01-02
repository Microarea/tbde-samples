using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace MagoCloudApi
{
    internal class UserData 
    {
        internal string Token { get; set; }
        internal string UserName { get; set; }
        internal string SubscriptionKey { get;  set; }
        internal string Producer { get; set; }
        internal string AppKey { get; set; }

        internal void Clear()
        {
            Token = string.Empty;
            UserName = string.Empty;
            SubscriptionKey = string.Empty;
            Producer = string.Empty;
            AppKey = string.Empty;
        }
    }
    internal class AuthenticationManager
    {
        internal UserData userData = new UserData();

        internal string Token { get => userData.Token; }

        internal bool IsLogged()
        {
            return !string.IsNullOrEmpty(userData.Token) && !string.IsNullOrEmpty(userData.UserName);
        }
        private string GetTokenForBody()
        {
            var requestBody = new JObject
                            {
                                {"Token", Token},
                            };
            string requestBodyJsonInString = JsonConvert.SerializeObject(requestBody);
            return requestBodyJsonInString;
        }
        internal void DoLogin(string userName, string pwd, string subscriptionKey, string producerKey, string appKey)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                   userData. Producer = producerKey;
                   userData. AppKey = appKey;

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://release-gwam.mago.cloud/gwam_login/api/login");
                    MagoCloudApiManager.PrepareMagoAPIHeader(request, producerKey, appKey);
                    //// Request a credential ////
                    var credential = new JObject
                                {
                                    { "AccountName", userName},
                                    { "Password", pwd},
                                    { "Token", "" },
                                    { "AppId", "MagoAPI"},
                                    { "SubscriptionKey", subscriptionKey},
                                    { "ProducerKey", ""},
                                    { "AppKey", ""}
                                };
                    string requestJsonInString = JsonConvert.SerializeObject(credential);
                    request.Content = new StringContent(requestJsonInString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //// recovery autentication token ////
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
                            if (resultVariable == "True" && resultCodeVariable == "0")
                            {
                                userData.Token = jsonObject["JwtToken"]?.ToString();
                                userData.UserName = jsonObject["AccountName"]?.ToString();
                                userData.SubscriptionKey = subscriptionKey;
                                MessageBox.Show("The login was successful.");
                            }
                        }
                        else
                            MessageBox.Show("Login reported a invalid content.");
                    }
                    else
                        MessageBox.Show("We were unable to connect to the MagoCloud login. Verify login credential");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
        internal void ValidToken()
        {
            using (HttpClient client = new HttpClient())
            {
               
                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://release-gwam.mago.cloud/gwam_login/api/isvalidtoken");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                     request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // recupero il mio token di autenticazione
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
                            if (resultVariable == "True")
                            {
                                MessageBox.Show("The token is valid");
                            }
                        }
                        else
                            MessageBox.Show("Token is no longer valid.");
                    }
                    else
                        MessageBox.Show("Unable to retrive the token.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }

        internal void DoLogout()
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://release-gwam.mago.cloud/gwam_login/api/logoff");
                    MagoCloudApiManager.PrepareHeaders(request, userData);
                    
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // recupero il mio token di autenticazione
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
                            if (resultVariable == "True")
                            {
                                userData.Clear();
                                MessageBox.Show("The User has been successfully disconnected.");
                            }
                        }
                        else
                            MessageBox.Show("Logout reported invalid content.");
                    }
                    else
                        MessageBox.Show("We were unable to logout from MagoCloud.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}
