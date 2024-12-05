//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Eco.Persistence;
using System.Web.Mvc;
using Newtonsoft.Json;


namespace TbApiTester
{

    //=======================================================================================================================
    internal class TbFsServiceManager
    {
        public string selApp { get; set; }
        public string selMod { get; set; }
        public string selDoc { get; set; }
        public string selProfile { get; set; }
        public string DefaultDocumentParameters { get; set; } = "<?xml version=\"1.0\" encoding=\"utf-8\"?><maxs:{0} tbNamespace=\"{1}\" xTechProfile=\"{2}\" xmlns:maxs=\"{3}\"><maxs:Parameters></maxs:Parameters></maxs:{0}>";
        public string DefaultUri { get; set; } = "http://www.microarea.it/Schema/2004/Smart";
        public string DefaultUser { get; set; } = "Standard";
        public string AllUser { get; set; } = "AllUsers";

        public List<string> DocumentNamespace { get; set; }
        public List<string> DocumentPath { get; set; }
        public string CurrentDocNS { get; set; }
        public string CurrentPath { get; set; }
        public string Path { get; set; } = string.Empty;
        private static readonly HttpClient _httpClient = new HttpClient();

        public string selDocObj { get; set; }
        public string folderPath { get; set; }
        //-------------------------------------------------------------------------------------------------------------------


        /////////////////////////////////
        /////// GET APPLICATIONS ////////
        public async Task<List<string>> GetApplications(UserData userData, DateTime operationDate)
        {
            selApp = string.Empty;
            UrlSManager.TbFsServiceUrl = string.Empty;
            List<string> applist = new List<string>();

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GettAllApplications");
            request.Method = HttpMethod.Post;
            TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
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
            selMod = string.Empty;
            List<string> modulelist = new List<string>();

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "")
                UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GetAllModulesByApplication");
            request.Method = HttpMethod.Post;
            TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Content = GetModulesParameters(application);

            try
            {
                using (var resp = await _httpClient.SendAsync(request))
                {
                    resp.EnsureSuccessStatusCode(); // Verifica che la risposta HTTP sia valida.

                    string responseContent = await resp.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseContent))
                    {
                        Console.WriteLine("La risposta è vuota.");
                        return modulelist; // Restituisce una lista vuota.
                    }

                    JObject jsonResponse = JObject.Parse(responseContent);
                    JToken[] modules = jsonResponse["modules"]?.ToArray() ?? Array.Empty<JToken>();

                    if (modules.Length == 0)
                    {
                        Console.WriteLine("L'array dei moduli è vuoto.");
                        return modulelist; // Restituisce una lista vuota.
                    }

                    foreach (var item in modules)
                    {
                        string name = item["name"]?.Value<string>();
                        if (!string.IsNullOrEmpty(name))
                        {
                            modulelist.Add(name);
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Errore nella richiesta HTTP: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Errore nel parsing del JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }

            return modulelist;
        }
        public static FormUrlEncodedContent GetModulesParameters(string application)
        {
            return new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("appName", application) });
        }

        /////////////////////////////////////
        /////// GET DOCUMENT FOLDERS ////////
        public async Task<(List<string>, List<string>)> GetDocumentsFolders(UserData userData, DateTime operationDate, string application, string module)
        {
            selDoc = string.Empty;
            List<string> folderObjects = new List<string>();
            List<string> folderObjectsNS = new List<string>();

            // Verifica parametri obbligatori
            if (string.IsNullOrEmpty(application) || string.IsNullOrEmpty(module))
                return (folderObjects, folderObjectsNS);

            try
            {
                // Recupera URL del servizio
                UrlSManager Urls = new UrlSManager();
                if (UrlSManager.TbFsServiceUrl == string.Empty)
                    UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");

                // Prepara la richiesta HTTP
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GetSubFolders");
                TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

                // Prepara il corpo della richiesta
                request.Content = GetDocumentObjectsParameters(application, module);

                // Invia la richiesta
                using (HttpResponseMessage resp = await _httpClient.SendAsync(request))
                {
                    // Verifica se la risposta è valida
                    if (resp.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine($"Errore nella risposta HTTP: {resp.StatusCode}");
                        return (folderObjects, folderObjectsNS);
                    }

                    // Leggi il contenuto della risposta
                    string responseContent = await resp.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseContent))
                    {
                        Console.WriteLine("La risposta è vuota.");
                        return (folderObjects, folderObjectsNS);
                    }

                    // Parse della risposta JSON
                    JObject jsonResponse = JObject.Parse(responseContent);
                    JArray folders = jsonResponse["folders"] as JArray;

                    if (folders == null || !folders.Any())
                    {
                        Console.WriteLine("Nessuna cartella trovata nella risposta.");
                        return (folderObjects, folderObjectsNS);
                    }

                    // Processa ogni cartella
                    foreach (var item in folders)
                    {
                        string ns = item["NameSpace"]?.ToString();
                        string name = item["name"]?.ToString();

                        if (!string.IsNullOrEmpty(ns) && !string.IsNullOrEmpty(name))
                        {
                            List<string> tokens = ns.Split('.').ToList();
                            tokens.Insert(tokens.Count - 1, "documents");
                            string result = string.Join(".", tokens);

                            folderObjectsNS.Add(result);
                            folderObjects.Add(name);
                        }
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Errore durante la richiesta HTTP: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Errore nel parsing del JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }

            return (folderObjects, folderObjectsNS);
        }

        public async Task<string> GetReferenceObjBasePath(UserData userData, string application, string module)
        {
            folderPath = string.Empty;
            if (string.IsNullOrEmpty(application) || string.IsNullOrEmpty(module))
                throw new ArgumentException("Application and module cannot be null or empty.");

            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/GetSubFolders");
            TbApiTesterManager.PrepareHeaders(request, userData, DateTime.Now);
            request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            request.Content = GetModulesParameters(application);
            request.Content = GetDocumentObjectsParameters(application, module);

            using (var resp = await _httpClient.SendAsync(request))
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                    throw new InvalidOperationException("Failed to retrieve folders.");

                string ret = await resp.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(ret))
                    throw new InvalidOperationException("Empty response.");

                JObject jRes = JObject.Parse(ret);
                JArray folders = jRes["folders"] as JArray;

                foreach (var item in folders)
                {
                    folderPath = item["path"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(folderPath))
                    {
                        string normalizedPath = folderPath.Replace("\\\\", "\\");
                        int appIndex = normalizedPath.IndexOf(application, StringComparison.OrdinalIgnoreCase);
                        if (appIndex > 0)
                        {
                            return System.IO.Path.Combine(
                                normalizedPath.Substring(0, appIndex + application.Length + 1),
                                module,
                                "ReferenceObjects"
                            );
                        }
                    }
                }
                throw new InvalidOperationException("Unable to determine base path.");
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
            selProfile = string.Empty;
            List<string> profilesList = new List<string>();

            // Verifica parametri obbligatori
            if (string.IsNullOrEmpty(application) || string.IsNullOrEmpty(module) || string.IsNullOrEmpty(folderName))
                return profilesList;

            try
            {
                // Recupera URL del servizio
                UrlSManager Urls = new UrlSManager();
                if (UrlSManager.TbFsServiceUrl == string.Empty)
                    UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");

                // Prepara la richiesta HTTP
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, UrlSManager.TbFsServiceUrl + "/tbfs-service/getprofilefolders");
                TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
                request.Headers.TryAddWithoutValidation("Content-Type", "application/json");

                // Prepara il corpo della richiesta
                request.Content = GetProfileParameters(application, module, folderName);

                // Invia la richiesta
                using (HttpResponseMessage resp = await _httpClient.SendAsync(request))
                {
                    // Verifica se la risposta è valida
                    if (resp.StatusCode != HttpStatusCode.OK)
                    {
                        Console.WriteLine($"Errore nella risposta HTTP: {resp.StatusCode}");
                        return profilesList;
                    }

                    // Leggi il contenuto della risposta
                    string responseContent = await resp.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(responseContent))
                    {
                        Console.WriteLine("La risposta è vuota.");
                        return profilesList;
                    }

                    // Parse della risposta JSON
                    JObject jsonResponse = JObject.Parse(responseContent);
                    JArray folders = jsonResponse["objects"] as JArray;

                    if (folders == null || !folders.Any())
                    {
                        Console.WriteLine("Nessun profilo trovato nella risposta.");
                        return profilesList;
                    }

                    // Processa i profili
                    foreach (var item in folders)
                    {
                        string name = item["name"]?.ToString();
                        string customizationType = item["customizationType"]?.ToString();

                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(customizationType))
                        {
                            string elem = $"{name},{customizationType}";
                            if (!customizationType.Equals("Standard", StringComparison.OrdinalIgnoreCase))
                                elem += "s";
                            profilesList.Add(elem);
                        }
                    }
                }

                // Ordina la lista dei profili
                profilesList.Sort();
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Errore durante la richiesta HTTP: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"Errore nel parsing del JSON: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }

            return profilesList;
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
            TbApiTesterManager.PrepareHeaders(request, userData, operationDate);
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

        //public async Task<IActionResult> UploadObject(UserData userData, MultipartFormDataContent files, Microarea.Tbf.Model.Interfaces.API.ObjectType objectType, string currNamespace, string user)
        //{
        //    UrlSManager Urls = new UrlSManager();
        //    if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
        //    string urltbfs = UrlSManager.TbFsServiceUrl + "/tbfs-service/UploadObject";

        //    using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(urltbfs)))
        //    {
        //        request.Content = files;
        //        TbApiTesterManager.PrepareHeaderAutorization(request, userData);
        //        HttpClient httpClient = new HttpClient();
        //        TbResponse opResult = null;
        //        using (var response = await httpClient.SendAsync(request))
        //        {
        //            opResult = new TbResponse();
        //            opResult.StatusCode = (int)response.StatusCode;
        //            string result = await response.Content.ReadAsStringAsync();
        //            //return opResult.StatusCode;
        //            return (IActionResult)opResult;
        //        }
        //    }
        //    throw new NotImplementedException();
        //    //TbResponse opResult = null;
        //    //opResult = new TbResponse();
        //    //return (IActionResult)opResult;
        //}

        //public async Task<IActionResult> UploadObject2(UserData userData, MultipartFormDataContent files)
        //{
        //    //UrlSManager Urls = new UrlSManager();
        //    //if (UrlSManager.TbFsServiceUrl == "") UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(userData, DateTime.Now, "/TBFSSERVICE");
        //    //string urltbfs = UrlSManager.TbFsServiceUrl + "/tbfs-service/UploadObject";

        //    //using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(urltbfs)))
        //    //{
        //    //    request.Content = files;
        //    //    TbApiTesterManager.PrepareHeaderAutorization(request, userData);
        //    //    HttpClient httpClient = new HttpClient();
        //    //    TbResponse opResult = null;
        //    //    using (var response = await httpClient.SendAsync(request))
        //    //    {
        //    //        opResult = new TbResponse();
        //    //        opResult.StatusCode = (int)response.StatusCode;
        //    //        string result = await response.Content.ReadAsStringAsync();
        //    //        //return opResult.StatusCode;
        //    //        return (IActionResult)opResult;
        //    //    }
        //    //}
        //    throw new NotImplementedException();
        //    //IActionResult actionResult = new IActionResult();
        //   string message = $"UploadObject: returnUpload";
        //   return new JsonResult(new { Result = true, Message = message });
        //}


        //// Helper per ottenere i byte di un file
        //private async Task<byte[]> GetFileBytesAsync(IFormFile file)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}

    }

}
