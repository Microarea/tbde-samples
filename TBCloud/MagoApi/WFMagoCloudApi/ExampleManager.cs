using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagoCloudApi;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI;
using Image = System.Drawing.Image;
using System.IO;

namespace MagoCloudApi
{
    class ExampleManager
    {

        public string ExampleTb()
        {
            string codeGet = "\n" + "Declaration request:\r\n" +
                          "HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, userData.GwamUrl + \"/gwam_mapper/api/services/url/\" + userData.SubscriptionKey + \"/REPORTSERVICE\");\r\n" +
                          "MagoCloudApiManager.PrepareHeaders(request, userData;\r\n " +
                          "Preparation headers:\r\n" +
                          "internal static void PrepareHeaders(HttpRequestMessage request, UserData userData)\r\n        {\r\n var credential = new JObject\r\n                    {\r\n                        { \"type\", \"JWT\"},\r\n                        { \"AppId\", \"MagoAPI\" },\r\n                        { \"securityValue\", userData.Token }\r\n                    };\r\n            string credentialJsonInString = JsonConvert.SerializeObject(credential);\r\n            request.Headers.TryAddWithoutValidation(\"Authorization\", credentialJsonInString);\r\n\r\n            var snapshotData = JsonConvert.SerializeObject(new\r\n            {\r\n                SubscriptionKey = userData.SubscriptionKey,\r\n                Token = userData.Token\r\n            });\r\n\r\n            request.Headers.TryAddWithoutValidation(\"Content-Type\", \"application/json\");\r\n            request.Headers.TryAddWithoutValidation(\"Snapshot\", snapshotData);\r\n            MagoCloudApiManager.PrepareMagoAPIHeader(request, userData.Producer, userData.AppKey);\r\n        }\r\n\r\n        internal static void PrepareMagoAPIHeader(HttpRequestMessage request, string producerKey, string appKey)\r\n        {\r\n            var producerData = new JObject\r\n                {\r\n                    {\"ProducerKey\",producerKey},\r\n                    {\"AppKey\",appKey }\r\n                };\r\n            string dJsonInString = JsonConvert.SerializeObject(producerData);\r\n            request.Headers.TryAddWithoutValidation(\"MagoAPI\", dJsonInString);\r\n        }\n" +
                          "request.Content = new StringContent(jsonInString, System.Text.Encoding.UTF8, \"application/json\");\n" +
                          "var response = await client.SendAsync(request)";
            return codeGet;
        }
        public void LoadImage(string imagePath)
        {
            string imageName = "retrivetb.png";
            try
            {
                // Carica l'immagine dal percorso specificato
                Image image = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Img", imageName)));

                // Fai qualcosa con l'immagine (ad esempio, visualizzala a video)
                Console.WriteLine($"Immagine caricata con successo: {Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Img", imageName))}");

                // Rilascia la risorsa dell'immagine
                image.Dispose();
            }
            catch (Exception ex)
            {
                // Gestione dell'errore
                Console.WriteLine($"Errore durante il caricamento dell'immagine: {ex.Message}");
            }
        }
    }
}



