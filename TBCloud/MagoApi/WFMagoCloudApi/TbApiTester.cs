using System;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;


namespace TbApiTester
{
    public partial class TbApiTester : Form
    {
        //UrlSManager isCloud = new UrlSManager();
        TbApiTesterManager manager = new TbApiTesterManager();
        UiManagerApi uiManager = new UiManagerApi();
        private CbxUi cbxUi;
        public bool IsCloudButtonClicked { get; set; }
        private bool isLoggedIn = false;
        private readonly LabelManager labelManager;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWhidthEllipse,
           int nHeightEllipse
           );

        internal string FileName { get; set; }
        private List<string> Request { get; set; }
        public object docinfo { get; private set; }

        bool mousedown;
        public long defPriceHandle = 0;
        public System.Diagnostics.Process p = null;
        private string folderPath = @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\Docs";
        private string inFileName;
        private string outFileName;
        private bool isFolderOpened = false;
        private bool isFullScreen = false;
        private string tableName;
        TbResponse m_GetBoResponse;
        TbResponse m_UpdateBoResponse;
        private string isClickedStart;
        private XDocument loadedXmlDocument;
        public string CurrentPath { get; set; }

        public TbApiTester(bool isCloudButtonClicked)
        {
            InitializeComponent();
            uiManager.SetControls(this.Controls);
            labelManager = new LabelManager(this);
            labelManager.InitializeLabels();
            cbxUi = new CbxUi(cbxApplication, cbxModule, cbxDocReport, cbxProfile, cbxArchiveType);
            btnTbfs.MouseHover += new EventHandler(cbxUi.BtnTbfs_MouseHover);
            btnTbfs.MouseLeave += new EventHandler(cbxUi.BtnTbfs_MouseLeave);
            textBoxArchiveType.MouseHover += new EventHandler(cbxUi.BtnTbfs_MouseHover);
            textBoxArchiveType.MouseLeave += new EventHandler(cbxUi.BtnTbfs_MouseLeave);
            this.cbxServicesWeb.Visible = false;
            var buttonState = GlobalSettings.CurrentButtonState;
            switch (buttonState)
            {
                case GlobalSettings.ButtonState.DevEnv:
                    text_http.Text = "https://test-gwam.mago.cloud";
                    Http_label.Text = "MagoDevEnv authentication authority URL";
                    uiManager.ReplaceColor(Color.FromArgb(232, 159, 0), Color.FromArgb(173, 92, 174));
                    pictureBoxLogo.Image = Properties.Resources.DevEnvBtn;
                    break;

                case GlobalSettings.ButtonState.Web:
                    text_http.Text = "https://gwam.mago.cloud";
                    Http_label.Text = "MagoWeb authentication authority URL";
                    uiManager.ReplaceColor(Color.FromArgb(232, 159, 0), Color.FromArgb(176, 205, 66));
                    this.cbxServicesWeb.Visible = true;
                    pictureBoxLogo.Image = Properties.Resources.MagoWeb;
                    PopulateServicesComboBox();//____Service List MagoWeb
                    break;

                case GlobalSettings.ButtonState.Cloud:
                    text_http.Text = "https://gwam.mago.cloud";
                    Http_label.Text = "MagoCloud authentication authority URL";
                    pictureBoxLogo.Image = Properties.Resources.MagoCloud;
                    break;
            }


            IsCloudButtonClicked = isCloudButtonClicked;
            btnClearText.Visible = false;
            manager.tbServerManager.folderPath = folderPath;
            cbxSelectionType.Items.Add("AddQueryHere");
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.tabNavigation.TabPages.Remove(this.tabMSH);
            this.tabNavigation.TabPages.Remove(this.TabBusinessObject);
            this.cbxSelectionType.SelectedIndex = 0;
            cbxSelectionType.DropDownStyle = ComboBoxStyle.DropDown;
            this.comboBoxQuery.SelectedIndex = 0; 
            this.SearchMethod.Visible = false;
            this.lblCaseSensitive.Visible = false;
            this.IsCloudButtonClicked = this.IsCloudButtonClicked;
            btnExploreReport.Hide();
            DynamicQueriesPanel.Hide();
            btnAccount.Hide();

        }


        public void UpdatePictureBoxImage(System.Drawing.Image newImage)
        {
            pictureBoxLogo.Image = newImage;
        }

        private void MagoCloudApi_Load(object sender, EventArgs e)
        {
            // Text Tooltip
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.SetToolTip(BtnRefDoc, "Refresh folder");
            myToolTip.SetToolTip(BtnOpenFolder, "Open folder");
            myToolTip.SetToolTip(BtnQuestionCall, "Questions about calls?");
            myToolTip.SetToolTip(BtnFillContent, "Resize TabControl");
            myToolTip.SetToolTip(btnClearText, "Clear Result Window");
            myToolTip.SetToolTip(btnAccount, "Account Info");
            myToolTip.SetToolTip(button_exit, "MagoCloud / MagoWeb / Development Environment");
            myToolTip.SetToolTip(btnTbfs, "TBFSSERVICE");
            myToolTip.SetToolTip(btnExploreReport, "Open Report Pdf folder ");

            cbxServicesWeb.Items.Add("MagoWebServices");
            cbxServicesWeb.SelectedIndex = 0;

            cbxApplication.Items.Add("Application");
            cbxApplication.SelectedIndex = 0;

            cbxModule.Items.Add("Module");
            cbxModule.SelectedIndex = 0;

            cbxDocReport.Items.Add("Document");
            cbxDocReport.SelectedIndex = 0;

            cbxProfile.Items.Add("Profile");
            cbxProfile.SelectedIndex = 0;
        }

        //////////// customize draggable
        private void panelTitleForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }
        private void panelTitleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X - 500;
                int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);
            }
        }

        private void panelTitleForm_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        //////////// customize tabControl
        private void tabNavigation_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush tabBrush;
            Brush brush;
            if (e.Index == tabNavigation.SelectedIndex)
            {
                brush = new SolidBrush(Color.FromArgb(22, 118, 186));
                tabBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
            }
            else
            {
                brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                tabBrush = new SolidBrush(Color.FromArgb(22, 118, 186));
            }
            string tabName = tabNavigation.TabPages[e.Index].Text;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.FillRectangle(brush, e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            paddedBounds = new Rectangle(paddedBounds.X, paddedBounds.Y + 5, paddedBounds.Width, paddedBounds.Height - 4);
            Font tabFont = new Font("Century Gothic", 9, FontStyle.Bold);
            RectangleF tf =
                new RectangleF(paddedBounds.X + paddedBounds.Width + 428,
                paddedBounds.Y - 1, this.Width - (paddedBounds.X + paddedBounds.Width) - 1, paddedBounds.Height + 11);
            Brush b;
            b = new SolidBrush(Color.FromArgb(22, 118, 186));
            e.Graphics.DrawString(tabName, tabFont, tabBrush, paddedBounds, stringFormat);
            e.Graphics.FillRectangle(b, tf);
        }

        private void OpenVisualStudio(string solutionPath, string filePath)
        {
            // string vsPath = @"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe";
            string args = $"\"{solutionPath}\" \"{filePath}\"";
            //Process.Start(vsPath, "/edit " + args);  
            //Process p = new Process();
            /* p.StartInfo.FileName = solutionPath;*/

            if (p == null)
            {
                p = System.Diagnostics.Process.Start(solutionPath, filePath);
                System.Threading.Thread.Sleep(2000);
                p.StartInfo.FileName = filePath;
                p.Start();
            }
            else
            {
                p.StartInfo.FileName = filePath;
                bool id = p.Start();
            }

        }
        ///////////////////////
        ///// FORM BTN ////////
        ///////////////////////

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            DoExit();
            System.Windows.Forms.Application.Exit();
        }

        private void btnReduceIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnWindowMax_Click(object sender, EventArgs e)
        {
            if (isFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                isFullScreen = false;
            }
            else
            {
                if (BtnFillContent.Text == "⬅")//chiude LoginPanel
                {
                    tabNavigation.Dock = DockStyle.Fill;
                    LoginPanel.Dock = DockStyle.Top | DockStyle.Bottom;
                }
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                // Rendi gli angoli arrotondati
                int radius = 20;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
                this.Region = new Region(path);
                isFullScreen = true;
            }
        }

        private void FillContent_Click(object sender, EventArgs e)
        {
            if (BtnFillContent.Text == "⬅")//close LoginPanel
            {
                BtnFillContent.Text = "➡";
                tabNavigation.Dock = DockStyle.Fill;
                LoginPanel.Dock = DockStyle.None;

            }
            else//apre LoginPanel
            {
                BtnFillContent.Text = "⬅";
                LoginPanel.Dock = DockStyle.Top | DockStyle.Bottom;
            }
        }

        ///////////////////////////////
        ///// AUTHENTUCATION BTN //////
        ///////////////////////////////

        private void button_Login_Click(object sender, System.EventArgs e)
        {
            bool bok = false;

            if (AreParametersOk())
            {
                bok = manager.authenticationManager.DoLogin(text_http.Text, text_user.Text, text_pwd.Text, text_subscription.Text, text_producer.Text, text_app.Text);
                if (bok)
                {
                    LoadEnumsTable();
                       _= FillApplications();
                        FillApplicationsRObj();

                    button_Login.ForeColor = Color.White;
                    button_Login.BackColor = Color.Green;
                    button_Login.Text = "Ok";
                    btnAccount.Visible = true;
                    labelMessage.Text = string.Empty;
                }
                else
                {
                    string responseContent = manager.authenticationManager._responseBody.ToString();
                    JObject jsonObject = JObject.Parse(responseContent);
                    string message = jsonObject["Message"]?.ToString();
                    if (!string.IsNullOrEmpty(message))
                    {
                        message = message.Replace(":", ":\n");
                    }
                    labelMessage.Text = message;
                    button_Login.BackColor = Color.Firebrick;
                    btnAccount.Visible = false;
                }
            }
        }

        private void button_Token_Click(object sender, EventArgs e)
        {
            if (manager.authenticationManager.IsLogged())
                manager.authenticationManager.ValidToken(text_http.Text);
            else
                MessageBox.Show("User is not logged, please Login!");
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            DoExit();
            this.Hide();
            StartMagoApi startForm = new StartMagoApi();
            startForm.ShowDialog();
            this.Close();
        }
        private void button_Logout_Click(object sender, EventArgs e)
        {
            if (manager.authenticationManager.IsLogged())
            {
                manager.authenticationManager.DoLogout(text_http.Text);
                button_Login.Text = "Login";
                button_Login.BackColor = Color.FromArgb(22, 118, 186);
                btnAccount.Visible = false;
            }
            else
            {
                MessageBox.Show("User is not logged, please Login!");
            }
        }
        private void DoExit()
        {
            manager.authenticationManager.DoLogout(text_http.Text);
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            string responseContent = manager.authenticationManager._responseBody.ToString();
            JObject jsonObject = JObject.Parse(responseContent);
            JToken rolesToken = jsonObject["Roles"];
            string accountName = jsonObject["AccountName"]?.ToString();
            string subscriptionKey = jsonObject["SubscriptionKey"]?.ToString();
            string fullName = jsonObject["FullName"]?.ToString();
            bool isAdmin = jsonObject["IsAdmin"]?.Value<bool>() ?? false;
            if (rolesToken == null || rolesToken.Type != JTokenType.Array)
            {
                ShowResult($"Account Name: {accountName}\nSubscriptionKey: {subscriptionKey}\nFull Name: {fullName}\nIs Admin: {isAdmin}\n\nRole = Null\n you are in DevEnv");
                return;
            }
            JArray rolesArray = (JArray)jsonObject["Roles"];

            List<string> roleNames = new List<string>();
            foreach (var role in rolesArray)
            {
                string roleName = role["RoleName"]?.ToString();
                if (roleName != null)
                {
                    roleNames.Add(roleName);
                }
            }
            string rolesDisplay = string.Join(Environment.NewLine, roleNames);
            ShowResult($"Account Name: {accountName}\nSubscriptionKey: {subscriptionKey}\nFull Name: {fullName}\nIs Admin: {isAdmin}\n\nRole Names:\n{rolesDisplay}");
        }
        ////////////////////////
        ///// RESULT WINDOW ////
        ////////////////////////
        private void ShowResult(string content, bool bOk = true, bool bBlue = false, bool bHelp = false)
        {

            Form form = new WindowsFormsResult.FormResult(content, bOk, bBlue, bHelp);
            form.ShowDialog(this);
            Cursor = Cursors.Default;
        }


        ////////////////////////
        ///// TBSERVER BTN /////
        ////////////////////////
        private void BtnQuestionCall_Click(object sender, EventArgs e)
        {
            string content =
            "- GetXmlParams: retrieves the whole list of parameters useful for performing the GetXmlData\n" +
            "- GetXmlData: retrives the entire business object data defined in the export profile.\n" +
            "- SetXmlData: allows the data of a business object to be written to MagoCloud using the Xml payload.";
            ShowResult(content, false, true, true);
        }
        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(folderPath);
            foreach (System.Diagnostics.Process process in processes)
            {
                if (process.MainWindowTitle.Contains(folderPath))
                {
                    MessageBox.Show("La cartella è già aperta", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            System.Diagnostics.Process.Start(folderPath);
        }
        // COMBOBOX TBFSSERVICE MANAGER
        //___________________________________________________________
        private async void cbxApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selApp = (cbxApplication.SelectedItem == null) ? string.Empty : cbxApplication.SelectedItem.ToString();


            if (manager.tbFsServiceManager.selApp != "Application")
                await FillModules(manager.tbFsServiceManager.selApp);

        }
        //___________________________________________________________
        private async void cbxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selMod = (cbxModule.SelectedItem == null) ? string.Empty : cbxModule.SelectedItem.ToString();


            if (manager.tbFsServiceManager.selMod != "Module")
            {
                string application = manager.tbFsServiceManager.selApp;
                string module = manager.tbFsServiceManager.selMod;
                if (manager.tbFsServiceManager.DocumentPath != null && manager.tbFsServiceManager.DocumentPath.Count > 0 && cbxModule != null && cbxModule.SelectedIndex > -1)
                {
                    manager.tbFsServiceManager.CurrentDocNS = manager.tbFsServiceManager.DocumentNamespace[cbxDocReport.SelectedIndex];
                }
                await FillDocuments(application, module);

            }
        }
        //___________________________________________________________
        private async void cbxDocReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selDoc = (cbxDocReport.SelectedItem == null) ? string.Empty : cbxDocReport.SelectedItem.ToString();


            if (manager.tbFsServiceManager.selDoc != "Document")
            {
                string application = manager.tbFsServiceManager.selApp;
                string module = manager.tbFsServiceManager.selMod;
                string folderName = manager.tbFsServiceManager.selDoc;
                if (manager.tbFsServiceManager.DocumentNamespace != null && manager.tbFsServiceManager.DocumentNamespace.Count > 0 && cbxDocReport != null && cbxDocReport.SelectedIndex > -1)
                {
                    manager.tbFsServiceManager.CurrentDocNS = manager.tbFsServiceManager.DocumentNamespace[cbxDocReport.SelectedIndex - 1];
                }
                await FillProfiles(application, module, folderName);
            }
        }
        //___________________________________________________________
        private void cbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userProfile = (cbxProfile.SelectedItem == null) ? string.Empty : cbxProfile.SelectedItem.ToString();

            string[] subs = userProfile.Split(',');

            manager.tbFsServiceManager.selProfile = (subs[0] == null) ? string.Empty : subs[0];
            manager.tbFsServiceManager.DefaultUser = (subs.Count() == 1) ? string.Empty : subs[1];
            //manager.tbFsServiceManager.selProfile = (cbxProfile.SelectedItem == null) ? string.Empty : cbxProfile.SelectedItem.ToString();

            if (manager.tbFsServiceManager.selProfile != "Profile")
            {
                //manager.tbFsServiceManager.selProfile = (cbxProfile.SelectedItem == null) ? string.Empty : cbxProfile.SelectedItem.ToString();
            }
        }


        private void BtnRefDoc_Click(object sender, EventArgs e)
        {
            BtnRefDoc.ForeColor = Color.FromArgb(65, 192, 146);
        }


        private string GetXmlContent()
        {
            // Restituisci il contenuto attuale dell'editor
            return xmlEditorWpfTb.textEditor.Text;
        }

        private void SetXmlContent(string content)
        {
            // Aggiungi contenuto all'editor
            xmlEditorWpfTb.textEditor.Clear(); // Pulisci il contenuto precedente se necessario
            xmlEditorWpfTb.textEditor.AppendText(content);
        }

        private async void BtnGetParams_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                return;
            }

            string fileContent = WriteParameters();
            if (fileContent == string.Empty)
                return;

            string contentBody = await manager.tbServerManager.GetXmlParams(manager.authenticationManager.userData, DateTime.Now, fileContent);
            labelCallTbResult.Text = "Result GetXmlParams:";
            labelTbUrl.Text = manager.tbServerManager.requestTb;

            // Imposta il contenuto nell'editor
            SetXmlContent(contentBody);

            Cursor = Cursors.Default;
        }
        private void buttonGetTb_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                return;
            }

            // Recupera il contenuto dall'editor
            string fileContent = GetXmlContent();
            if (fileContent == string.Empty)
                return;

            string contentBody = manager.tbServerManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
            labelCallTbResult.Text = "Result GetXmlData:";

            // Aggiorna il contenuto dell'editor con il risultato
            SetXmlContent(contentBody);

            Cursor = Cursors.Default;
            labelTbUrl.Text = manager.tbServerManager.requestTb;
        }

        private void LabelbuttonGetParam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = Path.Combine(System.Windows.Forms.Application.StartupPath, "CustomersSet.xml");

            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);

            if (!loaded)
            {
                labelTbUrl.Text = manager.authenticationManager.userData.TbUrl.ToString();
                MessageBox.Show(fileContent);
                return;
            }
            XDocument doc = XDocument.Parse(fileContent);
            ShowResult(doc != null ? "GetParam:\n" + doc : "Unable to retrieve SetParam\n" + doc, doc != null);
        }

        private void buttonSetTb_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Verifica se l'utente è autenticato
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                Cursor = Cursors.Default; // Ripristina il cursore
                return;
            }

            // Verifica se è stato selezionato un file
            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                Cursor = Cursors.Default; // Ripristina il cursore
                return;
            }

            // Ottieni il contenuto dall'editor
            string fileContent = GetXmlContent();
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                MessageBox.Show("The XML content is empty. Please provide valid XML data.");
                Cursor = Cursors.Default; // Ripristina il cursore
                return;
            }

            try
            {
                // Invia i dati modificati al server
                string contentBody = manager.tbServerManager.SetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);

                // Aggiorna il contenuto dell'editor con il risultato
                SetXmlContent(contentBody);

                // Aggiorna le etichette per mostrare il risultato
                labelCallTbResult.Text = "Result SetXmlData:";
                labelTbUrl.Text = manager.tbServerManager.requestTb;
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default; // Ripristina il cursore
            }
        }

        private void LabelbuttonSetParam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = Path.Combine(System.Windows.Forms.Application.StartupPath, "Customers1.xml");

            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);

            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            XDocument doc = XDocument.Parse(fileContent);
            ShowResult(doc != null ? "SetParam:\n" + doc : "Unable to retrieve SetParam\n" + doc, doc != null);
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            xmlEditorWpfTb.textEditor.Text = string.Empty;
        }


        //////////////////////////////
        ///// TBFSSERVICE MANAGER ////
        //////////////////////////////

        //private Task<List<string>> FillApplications()
        //{
        //    try
        //    {
        //        List<string> applications = manager.tbFsServiceManager.GetApplications(manager.authenticationManager.userData, DateTime.Now);

        //            return applications;

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}


        private async Task FillApplications()
        {
            try
            {
                List<string> applications = await manager.tbFsServiceManager.GetApplications(manager.authenticationManager.userData, DateTime.Now);
                if (applications == null)
                    return;

                cbxApplication.DataSource = null;
                if (!applications.Contains("Application"))
                {
                    applications.Insert(0, "Application");
                }
                cbxApplication.DataSource = applications;
                if (applications.Count > 0)
                {
                    cbxApplication.SelectedIndex = 0;
                }
                else
                {
                    cbxApplication.ForeColor = Color.Red;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task FillModules(string application)
        {
            cbxModule.DataSource = null;
            List<string> modules = await manager.tbFsServiceManager.GetModules(manager.authenticationManager.userData, DateTime.Now, application);
            if (modules == null)
                return;
            if (!modules.Contains("Module"))
            {
                modules.Insert(0, "Module");
            }
            cbxModule.DataSource = modules;
            if (modules.Count > 0)
                cbxModule.SelectedIndex = 0;
        }

        private async Task FillDocuments(string application, string module)
        {
            cbxDocReport.DataSource = null;
            (List<string> folderNames, List<string> folderObjectsNS) = await manager.tbFsServiceManager.GetDocumentsFolders(manager.authenticationManager.userData, DateTime.Now, application, module);

            if (folderNames == null)
                return;
            if (!folderNames.Contains("Document"))
            {
                folderNames.Insert(0, "Document");
            }
            cbxDocReport.DataSource = folderNames; // Remove the DataSource before editing the collection of items
            manager.tbFsServiceManager.DocumentNamespace = folderObjectsNS;
            if (folderNames.Count > 0)
                cbxDocReport.SelectedIndex = 0;
        }

        private async Task FillProfiles(string application, string module, string folderName)
        {
            cbxProfile.DataSource = null;
            List<string> profile = await manager.tbFsServiceManager.GetProfiles(manager.authenticationManager.userData, DateTime.Now, application, module, folderName);
            //List<string> textFile = await manager.tbFsServiceManager.GetTextFile(manager.authenticationManager.userData, DateTime.Now, application, module, folderName);

            if (profile == null)
                return;
            if (!profile.Contains("Profile"))
            {
                profile.Insert(0, "Profile");
            }
            cbxProfile.DataSource = profile; // Remove the DataSource before editing the collection of items

            if (profile.Count > 0)
                cbxProfile.SelectedIndex = 0;

        }
        private string WriteParameters()
        {
            string maxs = string.Empty;
            maxs = string.Format("{0}{1}/{2}/{3}/{4}/{5}.xsd",
                   manager.tbFsServiceManager.DefaultUri,
                   manager.tbFsServiceManager.selApp,
                   manager.tbFsServiceManager.selMod,
                   manager.tbFsServiceManager.selDoc,
                   manager.tbFsServiceManager.DefaultUser,
                   manager.tbFsServiceManager.selProfile);

            //string application = manager.tbFsServiceManager.selApp;
            //string module = manager.tbFsServiceManager.selMod;
            string docName = manager.tbFsServiceManager.selDoc;
            string profile = manager.tbFsServiceManager.selProfile;
            string docNS = manager.tbFsServiceManager.CurrentDocNS;
            string defDocParam = manager.tbFsServiceManager.DefaultDocumentParameters;
            string Doc = "Document.";

            string content = string.Empty;
            if (profile != null)
                content = string.Format(defDocParam, docName, Doc + docNS, profile, maxs).Replace("><", ">\r\n<");
            return content;
        }


        private async Task FillApplicationsRObj()
        {
            try
            {
                List<string> applications = await manager.tbFsServiceManager.GetApplications(manager.authenticationManager.userData, DateTime.Now);
                if (applications == null)
                    return;

                cbxAppRObj.DataSource = null;
                if (!applications.Contains("Application"))
                {
                    applications.Insert(0, "Application");
                }
                cbxAppRObj.DataSource = applications;
                if (applications.Count > 0)
                {
                    cbxAppRObj.SelectedIndex = 0;
                }
                else
                {
                    cbxAppRObj.ForeColor = Color.Red;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private async Task FillModulesRObj(string application)
        {
            cbxModRObj.DataSource = null;
            List<string> modules = await manager.tbFsServiceManager.GetModules(manager.authenticationManager.userData, DateTime.Now, application);
            if (modules == null)
                return;
            if (!modules.Contains("Module"))
            {
                modules.Insert(0, "Module");
            }
            cbxModRObj.DataSource = modules;
            if (modules.Count > 0)
                cbxModRObj.SelectedIndex = 0;
        }


        private void PopulateFileList(string path)
        {
            cbxDocRObj.DataSource = null;

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"The directory '{path}' does not exist.");

            string[] files = Directory.GetFiles(path);
            List<string> fileNames = files.Select(f => Path.GetFileName(f)).ToList();

            cbxDocRObj.DataSource = fileNames;
        }

        //////////////////////////
        ///// WEBMETHODS BTN /////
        //////////////////////////

        /////// DATE BTN ////////
        private void btnCurrOpeningDate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            labelWbUrl.Text = manager.authenticationManager.userData.TbUrl.ToString();
            DateTime now = new DateTime(2022, 12, 31);
            string contentBody = manager.webMethodsManager.CurrentOpeningDate(manager.authenticationManager.userData, now);

            ShowResult(contentBody != null ? "CurrentOpeningDate\n" + contentBody : "Unable to retrieve OpeningDate\n" + contentBody, contentBody != null);
            labelWbUrl.Text = UrlSManager.TbServerUrl;
            // Controlla la richiesta per btnWMethRequest

        }

        private void btnClosingDate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.webMethodsManager.ClosingDateFiscalYear(manager.authenticationManager.userData, DateTime.Now);

            ShowResult(contentBody != null ? "ClosingDate\n" + contentBody : "Unable to retrieve ClosingDate\n" + contentBody, contentBody != null);
        }

        private void btnCreatePx_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            defPriceHandle = manager.webMethodsManager.DefaultSalesPricesCreate(manager.authenticationManager.userData, DateTime.Now);
            ShowResult(defPriceHandle < 1 ? "The creation is not successful : \n" + defPriceHandle.ToString() : "Successful \n"
                + "You have created the handle number : \n" + defPriceHandle.ToString(), defPriceHandle >= 1); if (defPriceHandle < 1) ;
        }

        private void btnGetDefPrice_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            long handle = defPriceHandle;
            string customer = "0001";
            string item = "ZUCH";
            string uom = "KG";
            double quantity = 10.0;
            string contentBody = manager.webMethodsManager.GetDefaultPrice(manager.authenticationManager.userData, DateTime.Now, handle, customer, item, uom, quantity);
            ShowResult(contentBody != null ? "DefaultPricesHandle is : \n" + contentBody : "Error retrieving prices", contentBody != null);
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            long handle = defPriceHandle;
            bool contentBody = manager.webMethodsManager.DefaultSalesPricesDispose(manager.authenticationManager.userData, DateTime.Now, handle);
            string res = "Dispose successful: \n " + contentBody + "\nThe canceled sales price is: " + defPriceHandle.ToString();
            if (handle == 0)
            {
                ShowResult("Impossible to cancel. No SalesPrices created.", false);
            }
            else
                ShowResult(res, contentBody);
        }

        ////////////////////////////////
        /////  DATA SERVICE BTN   /////
        ///////////////////////////////

        //private void buttonDSGetData_Click(object sender, EventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    if (!manager.authenticationManager.IsLogged())
        //    {
        //        MessageBox.Show("User is not logged, please Login!");
        //        return;
        //    }
        //    else if (textBoxNameSpace.Text != null && textBoxNameSpace.Text != "")
        //    {
        //        string selectionType = "default";
        //        if (cbxSelectionType.SelectedItem != null && string.Compare(cbxSelectionType.SelectedItem.ToString(), "radar", true) == 0)
        //            selectionType = "radar";
        //        else if (cbxSelectionType.SelectedItem != null && string.Compare(cbxSelectionType.SelectedItem.ToString(), "MyQry", true) == 0)
        //            selectionType = "MyQry";
        //        bool bOk = false;
        //        string contentBody = "DataServiceGetData: " + selectionType + "\n" + manager.dataServiceManager.GetData(manager.authenticationManager.userData, selectionType, textBoxNameSpace.Text, ref bOk);
        //        ShowResult(contentBody, bOk);
        //        labelDataUrl.Text = manager.dataServiceManager.requestDs;
        //    }

        //}
        private void buttonDSGetData_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            else if (!string.IsNullOrEmpty(textBoxNameSpace.Text))
            {
                string selectionType = "default";

                // Legge il valore dalla ComboBox
                if (cbxSelectionType.SelectedItem != null || !string.IsNullOrWhiteSpace(cbxSelectionType.Text))
                {
                    selectionType = cbxSelectionType.Text; // Usa il testo inserito
                }

                bool bOk = false;
                string contentBody = "DataServiceGetData: " + selectionType + "\n" +
                                     manager.dataServiceManager.GetData(manager.authenticationManager.userData, selectionType, textBoxNameSpace.Text, ref bOk);
                ShowResult(contentBody, bOk);
                labelDataUrl.Text = manager.dataServiceManager.requestDs;
            }
        }

        private bool AreParametersOk()
        {
            if
            (
                //string.IsNullOrEmpty(text_http.Text) ||
                string.IsNullOrEmpty(text_user.Text) ||
                string.IsNullOrEmpty(text_pwd.Text) ||
                string.IsNullOrEmpty(text_subscription.Text) ||
                string.IsNullOrEmpty(text_producer.Text) ||
                string.IsNullOrEmpty(text_app.Text) ||
                string.IsNullOrEmpty(textBoxNameSpace.Text)
            )
            {
                MessageBox.Show("Please enter your authority information to continue (user name, passowrd, subscription key, producer key and app key)");
                text_user.Focus();
            }
            return true;
        }



        //// Dynamic parameter queries 

        private void btnQryDynamicInfto_Click(object sender, EventArgs e)
        {
            string content =
           "The OrderLists is not a Mago document.\r\nIt was created for this example you can find it in the Docs folder in this project\n" +
            "You can use it by adding it to your environment at the following path:\n" +
            "YourEnvironment\\Standard\\Applications\\ERP\\SaleOrders\\ReferenceObjects";
            ShowResult(content, false, true, true);
        }
        private void btnGetDataQry_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            bool bOk = false;
            string ExtNo = "111";
            DateTime ordDate = DateTime.Today;
            string yesterday = "05/06/2022";
            string filter_valQ1 = ExtNo;
            string filter_valQ2 = "";
            string Customer = "0001";
            string Payment = "%RB%";

            // Args Q1
            JObject joQ1 = new JObject();
            try
            {
                joQ1.Add("orderDate", yesterday);
                joQ1.Add("Customer", Customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nella costruzione di joQ1: " + ex.Message);
            }
            string args_valQ1 = joQ1.ToString();

            // Args JSON per Q2
            JObject joQ2 = new JObject();
            try
            {
                joQ2.Add("Customer", Customer);
                joQ2.Add("Payment", Payment);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore nella costruzione di joQ2: " + ex.Message);
            }
            string args_valQ2 = joQ2.ToString();

            // Leggi la selezione della ComboBox
            string selectedQuery = comboBoxQuery.SelectedItem?.ToString() ?? "";

            string result = ""; // Variabile per memorizzare il risultato della query
            switch (selectedQuery)
            {
                case "Radar":
                    // Esegui la query iniziale senza `filterVal` e `argsVal`
                    result = manager.dataServiceManager.GetData(
                        manager.authenticationManager.userData,
                        "radar",
                        "ERP.SaleOrders.Dbl.OrdsLists",
                        ref bOk
                    );
                    labelQuery.Text = $"Query: {selectedQuery}\nData: {ordDate.ToShortDateString()}";
                    break;

                case "Q1":
                    // Esegui la query Q1
                    result = manager.dataServiceManager.GetData(
                        manager.authenticationManager.userData,
                        "Q1",
                        "ERP.SaleOrders.Dbl.OrdsLists",
                        ref bOk,
                        filter_valQ1,  // filterVal
                        args_valQ1     // argsVal (JSON)
                    );
                    labelQuery.Text = $"Query: {selectedQuery}\nExtNo: {ExtNo}\nOrder Date: {yesterday}\nCustomer: {Customer}";
                    break;

                case "Q2":
                    // Esegui la query Q2
                    result = manager.dataServiceManager.GetData(
                        manager.authenticationManager.userData,
                        "Q2",
                        "ERP.SaleOrders.Dbl.OrdsLists",
                        ref bOk,
                        filter_valQ2,  // filterVal
                        args_valQ2     // argsVal (JSON)
                    );
                    labelQuery.Text = $"Query: {selectedQuery}\nCustomer: {Customer}\nPayment: {Payment}";
                    break;

                default:
                    MessageBox.Show("Per favore, seleziona una query dalla lista.");
                    return;
            }
            ShowResult($"Risultato {selectedQuery}:\n{result}", bOk);
            labelDataUrl.Text = manager.dataServiceManager.requestDs;
        }


        private void buttonDSVersion_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dataServiceManager.GetVersion(manager.authenticationManager.userData);
            ShowResult(contentBody != null ? "Get Version Xml:\n" + contentBody : "Unable to retrieve Get Version\n" + contentBody, contentBody != null);
            labelDataUrl.Text = manager.dataServiceManager.requestDs;
        }

        ////////////////////////////////
        ///// REPORTINGSERVICE BTN /////
        ////////////////////////////////
        private void btnGetRsItems_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.rsManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, 0);
            ShowResult(contentBody != null && contentBody != "" ? contentBody : "Unable to retrieve items\n" + contentBody, contentBody != null && contentBody != "");
            labelRsUrl.Text = manager.rsManager.requestRs;
        }

        private void btnGetRsCustomers_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.rsManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, 1);
            ShowResult(contentBody != null && contentBody != "" ? "GetRsCustomer\n" + contentBody : "Unable to retrieve customer\n" + contentBody, contentBody != null && contentBody != "");
            labelRsUrl.Text = manager.rsManager.requestRs;
        }

        private void btnGetReportPdf_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.rsManager.GetReportPdf(manager.authenticationManager.userData, DateTime.Now, 0);
            ShowResult(contentBody != null && contentBody != "" ? contentBody : "Unable to retrieve Pdf\n" + contentBody, contentBody != null && contentBody != "");
            btnExploreReport.Visible = true;
            labelRsUrl.Text = manager.rsManager.requestRs;
        }

        private void btnExploreReport_Click(object sender, EventArgs e)
        {
            // Usa la variabile globale per ottenere il percorso della cartella
            var pdfDirectory = RsManager.PdfDirectory;

            // Controlla che la cartella esista prima di aprirla
            if (Directory.Exists(pdfDirectory))
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = pdfDirectory,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("The PDF directory does not exist yet.");
            }
        }

        //////////////////////
        /////  DMS BTN  //////
        //////////////////////
        private void buttonMicrHome_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dmsManager.GetHome(manager.authenticationManager.userData);
            ShowResult(contentBody != null ? contentBody : "Error retrieving Home", contentBody != null);
            labelDmsUrl.Text = UrlSManager.DmsServiceUrl;
        }

        private void btnDmsSetting_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dmsManager.PostDmsSetting(manager.authenticationManager.userData);
            ShowResult(contentBody != null ? "DmsSetting: \n " + contentBody : "Error retrieving DmsSetting", contentBody != null);
        }


        //// BTN SOURCECODE ///
        ///////////////////////
        private void linkHelpTb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string contentBody = manager.exampleManager.ExampleTb();
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\TbServerManager.cs");
        }

        private void linkCodeSourceWb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WebMethodsManager.cs");
        }

        private void linkHelpDataService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\DataServiceManager.cs");
        }

        private void linkHelpReportingService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\RsManager.cs");
        }

        private void linkHelpDMS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\DmsManager.cs");
        }

        ////////////////////////
        ////DATA MANAGER MMS////
        ////////////////////////

        private void btnGetMMSVersion_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dmMMSManager.GetDmMMSServiceVersion(manager.authenticationManager.userData);
            ShowResult(contentBody != null ? contentBody : "Error retrieving Data Manager MMS", contentBody != null);
            DmMMSUrl.Text = UrlSManager.DmMMSUrl;

        }

        private void btnTableSchema_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            TbResponse responseS = manager.dmMMSManager.Schema(manager.authenticationManager.userData, MA_CustSupp.TableName).Result;
            string schemaContentBody = responseS.PlainResult;
            //TbResponse responseP = manager.dmMMSManager.Prototype(manager.authenticationManager.userData, sampleTableName).Result;
            //string prototypeContentBody = responseP.PlainResult;
            string contentBody = MA_CustSupp.TableName;
            ShowResult(responseS.Success ? "TableSchema " + MA_CustSupp.TableName + " OK" : "Error retrieving TableSchema " + MA_CustSupp.TableName);
            DmMMSUrl.Text = UrlSManager.DmMMSUrl;
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            Query query = new Query
            {
                TableName = MA_CustSupp.TableName,
                SelectedFields = new string[] { "CustSuppType", "CustSupp", "CompanyName" },
                //JoinClause = new string[] { "CustSuppType", "CustSupp", "CompanyName", "Branch" }

            };

            TbResponse SelectResponse = await manager.dmMMSManager.Select(manager.authenticationManager.userData, query);
            JArray dataArray = JArray.Parse((string)SelectResponse.ReturnValue);
            StringBuilder contentBody = new StringBuilder();

            foreach (JObject dataObject in dataArray)
            {
                string custSuppType = dataObject.GetValue("CustSuppType")?.ToString();
                string custSupp = dataObject.GetValue("CustSupp")?.ToString();
                string companyName = dataObject.GetValue("CompanyName")?.ToString();

                contentBody.AppendLine($"CustSuppType:\n{custSuppType}");
                contentBody.AppendLine($"CustSupp:\n{custSupp}");
                contentBody.AppendLine($"CompanyName:\n{companyName}");
                contentBody.AppendLine("------------");
            }
            ShowResult(contentBody.ToString(), true);
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            Query query = new Query();
            query.TableName = MA_CustSupp.TableName; ;
            query.SelectedFields = new string[] { "*" };
            TbResponse CountResponse = manager.dmMMSManager.Count(manager.authenticationManager.userData, query).Result;
            string CountContentBody = (string)CountResponse.ReturnValue;
            string contentBody = CountContentBody;
            labelCount.Text = "Count " + MA_CustSupp.TableName + " = " + contentBody;
        }

        private void btnSelectAllByKey_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            TableData tableData = new TableData();
            tableData.TableName = MA_CustSupp.TableName; ;
            tableData.Keys = new object[] { textBoxCustSuppType.Text, textBoxCustSupp.Text };
            TbResponse selectByKeyResponse = manager.dmMMSManager.SelectAllByKey(manager.authenticationManager.userData, tableData).Result;
            string selectByKeyContentBody = (string)selectByKeyResponse.ReturnValue;

            if (selectByKeyContentBody != null && selectByKeyContentBody.ToLower() != "null")
            {
                JObject dataObject = JObject.Parse(selectByKeyContentBody);
                string contentBody = "";
                foreach (var property in dataObject.Properties())
                {
                    // uncommenting the if only fields without an empty string are displayed
                    if (property.Value.Type != JTokenType.Null && property.Value.ToString() != "")
                        contentBody += $"{property.Name}: {property.Value}\n";
                }
                if (!string.IsNullOrEmpty(contentBody))
                {
                    ShowResult(contentBody);
                }
                else
                {
                    ShowResult("No valid data found.", false);
                }
            }
            else
            {
                ShowResult("Error retrieving SelectAllByKey: Null response.\nCheck that the entered parameters are correct.", false);
            }
        }

        private void btnExists_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            TableData crudData = new TableData();
            crudData.TableName = MA_CustSupp.TableName;
            crudData.Keys = new object[] { textBoxCustSuppType.Text, textBoxCustSupp.Text };
            crudData.Data = new MA_CustSupp();
            Task<bool> existsTask = manager.dmMMSManager.Exists(manager.authenticationManager.userData, crudData);
            bool existsResult = existsTask.Result;
            if (existsTask.Result == false)
            {
                MessageBox.Show(textBoxCustSupp.Text + " not Exist");
                return;
            }
            MessageBox.Show(textBoxCustSupp.Text + " Already Exist");
            return;
        }

        private void SingleAdd()
        {
            MA_CustSupp custSupp = new MA_CustSupp();

            custSupp.CustSuppType = Int32.Parse(textBoxCustSuppType.Text);
            custSupp.CustSupp = textBoxCustSupp.Text;
            custSupp.CompanyName = textBoxCompanyName.Text;
            custSupp.ISOCountryCode = textBoxIsoCountryCode.Text;
            // insert data
            TableData crudData = new TableData();
            crudData.TableName = MA_CustSupp.TableName;
            crudData.Data = custSupp;
            crudData.Keys = new object[] { textBoxCustSuppType.Text, textBoxCustSupp.Text };
            if (manager.dmMMSManager.Exists(manager.authenticationManager.userData, crudData).Result)
            {
                TbResponse updateResponse = manager.dmMMSManager.Update(manager.authenticationManager.userData, crudData).Result;
                if (updateResponse.Success != true)
                    MessageBox.Show($"Table not Updated ({updateResponse.StatusCode})");
                else
                    MessageBox.Show($"Table Updated Successfully ({updateResponse.StatusCode})");
                return;
            }
            else
            {
                TbResponse addResponse = manager.dmMMSManager.Add(manager.authenticationManager.userData, crudData).Result;
                if (addResponse.Success != true)
                    MessageBox.Show($"Table not Added ({addResponse.StatusCode})");
                else
                    MessageBox.Show($"Table Added Successfully ({addResponse.StatusCode})");
                return;
            }
        }

        private void MultipleAdd()
        {
            for (int i = 0; i < 400; i++)
            {
                MA_CustSupp custSupp = new MA_CustSupp();
                custSupp.CustSuppType = Int32.Parse(textBoxCustSuppType.Text);
                custSupp.CustSupp = $"{textBoxCustSupp.Text}-{i}"; // Aggiunta del numero progressivo al testo del textBoxCustSupp.Text
                custSupp.CompanyName = $"{textBoxCompanyName.Text}-{i}"; // Aggiunta del numero progressivo al testo del textBoxCompanyName.Text
                custSupp.ISOCountryCode = textBoxIsoCountryCode.Text;
                // insert data
                TableData crudData = new TableData();
                crudData.TableName = MA_CustSupp.TableName;
                crudData.Data = custSupp;
                crudData.Keys = new object[] { textBoxCustSuppType.Text, textBoxCustSupp.Text };
                if (manager.dmMMSManager.Exists(manager.authenticationManager.userData, crudData).Result)
                {
                    TbResponse updateResponse = manager.dmMMSManager.Update(manager.authenticationManager.userData, crudData).Result;
                    //if (updateResponse.Success != true)
                    //    MessageBox.Show($"Table not Updated ({updateResponse.StatusCode})");
                    //else
                    //    MessageBox.Show($"Table Updated Successfully ({updateResponse.StatusCode})");
                }
                else
                {
                    TbResponse addResponse = manager.dmMMSManager.Add(manager.authenticationManager.userData, crudData).Result;
                    //if (addResponse.Success != true)
                    //    MessageBox.Show($"Table not Added ({addResponse.StatusCode})");
                    //else
                    //    MessageBox.Show($"Table Added Successfully ({addResponse.StatusCode})");
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            SingleAdd();
            //MultipleAdd();
        }
        //UpdateSlave
        //private async void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PVDModelHeader pvdDocHeader = new PVDModelHeader()
        //        {
        //            Code = "0001",
        //            Line = 1,
        //            Item = "ZUCH",
        //            Lot = "ZuchCl1",
        //            Plate = "AS456YU", 
        //        };

        //        TableData tableData = new TableData()
        //        {
        //            TableName = PVDModelHeader.TableName,
        //            Data = pvdDocHeader,
        //            Keys = new object[] { pvdDocHeader.Code, pvdDocHeader.Line }
        //        };

        //        TbResponse updateResponse = await manager.dmMMSManager.Update(manager.authenticationManager.userData, tableData);

        //        bool success = updateResponse.Success;

        //        if (success)
        //        {
        //            MessageBox.Show("Aggiornamento riuscito");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Aggiornamento fallito");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show($"Si è verificato un errore: {ex.Message}");
        //    }
        //}

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            TableData crudData = new TableData();
            crudData.TableName = MA_CustSupp.TableName;
            crudData.Data = null;
            crudData.Keys = new object[] { textBoxCustSuppType.Text, textBoxCustSupp.Text };
            if (manager.dmMMSManager.Exists(manager.authenticationManager.userData, crudData).Result)
            {
                bool? bDeleted = manager.dmMMSManager?.Delete(manager.authenticationManager.userData, crudData).Result;
                if (bDeleted == true)
                {
                    MessageBox.Show(textBoxCustSupp.Text + " Table cleared successfully");
                    return;
                }
                else
                {
                    MessageBox.Show(textBoxCustSupp.Text + " Unable to delete");
                    return;
                }
            }
            else
            {
                MessageBox.Show(textBoxCustSupp.Text + " Table not found, unable to delete ");
                return;
            }
        }

        private void LoadEnumsTable()
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            EnumsResult enumsResult = manager.dmMMSManager.GetEnumsTable(manager.authenticationManager.userData);

            if (enumsResult != null)
            {
                List<string> listStored = enumsResult.ListStored;
                List<string> listName = enumsResult.ListName;
                // Carica gli elementi nella ComboBox
                foreach (string item in listName)
                {
                    cbxArchiveType.Items.Add(item);

                    int index = listName.IndexOf(item);
                    if (index == 0 && listStored.Count > 0)
                    {
                        string num = listStored[index];
                        textBoxArchiveType.Text = num;
                    }
                }
                if (cbxArchiveType.Items.Count > 0)
                {
                    cbxArchiveType.SelectedIndex = 0;
                }
            }
            else
            {
                textBoxArchiveType.Text = "ArchiveType not found";
            }
        }

        private void cbxArchiveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnumsResult enumsResult = manager.dmMMSManager.GetEnumsTable(manager.authenticationManager.userData);
            if (enumsResult != null)
            {
                List<string> listStored = enumsResult.ListStored;
                if (manager.tbFsServiceManager.selMod != "Module")
                {
                    string application = manager.tbFsServiceManager.selApp;
                    string module = manager.tbFsServiceManager.selMod;

                }
                int selectedIndex = cbxArchiveType.SelectedIndex;

                if (selectedIndex >= 0 && selectedIndex < listStored.Count)
                {
                    string num = listStored[selectedIndex];
                    textBoxArchiveType.Text = num;
                }
            }
        }

        private void btnGetNextId_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            //tipo archivio Inventory Entry = 3801093
            TbResponse getIdResponse = manager.dmMMSManager.GetNextID(manager.authenticationManager.userData, textBoxArchiveType.Text, false).Result;
            if (getIdResponse.Success == true)
            {
                string contentBody = (string)getIdResponse.ReturnValue;
                labelNextIdN.BackColor = Color.Green;
                labelNextIdN.Text = cbxArchiveType.Text + " Next id n° : " + contentBody;
            }
            else
            {
                labelNextIdN.BackColor = Color.Red;
                labelNextIdN.Text = cbxArchiveType.Text + " ArchiveType not present ";
            }
        }

        private void btnBObjectData_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            BusinessObjectData boData = new BusinessObjectData();
            boData.BONamespace = "ERP.CustomersSuppliers.Documents.Customers";
            // search by primary key
            boData.FindFields.Add("CustSuppType", textBoxBoCustSType.Text);
            if (!string.IsNullOrEmpty(textBoxBoCustSupp.Text))
            {
                boData.FindFields.Add("CustSupp", textBoxBoCustSupp.Text);
            }
            // search by company name or by other master table fields. % field enables like operator
            //boData.FindFields.Add("CompanyName", textBoxBoCompanyName.Text);
            boData.OrderByFields = new string[] { "CompanyName" };
            boData.RequestedTables = new List<RequestedTable>();
            boData.RequestedTables.Add(new RequestedTable(textBoxBoTabName.Text, new string[] { "CustSuppType", "CustSupp", "CompanyName" }));
            boData.RequestedTables.Add(new RequestedTable(textBoxCustSCOptions.Text, new string[] { "CustSuppType", "Customer", "Category", "CommissionCtg", "Area", "Salesperson", "AreaManager" }));
            boData.RequestedTables.Add(new RequestedTable(textBoxCustSuppNotes.Text, new string[] { "CustSuppType", "CustSupp", "Line", "Notes", "TBCreated" }));

            m_GetBoResponse = manager.dmMMSManager.GetBOByFindKeys(manager.authenticationManager.userData, boData).Result;
            string BoResponseContentBody = (string)m_GetBoResponse.ReturnValue;

            if (BoResponseContentBody != null && BoResponseContentBody.ToLower() != "null")
            {
                JObject dataObject = JObject.Parse(BoResponseContentBody);
                string contentBody = "";

                foreach (var property in dataObject)
                {
                    if (property.Key == textBoxBoTabName.Text)
                    {
                        var maCustSuppArray = (JArray)property.Value;
                        foreach (var maCustSuppItem in maCustSuppArray)
                        {
                            // Ma_CustSupp
                            var maCustSuppData = maCustSuppItem["data"].ToString();
                            maCustSuppData = maCustSuppData.Replace("\r\n", "");
                            contentBody += $"{property.Key} data: \n{maCustSuppData}\n";

                            // Ma_CustSuppCustomerOptions
                            var maCustSuppCustomerOptions = maCustSuppItem[textBoxCustSCOptions.Text];
                            contentBody += $"{textBoxCustSCOptions.Text}: {maCustSuppCustomerOptions}\n";

                            // Ma_CustSuppNotes
                            var maCustSuppNotes = maCustSuppItem[textBoxCustSuppNotes.Text];
                            contentBody += $"{textBoxCustSuppNotes.Text}: {maCustSuppNotes}\n";
                        }
                    }
                }
                ShowResult(contentBody);
            }
            else
            {
                ShowResult("Error retrieving GetBOByFindKeys: Null response.\nCheck that the entered parameters are correct.", false);
            }
        }

      

        private void cbxServicesWeb_DropDown(object sender, EventArgs e)
        {
            PopulateServicesComboBox();
        }

        private void PopulateServicesComboBox()
        {
            ServiceManager serviceManager = new ServiceManager();
            var servicesStatus = serviceManager.GetServicesStatus();

            cbxServicesWeb.Items.Clear(); // Pulisci gli elementi esistenti

            foreach (var (serviceName, status) in servicesStatus)
            {
                string displayText = $"{serviceName} - {status}";

                // Imposta il colore del testo in base allo stato del servizio per ogni elemento
                Color textColor = (status == "✅") ? Color.Green : Color.Red;
                cbxServicesWeb.Items.Add(new ComboBoxItem(displayText, textColor));
            }
            cbxServicesWeb.DrawMode = DrawMode.OwnerDrawFixed;
            cbxServicesWeb.DrawItem += cbxServicesWeb_DrawItem;
            cbxServicesWeb.Visible = servicesStatus.Count > 0;
        }

        private void cbxServicesWeb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                ComboBoxItem item = (ComboBoxItem)cbxServicesWeb.Items[e.Index];
                e.DrawBackground();

                using (SolidBrush brush = new SolidBrush(item.TextColor))
                {
                    e.Graphics.DrawString(item.Text, e.Font, brush, e.Bounds);
                }

                e.DrawFocusRectangle();
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public Color TextColor { get; set; }

            public ComboBoxItem(string text, Color textColor)
            {
                Text = text;
                TextColor = textColor;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void WebMethodList_Click(object sender, EventArgs e)
        {
            string searchTerm = SearchMethod.Text.Trim();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "Functions.json";
            string fullPath = Path.Combine(baseDirectory, fileName);
            StringBuilder resultBuilder = new StringBuilder();
            try
            {
                string fileContent = File.ReadAllText(fullPath);
                // Utilizza una regex per trovare oggetti JSON
                var matches = Regex.Matches(fileContent, @"\{.*?\}(?=\s*\{|\s*$)", RegexOptions.Singleline);

                foreach (Match match in matches)
                {
                    try
                    {
                        Function function = JsonConvert.DeserializeObject<Function>(match.Value);
                        // Se searchTextBox è vuoto o il termine di ricerca è presente in Ns
                        if (string.IsNullOrEmpty(searchTerm) || function.Ns.Contains(searchTerm))
                        {
                            resultBuilder.AppendLine($"Ns: {function.Ns}\n Type: {function.Type}");
                            this.WebMetodLbl.Visible = true;
                            this.SearchMethod.Visible = true;
                            this.lblCaseSensitive.Visible = true;
                        }
                    }
                    catch (JsonReaderException ex)
                    {
                        resultBuilder.AppendLine("Errore durante la deserializzazione di un oggetto JSON: " + ex.Message);
                    }
                }

                ShowResult(resultBuilder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore generale: " + ex.Message);
            }

        }


        public class Function
        {
            public string Ns { get; set; }
            public string Type { get; set; }
            public List<Argument> Args { get; set; }
        }

        public class Argument
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }


        private void btnTbfs_Click(object sender, EventArgs e)
        {
            string content =
           $"The service that makes this call is the TBFSSERVICE :\n" +
           $"\n- GettAllApplications: {UrlSManager.TbFsServiceUrl}/tbfs-service/GettAllApplications.\n" +
           $"\n- GetAllModulesByApplication: {UrlSManager.TbFsServiceUrl}/tbfs-service/GetAllModulesByApplication.\n" +
           $"\n- GetSubFolders: {UrlSManager.TbFsServiceUrl}/tbfs-service/GetSubFolders.\n" +
           $"\n- getprofilefolders: {UrlSManager.TbFsServiceUrl}/tbfs-service/getprofilefolders";
            ShowResult(content, false, true, true);
        }

        private void btnExpandDynamicQueries_Click(object sender, EventArgs e)
        {
            if (btnExpandDynamicQueries.Text == "Try") // Mostra il panel
            {
                btnExpandDynamicQueries.Text = "Close";
                DynamicQueriesPanel.Dock = DockStyle.None;
                DynamicQueriesPanel.Visible = true; // Rende il panel visibile
            }
            else // Nasconde il panel
            {
                btnExpandDynamicQueries.Text = "Try";
                DynamicQueriesPanel.Dock = DockStyle.None;
                DynamicQueriesPanel.Visible = false; // Nasconde il panel
            }
        }

        private void btnBusinessObj_Click(object sender, EventArgs e)
        {


            // Imposta i parametri per RunDocumentAsync
            string nameSpace = "Courses.Courses.DynamicDocuments.Courses"; // Adatta al tuo contesto
            bool unattended = true;
            string callerId = "caller123"; // Un identificatore qualsiasi per il chiamante



            // Richiama il metodo RunDocumentAsync e attendi il risultato
            var result = manager.docBusinessObjManager.RunDocumentAsync<object>(manager.authenticationManager.userData, nameSpace, unattended, callerId);

            // Gestisci il risultato (opzionale)
            if (result != null)
            {
                MessageBox.Show("RunDocumentAsync completato con successo.");
            }
            else
            {
                MessageBox.Show("RunDocumentAsync ha restituito null.");
            }
        }

        private void cbxSelectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSelectionType.SelectedItem != null)
            {
                // Controlla se l'utente ha selezionato "AddQueryHere"
                if (cbxSelectionType.SelectedItem.ToString() == "AddQueryHere")
                {
                    // Permetti l'editing del testo
                    cbxSelectionType.Text = "";
                }
                else
                {
                    // Impedisci l'editing e forza il testo a essere l'elemento selezionato
                    cbxSelectionType.Text = cbxSelectionType.SelectedItem.ToString();
                }
            }
        }


        private async void cbxAppRObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selApp = (cbxAppRObj.SelectedItem == null) ? string.Empty : cbxAppRObj.SelectedItem.ToString();


            if (manager.tbFsServiceManager.selApp != "Applications")
                await FillModulesRObj(manager.tbFsServiceManager.selApp);

        }

        private async void cbxModRObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selMod = (cbxModRObj.SelectedItem == null) ? string.Empty : cbxModRObj.SelectedItem.ToString();

            if (manager.tbFsServiceManager.selMod != "Module" && manager.tbFsServiceManager.selMod != string.Empty)
            {
                string application = manager.tbFsServiceManager.selApp;
                string module = manager.tbFsServiceManager.selMod;

                string basePath = await manager.tbFsServiceManager.GetReferenceObjBasePath(manager.authenticationManager.userData, application, module);
                manager.tbFsServiceManager.CurrentPath = basePath;
                PopulateFileList(basePath);
            }
        }

        private void cbxDocRObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDocRObj.SelectedItem == null)
            {
                textBoxNameSpace.Clear();
                cbxSelectionType.DataSource = null; // Reset combobox
                loadedXmlDocument = null; // Reset XML
                return;
            }

            string selectedFile = cbxDocRObj.SelectedItem.ToString();
            manager.tbFsServiceManager.selDocObj = selectedFile;
            string fullPath = Path.Combine(manager.tbFsServiceManager.CurrentPath, selectedFile);

            if (File.Exists(fullPath))
            {
                try
                {
                    // Carica l'XML e salva l'oggetto
                    loadedXmlDocument = XDocument.Load(fullPath);

                    // 1. Extract namespace
                    XElement functionElement = loadedXmlDocument.Descendants("Function").FirstOrDefault();
                    if (functionElement != null && functionElement.Attribute("namespace") != null)
                    {
                        string namespaceValue = functionElement.Attribute("namespace").Value;
                        textBoxNameSpace.Text = namespaceValue;
                    }
                    else
                    {
                        textBoxNameSpace.Text = "Namespace not found.";
                    }

                    // 2. Populated combobox "name" tag <Selection>
                    IEnumerable<string> selectionNames = loadedXmlDocument
                        .Descendants("SelectionTypes")
                        .Descendants("Selection")
                        .Attributes("name")
                        .Select(attr => attr.Value);

                    if (selectionNames.Any())
                    {
                        cbxSelectionType.DataSource = selectionNames.ToList(); // Populated  combobox
                    }
                    else
                    {
                        cbxSelectionType.DataSource = null; // Reset
                        MessageBox.Show("No Selection Types found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading XML: {ex.Message}");
                    textBoxNameSpace.Clear();
                    cbxSelectionType.DataSource = null;
                    loadedXmlDocument = null; // Reset error
                }
            }
            else
            {
                textBoxNameSpace.Clear();
                cbxSelectionType.DataSource = null;
                loadedXmlDocument = null; // Reset not exist file 
                MessageBox.Show($"The file '{selectedFile}' does not exist.");
            }
        }

        private void BtnViewModifyXml_Click(object sender, EventArgs e)
        {
            if (loadedXmlDocument == null)
            {
                MessageBox.Show("Nessun documento XML è stato caricato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string content = loadedXmlDocument.ToString();
            FormRefObj formRefObj = new FormRefObj(content, manager);
            formRefObj.ShowDialog();
        }


        /// <summary>
        /// BOTTONE MASCHERA PRINCIPALE
        
        public enum ObjectType { Document, Report, File, Image, Text, Folder, CreateFolder, CurrentModuleRoot, Setting, Profile, ProfileFile, ReportDescription, ReferenceObject, FormatFont, Pdf, Rtf }



        private async void BtnUploadRefObj_Click(object sender, EventArgs e)
        {

            try
            {
                int statusCode = await UploadObject();

                MessageBox.Show($"Upload esegito: {statusCode}");
                BtnUploadRefObj.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                // Gestione degli errori
                MessageBox.Show($"Errore durante l'upload: {ex.Message}");
                BtnUploadRefObj.ForeColor = Color.Red;
            }
        }

        private async Task<int> UploadObject()
        {
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




