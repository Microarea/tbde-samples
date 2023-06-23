using EnvDTE;
using EnvDTE90;
//using MagicLinkTester.Libraries;
//using Microarea.Tbf.Model.API;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Windows.Documents;

namespace MagoCloudApi
{
   
    //=======================================================================================================================
    internal class TbFsServiceManager
    {
        public string selApp { get; set; }
        public string selMod { get; set; }
        public string selDoc { get; set; }
        public string selProfile { get; set; }
        public string DefaultDocumentParameters { get; set; }="<?xml version=\"1.0\" encoding=\"utf-8\"?><maxs:{0} tbNamespace=\"{1}\" xTechProfile=\"{2}\" xmlns:maxs=\"{3}\"><maxs:Parameters></maxs:Parameters></maxs:{0}>";
        public string DefaultUri { get; set; }= "http://www.microarea.it/Schema/2004/Smart";
        public string DefaultUser { get; set; } = "Standard";

        public List<string> DocumentNamespace { get; set; }
        public List<string> DocumentPath { get; set; }
        public string CurrentDocNS { get; set; }
        public string CurrentPath { get; set; }
        public string Path { get; set; } = string.Empty;
        private static readonly HttpClient _httpClient = new HttpClient();
        //-------------------------------------------------------------------------------------------------------------------


        /////////////////////////////////
        /////// GET APPLICATIONS ////////
        public async Task<List<string>> GetApplications(UserData userData, DateTime operationDate)
        {
            List<string> applist = new List<string>();

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GettAllApplications");
            request.Method = HttpMethod.Post;
            MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

            using (var resp = await _httpClient.SendAsync(request))
            {
                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    return applist;

                JObject jRes = JObject.Parse(ret);
                JToken[] applications = jRes["applications"].ToArray();
                foreach (var item in applications)
                {
                    string name = item["name"].Value<string>();
                    if (string.IsNullOrEmpty(name))
                        continue;

                    applist.Add(name);
                }
                applist.Sort();
                return applist;
            }
        }

        ////////////////////////////
        /////// GET MODULES ////////
        public async Task<List<string>> GetModules(UserData userData, DateTime operationDate, string application)
        {
            List<string> modulelist = new List<string>();
            
            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GetAllModulesByApplication");
            request.Method = HttpMethod.Post;
            MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Content = GetModulesParameters(application);

            using (var resp = await _httpClient.SendAsync(request))
            {
                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    return modulelist;

                JObject jRes = JObject.Parse(ret);
                JToken[] modules = jRes["modules"].ToArray();
                foreach (var item in modules)
                {
                    string name = item["name"].Value<string>();
                    if (string.IsNullOrEmpty(name))
                        continue;
                        modulelist.Add(name);
                }
                return modulelist;
            }
        }
        public static FormUrlEncodedContent GetModulesParameters(string application)
        {
            return new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("appName", application) });
        }

        /////////////////////////////////////
        /////// GET DOCUMENT FOLDERS ////////
        public async Task<(List<string>, List<string>)> GetDocumentsFolders(UserData userData, DateTime operationDate, string application, string module)
        {
            List<string> folderObjects = new List<string>();
            List<string> folderObjectsNS = new List<string>();

            if (string.IsNullOrEmpty(application) || string.IsNullOrEmpty(module))
                return (folderObjects, folderObjectsNS);

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GetSubFolders");
            MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Content = GetModulesParameters(application);
            request.Content = GetDocumentObjectsParameters(application, module);

            using (var resp = await _httpClient.SendAsync(request))
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                    return (folderObjects, folderObjectsNS);

                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    return (folderObjects, folderObjectsNS);

                JObject jRes = JObject.Parse(ret);
                JArray folders = jRes["folders"] as JArray;

                foreach (var item in folders)
                {
                    string ns = item["NameSpace"].ToString();
                    List<string> tokens = ns.Split('.').ToList();
                    tokens.Insert(tokens.Count - 1, "documents");
                    var result = string.Join(".", tokens.ToArray());

                    folderObjectsNS.Add($"{result}");
                    folderObjects.Add((string)item["name"]);
                }
                return (folderObjects, folderObjectsNS);
            }
        }

        public static FormUrlEncodedContent GetDocumentObjectsParameters(string application, string module)
        {
            string ns = $"{application}.{module}";
            return new FormUrlEncodedContent(
                       new[] { new KeyValuePair<string, string>("parentNameSpace", ns),
                       new KeyValuePair<string, string>("type", "ProfileFile"),
                       new KeyValuePair<string, string>("isCreateFolderMode", "false")
                       });
        }


        /////////////////////////////
        /////// GET PROFILES ////////
        public async Task<List<string>> GetProfiles(UserData userData, DateTime operationDate, string application, string module, string folderName)
        {
            
            List<string> profileslist = new List<string>();
          
            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            //msg.RequestUri = new Uri(new Uri(_tbfsServiceUrl), "tbfs-service/GettAllApplications");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/getprofilefolders");
            request.Method = HttpMethod.Post;
            MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Content = GetProfileParameters(application, module, folderName);
            //request.Content = GetTextFileParameters(application, module, folderName, "marco.spazian@zucchetti.com", "DT-0208BD", "it-IT");
            using (var resp = await _httpClient.SendAsync(request))
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                    return profileslist;

                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    return profileslist;

                JObject jRes = JObject.Parse(ret);

                JArray folders = jRes["objects"] as JArray;
                foreach (var item in folders)
                {
                    profileslist.Add(item["name"].ToString());
                }
                profileslist.Sort();
                return profileslist;
            }
        }

        public async Task<List<string>> GetTextFile(UserData userData, DateTime operationDate, string application, string module, string folderName)
        {
            //string path, string folderName
            List<string> profileslist = new List<string>();

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            //msg.RequestUri = new Uri(new Uri(_tbfsServiceUrl), "tbfs-service/GettAllApplications");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/gettextfile");
            request.Method = HttpMethod.Post;
            MagoCloudApiManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            //request.Content = GetProfileParameters(application, module, folderName);
            request.Content = GetTextFileParameters(application, module, folderName, "marco.spazian@zucchetti.com", "DT-0208BD", "it-IT");

            using (var resp = await _httpClient.SendAsync(request))
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                    return profileslist;

                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    return profileslist;

                JObject jRes = JObject.Parse(ret);

                //JArray folders = jRes["objects"] as JArray;
                //foreach (var item in folders)
                //{
                //    profileslist.Add(item["name"].ToString());
                //}
                //profileslist.Sort();
                return profileslist;
            }
        }

        public static FormUrlEncodedContent GetProfileParameters(string application, string module, string folderName)
        {
            string parentPath = application + "." + module;
            return new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("path", parentPath), new KeyValuePair<string, string>("folderName", folderName) });
        }
        public static FormUrlEncodedContent GetTextFileParameters(string application, string module, string folderName, string user, string company, string culture)
        {
            //(string nameSpace, string user, string company, string culture
            string ns = application + "." + module + ".ModuleObjects";
            return new FormUrlEncodedContent(new[] { 
                new KeyValuePair<string, string>("namespace", ns),
                new KeyValuePair<string, string>("user", user),
                new KeyValuePair<string, string>("company", company),
                new KeyValuePair<string, string>("culture", culture)
            });
        }

    }
    
}
