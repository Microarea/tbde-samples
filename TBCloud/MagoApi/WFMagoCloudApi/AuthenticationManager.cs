using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace MagoCloudApi
{
    internal class UserData 
    {
        internal string TbUrl = UrlSManager.TbServerUrl;
        internal string DataUrl = UrlSManager.DataServiceUrl;
        internal string DmsUrl = UrlSManager.DmsServiceUrl;
        internal string TbFsUrl = UrlSManager.TbFsServiceUrl;
        internal string WmUrl = UrlSManager.TbServerUrl;
        internal string RsUrl = UrlSManager.ReportingServiceUrl;
        internal string DmMMsUrl = UrlSManager.DmMMSUrl;
        internal string EnumsUrl = UrlSManager.EnumsTableUrl;
        
        internal string GwamUrl { get; set; }
        internal string Token { get; set; }
        internal string UserName { get; set; }
        internal string SubscriptionKey { get;  set; }
        internal string Producer { get; set; }
        internal string AppKey { get; set; }
       
        internal void Clear()
        {
            UrlSManager.TbFsServiceUrl = string.Empty;
            DataUrl = string.Empty;
            DmsUrl = string.Empty;
            TbFsUrl = null;
            WmUrl = string.Empty;
            RsUrl = string.Empty;
            DmMMsUrl = string.Empty;
            EnumsUrl = string.Empty;
            GwamUrl = string.Empty;
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
        
        internal bool DoLogin(string gwamUrl,string userName, string pwd, string subscriptionKey, string producerKey, string appKey)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                   userData. Producer = producerKey;
                   userData. AppKey = appKey;
                    // @@mmf
                    string localLogin = "http://localhost:5000/account-manager/login";
                    //string localLogin = "http://localhost:81/account-manager/login";

                    // the URL to access MagoWeb is the following
                    //string magoWebLogin = "http://localhost:60000/account-manager/login";

                    HttpRequestMessage request;
                    if (gwamUrl == string.Empty)
                        request = new HttpRequestMessage(HttpMethod.Post, localLogin);//magoWebLogin
                    else
                        request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                    //@@mmf end

                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                    MagoCloudApiManager.PrepareHeaderMagoAPI(request, producerKey, appKey);
                    //// Request a credential ////
                    var credential = new JObject
                                {
                                    { "GwamUrl", gwamUrl},
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
                                userData.GwamUrl = gwamUrl;
                                userData.Token = jsonObject["JwtToken"]?.ToString();
                                userData.UserName = jsonObject["AccountName"]?.ToString();
                                userData.SubscriptionKey = subscriptionKey;

                                MessageBox.Show("The login was successful.");
                                return true;
                            }
                            else
                                MessageBox.Show("Login Failed");
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
                    return false;
                }
            }
            return false;
        }
        internal void ValidToken(string GwamUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //@@mmf
                    string localLogoff = "http://localhost:5000/account-manager/isvalidtoken";
                    //string WebLogoff = "http://localhost:60000/account-manager/isvalidtoken";
                    HttpRequestMessage request;
                    if (GwamUrl == string.Empty)
                        request = new HttpRequestMessage(HttpMethod.Post, localLogoff);//WebLogoff
                    else
                        request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/isvalidtoken");
                    //@@mmf end
                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/isvalidtoken");
                    MagoCloudApiManager.PrepareHeaders(request, userData, DateTime.Now);
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
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

        internal void DoLogout(string GwamUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //@@mmf
                    string localLogoff = "http://localhost:5000/account-manager/logoff";
                    //string WebLogoff = "http://localhost:60000/account-manager/logoff";
                    HttpRequestMessage request;
                    if (GwamUrl == string.Empty)
                        request = new HttpRequestMessage(HttpMethod.Post, localLogoff);//WebLogoff
                    else
                        request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/logoff");
                    //@@mmf end
                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/logoff");
                     MagoCloudApiManager.PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
                     MagoCloudApiManager.PrepareHeaderAutorization(request, userData);

                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
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
