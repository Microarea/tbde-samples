using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace TbApiTester
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
            UrlSManager.DmMMSUrl = string.Empty;
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
    public class SubscriptionInfo
    {
        public SubscriptionInfo(string subscriptionKey, string description)
        {
            SubscriptionKey = subscriptionKey;
            Description = description;
        }
        public string Description { get; set; }
        public string SubscriptionKey { get; set; }
    }
    internal class AuthenticationManager
    {
        internal UserData userData = new UserData();
        public string _responseBody;

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


        // logIn2.5
        //internal bool DoLogin(string gwamUrl,string userName, string pwd, string subscriptionKey, string producerKey, string appKey)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //           userData. Producer = producerKey;
        //           userData. AppKey = appKey;
        //            // @@mmf
        //            string localLogin = "http://localhost:5000/account-manager/login";


        //            // the URL to access MagoWeb is the following
        //            //string magoWebLogin = "https://gwam.mago.cloud";
        //            // the URL to access MagoWeb 5.0 is the following 
        //            string MagoWebLogin50 = "http://localhost:60000/mw-console/api/login";

        //            HttpRequestMessage request;
        //            if (gwamUrl == string.Empty)
        //                request = new HttpRequestMessage(HttpMethod.Post, MagoWebLogin50);
        //            else
        //                request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
        //            //@@mmf end

        //            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
        //            TbApiTesterManager.PrepareHeaderMagoAPI(request, producerKey, appKey);
        //            //// Request a credential ////
        //            var credential = new JObject
        //                        {
        //                            { "GwamUrl", gwamUrl},
        //                            { "AccountName", userName},
        //                            { "Password", pwd},
        //                            { "Token", "" },
        //                            { "AppId", "MagoAPI"},
        //                            { "SubscriptionKey", subscriptionKey},
        //                            { "ProducerKey", ""},
        //                            { "AppKey", ""}
        //                        };
        //            string requestJsonInString = JsonConvert.SerializeObject(credential);
        //            request.Content = new StringContent(requestJsonInString, System.Text.Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;


        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                //// recovery autentication token ////
        //                _responseBody = response.Content.ReadAsStringAsync().Result;
        //                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(_responseBody);
        //                if (jsonObject != null)
        //                {
        //                    string resultVariable = jsonObject["Result"]?.ToString();
        //                    string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
        //                    if (resultVariable == "True" && resultCodeVariable == "0")
        //                    {
        //                        userData.GwamUrl = gwamUrl;
        //                        userData.Token = jsonObject["JwtToken"]?.ToString();
        //                        userData.UserName = jsonObject["AccountName"]?.ToString();
        //                        userData.SubscriptionKey = subscriptionKey;

        //                        MessageBox.Show("The login was successful.");
        //                        return true;
        //                    }
        //                    else
        //                        MessageBox.Show("Login Failed");
        //                }
        //                else
        //                    MessageBox.Show("Login reported a invalid content.");
        //            }
        //            else
        //                MessageBox.Show("We were unable to connect to the MagoCloud login. Verify login credential");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine("\nException Caught!");
        //            Console.WriteLine("Message :{0} ", e.Message);
        //            return false;
        //        }
        //    }
        //    return false;
        //}


        internal bool DoLogin(string gwamUrl, string userName, string pwd, string subscriptionKey, string producerKey, string appKey)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    userData.Producer = producerKey;
                    userData.AppKey = appKey;

                    string MagoWebLogin50 = "http://localhost:60000/mw-console/api/login";
                    string mwConsoleApi = "http://localhost:60000/mw-console/api";

                    HttpRequestMessage request;
                    
                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        HttpResponseMessage checkResponse = client.GetAsync(mwConsoleApi).Result;

                        if (checkResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            // Use MagoWebLogin  for 5.0
                            request = new HttpRequestMessage(HttpMethod.Post, MagoWebLogin50);
                            MessageBox.Show("You are in 5.0 Version\nNow for logIn use mw-console service:\n" + MagoWebLogin50);
                        }
                        else
                        {
                            // Use gwamUrl 2.5 
                            if (string.IsNullOrEmpty(gwamUrl))
                            {
                                MessageBox.Show(mwConsoleApi.ToString());
                                return false;
                            }
                            request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                        }
                    }
                    else
                    {
                        // Usa gwamUrl direttamente per altri stati del pulsante
                        if (string.IsNullOrEmpty(gwamUrl))
                        {
                            MessageBox.Show("Invalid GWAM URL.");
                            return false;
                        }
                        request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                    }

                    TbApiTesterManager.PrepareHeaderMagoAPI(request, producerKey, appKey);

                    var credential = new JObject
            {
                { "GwamUrl", gwamUrl },
                { "AccountName", userName },
                { "Password", pwd },
                { "Token", "" },
                { "AppId", "MagoAPI" },
                { "SubscriptionKey", subscriptionKey },
                { "ProducerKey", "" },
                { "AppKey", "" }
            };

                    string requestJsonInString = JsonConvert.SerializeObject(credential);
                    request.Content = new StringContent(requestJsonInString, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        _responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(_responseBody);
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
                            {
                                MessageBox.Show("Login Failed");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login reported invalid content.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("We were unable to connect to the MagoCloud login. Verify login credentials.");
                    }
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

        //ValidToken 2.5
        //internal void ValidToken(string GwamUrl)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            //@@mmf
        //            string localIsvalidtoken = "http://localhost:5000/account-manager/isvalidtoken";
        //            //string WebLogoff = "http://localhost:60000/account-manager/isvalidtoken";
        //            HttpRequestMessage request;
        //            if (GwamUrl == string.Empty)
        //                request = new HttpRequestMessage(HttpMethod.Post, localIsvalidtoken);//WebLogoff
        //            else
        //                request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/isvalidtoken");
        //            //@@mmf end
        //            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/isvalidtoken");
        //            TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);
        //            request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                //// recovery autentication token ////
        //                string responseBody = response.Content.ReadAsStringAsync().Result;
        //                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);
        //                if (jsonObject != null)
        //                {
        //                    string resultVariable = jsonObject["Result"]?.ToString();
        //                    string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
        //                    if (resultVariable == "True")
        //                    {
        //                        MessageBox.Show("The token is valid");
        //                    }
        //                }
        //                else
        //                    MessageBox.Show("Token is no longer valid.");
        //            }
        //            else
        //                MessageBox.Show("Unable to retrive the token.");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine("\nException Caught!");
        //            Console.WriteLine("Message :{0} ", e.Message);
        //        }
        //    }
        //}


        internal void ValidToken(string GwamUrl)//ValidToken 5.0
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string localIsValidToken = "http://localhost:5000/account-manager/isvalidtoken";
                    string mwConsoleIsValidToken = "http://localhost:60000/mw-console/api/isvalidtoken";

                    HttpRequestMessage request;

                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        request = new HttpRequestMessage(HttpMethod.Post, mwConsoleIsValidToken);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(GwamUrl))
                        {
                            request = new HttpRequestMessage(HttpMethod.Post, localIsValidToken);
                        }
                        else
                        {
                            request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/isvalidtoken");
                        }
                    }


                    TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            if (resultVariable == "True")
                            {
                                MessageBox.Show("The token is valid");
                                return;
                            }
                        }

                        MessageBox.Show("Token is no longer valid.");
                    }
                    else
                    {
                        MessageBox.Show("Unable to retrieve the token.");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }

        //LogOut2.5
        //internal void DoLogout(string GwamUrl)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            //@@mmf
        //            string localLogoff = "http://localhost:5000/account-manager/logoff";
        //            //string WebLogoff = "http://localhost:60000/account-manager/logoff";
        //            HttpRequestMessage request;
        //            if (GwamUrl == string.Empty)
        //                request = new HttpRequestMessage(HttpMethod.Post, localLogoff);//WebLogoff
        //            else
        //                request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/logoff");
        //            //@@mmf end
        //            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/logoff");
        //            TbApiTesterManager.PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
        //            TbApiTesterManager.PrepareHeaderAutorization(request, userData);

        //            request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");
        //            HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                //// recovery autentication token ////
        //                string responseBody = response.Content.ReadAsStringAsync().Result;
        //                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

        //                if (jsonObject != null)
        //                {
        //                    string resultVariable = jsonObject["Result"]?.ToString();
        //                    string resultCodeVariable = jsonObject["ResultCode"]?.ToString();
        //                    if (resultVariable == "True")
        //                    {
        //                        userData.Clear();
        //                        MessageBox.Show("The User has been successfully disconnected.");
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Logout reported invalid content.");
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("We were unable to logout from MagoCloud.");
        //            }
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            MessageBox.Show($"HTTP Request Exception: {e.Message}");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Unexpected error: {ex.Message}");
        //        }
        //    }
        //}

        internal void DoLogout(string GwamUrl) //logIn5.0
        {
            if (string.IsNullOrEmpty(userData.Token)) 
            {
                MessageBox.Show("No user is logged in.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string localLogoff = "http://localhost:5000/account-manager/logoff";
                    string mwConsoleLogoff = "http://localhost:60000/mw-console/api/logoff";

                    HttpRequestMessage request;

                    //  GlobalSettings.CurrentButtonState
                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        // mw-console 
                        request = new HttpRequestMessage(HttpMethod.Post, mwConsoleLogoff);
                    }
                    else
                    {
                        request = string.IsNullOrEmpty(GwamUrl)
                            ? new HttpRequestMessage(HttpMethod.Post, localLogoff)
                            : new HttpRequestMessage(HttpMethod.Post, GwamUrl + "/gwam_login/api/logoff");
                    }

                    TbApiTesterManager.PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);

                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonObject != null)
                        {
                            string resultVariable = jsonObject["Result"]?.ToString();
                            if (resultVariable == "True")
                            {
                                userData.Clear();
                                MessageBox.Show("The user has been successfully disconnected.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        MessageBox.Show("Logout reported invalid content.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("We were unable to logout from MagoCloud.", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"HTTP Request Exception: {e.Message}", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Logout Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
