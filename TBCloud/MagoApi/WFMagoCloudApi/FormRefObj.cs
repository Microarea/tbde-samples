using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TbApiTester
{
    public partial class FormRefObj : Form
    {
        private string modifiedXml;
        TbApiTesterManager manager = new TbApiTesterManager();

        public FormRefObj(string content, TbApiTesterManager man)
        {
            InitializeComponent();
            //this.ContainerBtnUpload.Hide();
            this.xmlEditorResult.TextContent = content;
            this.xmlEditorResult.Update();
            this.xmlEditorResult.Show();


            //this.xmlEditorWpfRef.textEditor.Text = content;
            //this.modifiedXml = xmlEditorWpfRef.textEditor.Text = content;

            //this.xmlEditorRef.TextContent = content;
            //this.modifiedXml = xmlEditorRef.TextContent = content; 
            manager = man;

           
        }
        public string GetModifiedXml()
        {
            return modifiedXml;
        }

        private void BtnSaveModifyXml_Click(object sender, EventArgs e)
        {
            //modifiedXml = xmlEditorRef.TextContent;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public enum ObjectType { Document, Report, File, Image, Text, Folder, CreateFolder, CurrentModuleRoot, Setting, Profile, ProfileFile, ReportDescription, ReferenceObject, FormatFont, Pdf, Rtf }

        private async void btnUploadObj_Click(object sender, EventArgs e)
        {
            try
            {
                // Esegui l'upload e ottieni lo stato
                int statusCode = await UploadObject();

                // Mostra il risultato all'utente
                MessageBox.Show($"Upload completato con codice di stato: {statusCode}");
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante l'upload: {ex.Message}");
            }
        }
        // Metodo principale di upload
        private async Task<int> UploadObject()
        {
            // Parametri necessari per l'upload
            string startPath = "";
            string filePath = $@"{manager.tbFsServiceManager.CurrentPath}\{manager.tbFsServiceManager.selDocObj}";
            string currNamespace = manager.tbFsServiceManager.selApp + "." + manager.tbFsServiceManager.selMod;
            string user = "AllUsers";

            // Creazione del contenuto per MultipartFormData
            var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            // Aggiunta dei contenuti al form
            form.Add(fileContent, "files", Path.GetFileName(filePath));
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(ObjectType.ReferenceObject.ToString())), "objectType");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(currNamespace)), "currentNamespace");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(user)), "user");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(startPath)), "startPath");

            // Preparazione URL
            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "")
                UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(manager.authenticationManager.userData, DateTime.Now, "/TBFSSERVICE");

            string urltbfs = UrlSManager.TbFsServiceUrl + "/tbfs-service/UploadObject/";

            // Invio della richiesta HTTP
            using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(urltbfs)))
            {
                request.Content = form;

                // Aggiunta autorizzazioni all'header
                TbApiTesterManager.PrepareHeaderAutorization(request, manager.authenticationManager.userData);

                using (HttpClient httpClient = new HttpClient())
                {
                    TbResponse opResult = null;

                    using (var response = await httpClient.SendAsync(request))
                    {
                        // Creazione della risposta
                        opResult = new TbResponse
                        {
                            StatusCode = (int)response.StatusCode
                        };

                        string result = await response.Content.ReadAsStringAsync();

                        // Log o altre operazioni con il risultato
                        Console.WriteLine($"Risultato dell'upload: {result}");

                        return opResult.StatusCode; // Ritorna il codice di stato
                    }
                }
            }
        }

    }
}
