
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Policy;
//using System.Security.Principal;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Net.WebRequestMethods;

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
        internal string SubscriptionKey { get; set; }
        internal string Producer { get; set; }
        internal string AppKey { get; set; }
        internal string LoginKey { get; set; }

        internal void Clear()
        {
            UrlSManager.TbFsServiceUrl = string.Empty;
            UrlSManager.DmMMSUrl = string.Empty;
            UrlSManager.TbServerUrl = string.Empty;
            UrlSManager.DmsServiceUrl = string.Empty;
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
            LoginKey = string.Empty;
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
                    // Store user data info
                    userData.Producer = producerKey;
                    userData.AppKey = appKey;

                    string MagoWebLogin50 = gwamUrl + "/mw-console/api/login";
                    string mwConsoleApi = gwamUrl + "/mw-console/api";

                    HttpRequestMessage request;

                    // Check if the button state indicates web login
                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        // Validate the URL format before continuing
                        if (!Uri.TryCreate(gwamUrl, UriKind.Absolute, out var uriResult) ||
                            (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
                        {
                            MessageBox.Show("The specified URL is not valid.", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        HttpResponseMessage checkResponse = client.GetAsync(mwConsoleApi).Result;
                        string moduleMessage = GetModules(gwamUrl, userData, DateTime.Now);

                        if (checkResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            // Use new login endpoint for version 5.0+
                            request = new HttpRequestMessage(HttpMethod.Post, MagoWebLogin50);
                            MessageBox.Show("Detected MagoCloud version 5.0 or later.\nUsing login endpoint:\n" + MagoWebLogin50, "Version Detected");
                        }
                        else
                        {
                            // Use legacy login endpoint
                            if (string.IsNullOrEmpty(gwamUrl))
                            {
                                MessageBox.Show(mwConsoleApi, "Missing URL");
                                return false;
                            }
                            request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                        }
                    }
                    else
                    {
                        // Local fallback for test/dev environment
                        if (string.IsNullOrWhiteSpace(gwamUrl))
                        {
                            string localLogin = "http://localhost:5000/account-manager/login";
                            request = new HttpRequestMessage(HttpMethod.Post, localLogin);
                        }
                        else
                        {
                            request = new HttpRequestMessage(HttpMethod.Post, gwamUrl + "/gwam_login/api/login");
                        }
                    }

                    // Add required headers
                    TbApiTesterManager.PrepareHeaderMagoAPI(request, producerKey, appKey);

                    // Prepare login credentials
                    var credential = new JObject
            {
                { "GwamUrl", gwamUrl },
                { "AccountName", userName },
                { "Password", pwd },
                { "Token", "" },
                { "AppId", appKey },
                { "SubscriptionKey", subscriptionKey },
                { "ProducerKey", "" },
                { "AppKey", appKey }
            };

                    string requestJsonInString = JsonConvert.SerializeObject(credential);
                    request.Content = new StringContent(requestJsonInString, System.Text.Encoding.UTF8, "application/json");

                    // Send login request
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
                                // Store session data
                                userData.GwamUrl = gwamUrl;
                                userData.Token = jsonObject["JwtToken"]?.ToString();
                                userData.UserName = jsonObject["AccountName"]?.ToString();
                                userData.SubscriptionKey = subscriptionKey;
                                userData.LoginKey = jsonObject["LoginKey"]?.ToString();

                                MessageBox.Show("Login successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Login failed. Please check your credentials.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The server response content is invalid.", "Invalid Response", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Could not connect to the login service. Please verify your credentials or network connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("An error occurred while sending the HTTP request:\n" + e.Message, "HTTP Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (TaskCanceledException e)
                {
                    MessageBox.Show("The request timed out:\n" + e.Message, "Request Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception e)
                {
                    MessageBox.Show("An unexpected error occurred:\n" + e.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        internal void ValidToken(string gwamUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string localIsValidToken = "http://localhost:5000/account-manager/isvalidtoken";
                    string mwConsoleIsValidToken = gwamUrl + "/mw-console/api/isvalidtoken";
                    string mwConsoleApi = gwamUrl + "/mw-console/api";
                    string requestUrl;

                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        if (client.GetAsync(mwConsoleApi).Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            requestUrl = mwConsoleIsValidToken;
                            MessageBox.Show("You are on Version 5.0 or later\nNow for token validation use mw-console service:\n" + mwConsoleIsValidToken);
                        }
                        else if (string.IsNullOrEmpty(gwamUrl))
                        {
                            MessageBox.Show(mwConsoleApi);
                            return;
                        }
                        else
                        {
                            requestUrl = gwamUrl + "/gwam_login/api/isvalidtoken";
                        }
                    }
                    else
                    {
                        requestUrl = string.IsNullOrEmpty(gwamUrl) ? localIsValidToken : gwamUrl + "/gwam_login/api/isvalidtoken";
                        if (string.IsNullOrEmpty(gwamUrl))
                            MessageBox.Show("Using local validation: " + localIsValidToken);
                    }

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK && JsonConvert.DeserializeObject<JObject>(responseBody)?["Result"]?.ToString() == "True")
                    {
                        MessageBox.Show("The token is valid");
                    }
                    else
                    {
                        MessageBox.Show("Token is no longer valid.");
                    }
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show("Error in ValidToken: " + e.Message);
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

        internal void DoLogout(string gwamUrl)
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
                    string mwConsoleLogoff = gwamUrl + "/mw-console/api/logoff";
                    string mwConsoleApi = gwamUrl + "/mw-console/api";
                    string requestUrl;


                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        if (client.GetAsync(mwConsoleApi).Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            requestUrl = mwConsoleLogoff;
                            MessageBox.Show("You are on Version 5.0 or later\nNow for logoff use mw-console service:\n" + mwConsoleLogoff);
                        }
                        else
                        {
                            requestUrl = gwamUrl + "/gwam_login/api/logoff";
                        }
                    }
                    else
                    {
                        requestUrl = string.IsNullOrEmpty(gwamUrl) ? localLogoff : gwamUrl + "/gwam_login/api/logoff";
                        if (string.IsNullOrEmpty(gwamUrl))
                            MessageBox.Show("Using local validation: " + localLogoff);
                    }

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    TbApiTesterManager.PrepareHeaderMagoAPI(request, userData.Producer, userData.AppKey);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK && JsonConvert.DeserializeObject<JObject>(responseBody)?["Result"]?.ToString() == "True")
                    {
                        userData.Clear();
                        MessageBox.Show("The user has been successfully disconnected.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Logout reported invalid content.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        internal string GetModules(string gwamUrl, UserData userData, DateTime operationDate)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string localGetModules = "http://localhost:5000/account-manager/GetModules";
                    string mwConsoleGetModules = "http://localhost:60000/account-manager/GetModules";
                    string mwConsoleApi = "http://localhost:60000/mw-console/api";
                    string requestUrl;

                    if (GlobalSettings.CurrentButtonState == GlobalSettings.ButtonState.Web)
                    {
                        if (client.GetAsync(mwConsoleApi).Result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            requestUrl = mwConsoleGetModules;
                        }
                        else if (string.IsNullOrEmpty(gwamUrl))
                        {
                            return "MW Console API is unreachable.";
                        }
                        else
                        {
                            requestUrl = "http://localhost:5000/account-manager/GetModules";
                        }
                    }
                    else
                    {
                        requestUrl = string.IsNullOrEmpty(gwamUrl) ? localGetModules : gwamUrl + "/gwam_login/api/GetModules";
                    }

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
                    request.Content = new StringContent(GetTokenForBody(), System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.SendAsync(request).Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(responseBody);

                        if (jsonResponse?["modules"]?["module"] is JArray modulesArray)
                        {
                            bool containsMagoAPI = modulesArray.Any(m => m["name"]?.ToString() == "erp.magoapi");

                            if (!containsMagoAPI)
                            {
                                return "❌ DataManager is disabled." + " The module 'MagoApi' is NOT available.";
                            }
                            // If the module exists, return an empty string (no error message)
                            return "";
                        }
                        else
                        {
                            return "⚠️ Invalid response format: 'modules' array not found.";
                        }
                    }
                    else
                    {
                        return "❌ Token is no longer valid.";
                    }
                }
                catch (HttpRequestException e)
                {
                    return "❌ Error in GetModules: " + e.Message;
                }
            }
        }

    }
}
