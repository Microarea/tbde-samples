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
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TbApiTester.LogCredential;
using System.Windows.Controls.Primitives;
using System.Data;




namespace TbApiTester
{
    public partial class TbApiTester : Form
    {
        //UrlSManager isCloud = new UrlSManager();
        TbApiTesterManager manager = new TbApiTesterManager();
        UiManagerApi uiManager = new UiManagerApi();
        private LogCredential logCredential;
        private CbxUi cbxUi;
        public bool IsCloudButtonClicked { get; set; }
        private bool isLoggedIn = false;
        private readonly LabelManager labelManager;
        public string base64Data;//dms
        public string fileName;//dms
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
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        private bool isFullScreen = false;
        private string tableName;
        TbResponse m_GetBoResponse;
        public XDocument loadedXmlDocument;
        public string CurrentPath { get; set; }
        private Color previousColor;
        public string interfaceToken { get; set; }
        public string info { get; set; }
        private System.Windows.Forms.Timer countdownTimer;
        private int countdownSeconds = 15;
        private bool thread;

        public TbApiTester(bool isCloudButtonClicked)
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            btnSaveCredential.Visible = false;
            logCredential = new LogCredential();
            string currentEnvironment = GlobalSettings.CurrentButtonState.ToString();

            InitializeCredential(currentEnvironment);
            string folderPath = Path.Combine(basePath, "Docs");
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
                    text_http.Text = "";//"http://localhost:5000/account-manager/login"
                    Http_label.Text = "MagoDevEnv authentication authority URL";
                    uiManager.ReplaceColor(Color.FromArgb(232, 159, 0), Color.FromArgb(173, 92, 174));
                    pictureBoxLogo.Image = Properties.Resources.DevEnvBtn;
                    labelInfoAuthenticate.Text += "Dev";
                    break;

                case GlobalSettings.ButtonState.Web:
                    text_http.Text = "https://gwam.mago.cloud";
                    Http_label.Text = "MagoWeb authentication authority URL";
                    uiManager.ReplaceColor(Color.FromArgb(232, 159, 0), Color.FromArgb(176, 205, 66));
                    this.cbxServicesWeb.Visible = true;
                    pictureBoxLogo.Image = Properties.Resources.MagoWeb;
                    labelInfoAuthenticate.Text += "Web";
                    PopulateServicesComboBox();//____Service List MagoWeb
                    break;

                case GlobalSettings.ButtonState.Cloud:
                    text_http.Text = "https://gwam.mago.cloud";
                    Http_label.Text = "MagoCloud authentication authority URL";
                    pictureBoxLogo.Image = Properties.Resources.MagoCloud;
                    labelInfoAuthenticate.Text += "Cloud";
                    break;
            }


            IsCloudButtonClicked = isCloudButtonClicked;
            btnClearText.Visible = false;
            manager.tbServerManager.folderPath = folderPath;
            cbxSelectionType.Items.Add("AddQueryHere");
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.tabNavigation.TabPages.Remove(this.tabMSH);
            this.cbxSelectionType.SelectedIndex = 0;
            cbxSelectionType.DropDownStyle = ComboBoxStyle.DropDown;
            this.comboBoxQuery.SelectedIndex = 0;
            this.SearchMethod.Visible = false;
            this.lblCaseSensitive.Visible = false;
            this.IsCloudButtonClicked = this.IsCloudButtonClicked;
            btnExploreReport.Hide();
            DynamicQueriesPanel.Hide();
            btnAccount.Hide();
            panelDataManagerOtherCall.Hide();
        }
        public void InitializeCredential(string currentEnvironment)
        {
            var logCredential = new LogCredential();
            var credentials = logCredential.LoadLoginDetails(currentEnvironment);

            if (credentials != null)
            {
                text_user.Text = credentials.Username;
                text_pwd.Text = credentials.Password;
                text_subscription.Text = credentials.Subscription;
                text_producer.Text = credentials.Producer;
                text_app.Text = credentials.App;
            }
            else
            {
                MessageBox.Show($"Welcome in Mago{currentEnvironment}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSaveCredential_Click(object sender, EventArgs e)
        {
            string username = text_user.Text;
            string password = text_pwd.Text;
            string subscription = text_subscription.Text;
            string producer = text_producer.Text;
            string app = text_app.Text;

            string currentEnvironment = GlobalSettings.CurrentButtonState.ToString();

            try
            {
                var logCredential = new LogCredential();
                logCredential.SaveCredentialsFromForm(currentEnvironment, username, password, subscription, producer, app);
                MessageBox.Show("Saved credentials!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void UpdatePictureBoxImage(System.Drawing.Image newImage)
        {
            pictureBoxLogo.Image = newImage;
        }

        private void MagoCloudApi_Load(object sender, EventArgs e)
        {
            // Text Tooltip
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.SetToolTip(BtnOpenFolder, "Open folder");
            myToolTip.SetToolTip(btnSaveXmlTbServer, "Save xmlResult");
            myToolTip.SetToolTip(BtnQuestionCall, "Questions about calls?");
            myToolTip.SetToolTip(BtnFillContent, "Resize TabControl");
            myToolTip.SetToolTip(btnClearText, "Clear Result Window");
            myToolTip.SetToolTip(btnAccount, "Account Info");
            myToolTip.SetToolTip(button_exit, "MagoCloud / MagoWeb / Development Environment");
            myToolTip.SetToolTip(btnTbfs, "TBFSSERVICE");
            myToolTip.SetToolTip(btnExploreReport, "Open Report Pdf folder ");
            myToolTip.SetToolTip(btnSaveCredential, "Save your credentials");

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
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                isFullScreen = false;
            }
            else
            {
                if (BtnFillContent.Text == "⬅")//close LoginPanel
                {
                    tabNavigation.Dock = DockStyle.Fill;
                    LoginPanel.Dock = DockStyle.Top | DockStyle.Bottom;
                }
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                //  Rounded corner
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
            if (BtnFillContent.Text == "❮") // Close LoginPanel
            {
                BtnFillContent.Text = "❯";
                tabNavigation.Dock = DockStyle.Fill;
                LoginPanel.Dock = DockStyle.None;
                panelDataManagerOtherCall.Visible = true;
                previousColor = BtnFillContent.BackColor;
                BtnFillContent.BackColor = Color.FromArgb(22, 118, 186);
            }
            else // Open LoginPanel
            {
                BtnFillContent.Text = "❮";
                LoginPanel.Dock = DockStyle.Top | DockStyle.Bottom;
                panelDataManagerOtherCall.Visible = false;
                BtnFillContent.BackColor = previousColor;
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

                    _ = FillApplications();
                    _ = FillApplicationsRObj();
                    btnSaveCredential.Visible = true;
                    btnAccount.Visible = true;

                    //account-manager/GetModules
                    //string moduleMessage = manager.authenticationManager.GetModules(text_http.Text, manager.authenticationManager.userData, DateTime.Now);
                    Query query = new Query();
                    query.TableName = MA_CustSupp.TableName; ;
                    query.SelectedFields = new string[] { "*" };
                    TbResponse CountResponse = manager.dmMMSManager.Count(manager.authenticationManager.userData, query).Result;

                    if (CountResponse == null)
                    {
                        DmMMSUrl.Text = "❌ Error: No response";
                        return;
                    }

                    string moduleMessage = CountResponse.PlainResult?.ToString() ?? "No value received";

                    if (!CountResponse.Success)
                    {
                        DmMMSUrl.Text = moduleMessage;  // View error message
                        DmMMSUrl.ForeColor = Color.Black;
                        DisableButtonsInControl(this.DataManager);
                        return;
                    }
                    button_Login.ForeColor = Color.White;
                    button_Login.BackColor = Color.Green;
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
            {

                manager.authenticationManager.ValidToken(text_http.Text);
                string subKey = text_subscription.Text;
                string conn = "Data Source= localhost;Initial Catalog= 'DT-EB28E9';User Id='sa';Password='Microarea.';Connect Timeout=30;Pooling=true;Encrypt=False;";
                string currentUser = text_user.Text;
                string accName;

                //TB_Locks locks = new TB_Locks();
                //accName = locks.AccountName;

                //TB_LocksConfiguration confLock = new TB_LocksConfiguration(Microarea.Tbf.Model.Database.DbType.SQLSERVER, subKey);
                //Microarea.Tbf.Model.DataManager.Providers.SubscriptionProvider subProv = new Microarea.Tbf.Model.DataManager.Providers.SubscriptionProvider(subKey, conn, DbType.SQLSERVER);
                //Microarea.Tbf.Model.Interfaces.Database.DbDataContextProduct product = new Microarea.Tbf.Model.Interfaces.Database.DbDataContextProduct();
                //TbLockManager lockMg = new TbLockManager(subProv, product);

                //string procName = text_app.Text;
                //string iKey = "I-663D32";

                //string token = manager.authenticationManager.userData.LoginKey;
                //string context = "000000002E846AA0";
                //RecordLockInfo pippo = new RecordLockInfo(procName, iKey, accName, token, context, 48, 48);

                //ILogger<DiagnosticProvider> logger;
                //var factory = LoggerFactory.Create(builder =>
                //{
                //    builder.AddConsole(); // oppure .AddDebug(), .AddFile() ecc.
                //});
                //logger = factory.CreateLogger<DiagnosticProvider>();
                //DiagnosticProvider provider = new DiagnosticProvider(logger);
                //_ = lockMg.RecordLockAsync(pippo, provider, "MA_ActivityCodes", "ActivityCodes:466400");
            }
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
            List<SubscriptionInfo> subscriptionInfos = new List<SubscriptionInfo>();

            string responseContent = manager.authenticationManager._responseBody.ToString();
            JObject jsonObject = JObject.Parse(responseContent);

            string formattedJson = jsonObject.ToString(Newtonsoft.Json.Formatting.Indented);
            ShowResult(formattedJson);
        }


        private void DisableButtonsInControl(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                if (ctrl is System.Windows.Forms.Button btn)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
                else if (ctrl.HasChildren)
                {
                    DisableButtonsInControl(ctrl);
                }
            }
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

        private string GetXmlContent()
        {
            return xmlEditorTbResult.TextContent;
        }

        private void SetXmlContent(string content)
        {
            if (content != null && content != string.Empty)
            {
                btnClearText.Visible = true;
                xmlEditorTbResult.Update();
                xmlEditorTbResult.TextContent = content;
            }
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

            SetXmlContent(contentBody);
            Cursor = Cursors.Default;
            labelTbUrl.Text = manager.tbServerManager.requestTb;
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

            string fileContent = GetXmlContent();
            if (fileContent == string.Empty)
                return;

            string contentBody = manager.tbServerManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
            labelCallTbResult.Text = "Result GetXmlData:";

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

            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                Cursor = Cursors.Default;
                return;
            }

            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                Cursor = Cursors.Default;
                return;
            }

            // Ottieni il contenuto dall'editor
            string fileContent = GetXmlContent();
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                MessageBox.Show("The XML content is empty. Please provide valid XML data.");
                Cursor = Cursors.Default;
                return;
            }

            try
            {
                string contentBody = manager.tbServerManager.SetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
                SetXmlContent(contentBody);

                labelCallTbResult.Text = "Result SetXmlData:";
                labelTbUrl.Text = manager.tbServerManager.requestTb;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
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
            xmlEditorTbResult.TextContent = string.Empty;
            if (xmlEditorTbResult.TextContent == string.Empty)
                btnClearText.Visible = false;
        }


        //////////////////////////////
        ///// TBFSSERVICE MANAGER ////
        //////////////////////////////
        private async Task FillComboBox<T>(ComboBox comboBox, Task<List<T>> dataTask, string defaultItem = null)
        {
            try
            {
                // Ottieni i dati
                List<T> items = await dataTask;
                if (items == null)
                    return;


                comboBox.DataSource = null;

                if (!string.IsNullOrEmpty(defaultItem) && !items.Contains((T)Convert.ChangeType(defaultItem, typeof(T))))
                {
                    items.Insert(0, (T)Convert.ChangeType(defaultItem, typeof(T)));
                }

                comboBox.DataSource = items;

                if (items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                    comboBox.ForeColor = Color.White;
                }
                else
                {
                    comboBox.ForeColor = Color.Red;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        private async Task FillApplications()
        {
            try
            {
                await FillComboBox(cbxApplication, manager.tbFsServiceManager.GetApplications(manager.authenticationManager.userData, DateTime.Now), "Application");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async Task FillModules(string application)
        {
            var modulesWithPaths = await manager.tbFsServiceManager.GetModules(manager.authenticationManager.userData, DateTime.Now, application);
            List<string> moduleNames = modulesWithPaths?.Select(m => m.ModuleName).ToList() ?? new List<string>();

            await FillComboBox(cbxModule, Task.FromResult(moduleNames), "Module");

        }

        private async Task FillDocuments(string application, string module)
        {
            var (folderNames, folderObjectsNS) = await manager.tbFsServiceManager.GetDocumentsFolders(manager.authenticationManager.userData, DateTime.Now, application, module);
            await FillComboBox(cbxDocReport, Task.FromResult(folderNames), "Document");
            manager.tbFsServiceManager.DocumentNamespace = folderObjectsNS;
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

            var modulesWithPaths = await manager.tbFsServiceManager.GetModules(manager.authenticationManager.userData, DateTime.Now, application);
            if (modulesWithPaths == null || modulesWithPaths.Count == 0)
                return;

            List<string> moduleNames = modulesWithPaths.Select(m => m.ModuleName).ToList();

            if (!moduleNames.Contains("Module"))
            {
                moduleNames.Insert(0, "Module");
            }

            cbxModRObj.DataSource = moduleNames;

            var modulePaths = modulesWithPaths.ToDictionary(m => m.ModuleName, m => m.Path);

            if (moduleNames.Count > 0)
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



        private void BtnInfoLoginCntx_Click(object sender, EventArgs e)
        {
            string content =
          $@"Thread Lifecycle

            Creating context objects alone is not sufficient to keep the thread alive.
            To explicitly manage the thread's lifecycle, the following endpoints can be used:

            - Keep the thread alive:  
              POST http://{UrlSManager.TbServerUrl}/tbserver/api/tb/document/useLoginContext/

            - Release the thread:  
              POST http://{UrlSManager.TbServerUrl}/tbserver/api/tb/document/releaseLoginContext/";
            ShowResult(content, false, true, true);
        }
        /////// DATE BTN ////////


        private void btnCurrOpeningDate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            DateTime now = new DateTime(2022, 12, 31);
            string contentBody = manager.webMethodsManager.CurrentOpeningDate(manager.authenticationManager.userData, now);
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            ShowResult(contentBody != null ? "CurrentOpeningDate\n" + contentBody : "Unable to retrieve OpeningDate\n" + contentBody, contentBody != null);

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
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            ShowResult(contentBody != null ? "ClosingDate\n" + contentBody : "Unable to retrieve ClosingDate\n" + contentBody, contentBody != null);
        }

        private async void btnCreatePx_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            defPriceHandle = manager.webMethodsManager.DefaultSalesPricesCreate(manager.authenticationManager.userData, DateTime.Now);
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            ShowResult(defPriceHandle < 1 ? "The creation is not successful : \n" + defPriceHandle.ToString() : "Successful \n"
                + "You have created the handle number : \n" + defPriceHandle.ToString(), defPriceHandle >= 1); if (defPriceHandle < 1) ;
            if (thread != true) StartCountdown();
            else return;
        }

        private void StartCountdown()
        {
            countdownSeconds = 15;
            labelThred.Text = $"Thread valid for:\n{countdownSeconds} seconds";

            if (countdownTimer == null)
            {
                countdownTimer = new System.Windows.Forms.Timer();
                countdownTimer.Interval = 1000; // 1 secondo
                countdownTimer.Tick += CountdownTimer_Tick;
            }

            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;

            if (countdownSeconds > 0)
            {
                ThreadStatusPanel.Visible = true;
                ThreadStatusPanel.BackColor = Color.LimeGreen;
                labelThred.Text = $"Thread valid for:\n{countdownSeconds} seconds";
            }
            else
            {
                countdownTimer.Stop();
                ThreadStatusPanel.Visible = true;
                ThreadStatusPanel.BackColor = Color.Red;
                labelThred.Text = "Thread is no longer valid.";
                defPriceHandle = -1;
            }
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
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            ShowResult(contentBody != null ? "DefaultPricesHandle is : \n" + contentBody : "Error retrieving prices\n" + "Thread inactive or expired?", contentBody != null);
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
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            string res = "Dispose successful: \n " + contentBody + "\nThe canceled sales price is: " + defPriceHandle.ToString();
            if (handle == 0)
            {
                ShowResult("Impossible to cancel. No SalesPrices created.\n" + "Thread inactive or expired?", false);
            }
            else
                ShowResult(res, contentBody);
        }

        private void btnUseLogInCnxt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            if (countdownTimer != null)
            {
                countdownTimer.Stop();
            }
            thread = manager.webMethodsManager.UseLoginContext(manager.authenticationManager.userData, DateTime.Now);
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
            if (thread == true)
            {
                ThreadStatusPanel.Visible = true;
                ThreadStatusPanel.BackColor = Color.LimeGreen;
                labelThred.Text = "Thread active";
            }
            else
            {
                ThreadStatusPanel.BackColor = Color.Red;
            }
        }

        private void btnReleaseLogInCnxt_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            thread = manager.webMethodsManager.ReleaseLoginContext(manager.authenticationManager.userData, DateTime.Now);
            if (thread == true)
            {
                StartCountdown();
                thread = false;
            }
            labelWbUrl.Text = manager.webMethodsManager.requestTb.ToString();
        }

        ////////////////////////////////
        /////  DATA SERVICE BTN   /////
        ///////////////////////////////

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

                try
                {
                    string basePath = manager.tbFsServiceManager.Path;
                    if (string.IsNullOrEmpty(basePath))
                    {
                        Console.WriteLine("Base Path is null.");
                        return;
                    }
                    string parentPath = System.IO.Path.GetDirectoryName(basePath);
                    if (string.IsNullOrEmpty(parentPath))
                    {
                        Console.WriteLine("Impossible retrive Path");
                        return;
                    }
                    string extendedPath = System.IO.Path.Combine(parentPath, module, "ReferenceObjects");

                    manager.tbFsServiceManager.CurrentPath = extendedPath;

                    if (!System.IO.Directory.Exists(extendedPath))
                    {
                        MessageBox.Show("ReferenceObjects directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        int selectedIndex = cbxModRObj.SelectedIndex;
                        cbxDocRObj.Text = "ReferenceObjects";
                        return;
                    }

                    PopulateFileList(extendedPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
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

                    // 2. Populated combobox "Types" tag <Selection>
                    IEnumerable<string> selectionTypes = loadedXmlDocument
                        .Descendants("SelectionTypes")
                        .Descendants("Selection")
                        .Attributes("type")
                        .Select(attr => attr.Value);

                    if (selectionTypes.Any())
                    {
                        cbxSelectionType.DataSource = selectionTypes.ToList(); // Populated  combobox
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

        private void cbxSelectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSelectionType.SelectedItem != null)
            {
                if (cbxSelectionType.SelectedItem.ToString() == "AddQueryHere")
                {
                    cbxSelectionType.Text = "";
                }
                else
                {
                    cbxSelectionType.Text = cbxSelectionType.SelectedItem.ToString();
                }
            }
        }


        private void BtnViewModifyXml_Click(object sender, EventArgs e)
        {
            if (loadedXmlDocument == null)
            {
                MessageBox.Show("No XML document was loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string content = loadedXmlDocument.ToString();
            FormRefObj formRefObj = new FormRefObj(content, manager);
            formRefObj.ShowDialog();
            labelDataUrl.Text = UrlSManager.TbFsServiceUrl + "/tbfs-service/UploadObject/";
        }


        public enum ObjectType { Document, Report, File, Image, Text, Folder, CreateFolder, CurrentModuleRoot, Setting, Profile, ProfileFile, ReportDescription, ReferenceObject, FormatFont, Pdf, Rtf }



        private async void BtnUploadRefObj_Click(object sender, EventArgs e)
        {

            try
            {
                int statusCode = await UploadObject();

                MessageBox.Show($"Upload done: {statusCode}");
                BtnUploadRefObj.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while uploading: {ex.Message}");
                BtnUploadRefObj.ForeColor = Color.Red;
            }
        }

        private async Task<int> UploadObject()
        {
            string startPath = "";
            string filePath = $@"{manager.tbFsServiceManager.CurrentPath}\{manager.tbFsServiceManager.selDocObj}";
            string currNamespace = manager.tbFsServiceManager.selApp + "." + manager.tbFsServiceManager.selMod;
            string user = "AllUsers";

            //  MultipartFormData
            var form = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

            form.Add(fileContent, "files", Path.GetFileName(filePath));
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(ObjectType.ReferenceObject.ToString())), "objectType");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(currNamespace)), "currentNamespace");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(user)), "user");
            form.Add(new ByteArrayContent(Encoding.UTF8.GetBytes(startPath)), "startPath");

            // URL Prepare
            UrlSManager Urls = new UrlSManager();
            if (UrlSManager.TbFsServiceUrl == "")
                UrlSManager.TbFsServiceUrl = Urls.RetriveUrl(manager.authenticationManager.userData, DateTime.Now, "/TBFSSERVICE");

            string urltbfs = UrlSManager.TbFsServiceUrl + "/tbfs-service/UploadObject/";

            using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(urltbfs)))
            {
                request.Content = form;

                TbApiTesterManager.PrepareHeaderAutorization(request, manager.authenticationManager.userData);

                using (HttpClient httpClient = new HttpClient())
                {
                    TbResponse opResult = null;

                    using (var response = await httpClient.SendAsync(request))
                    {
                        opResult = new TbResponse
                        {
                            StatusCode = (int)response.StatusCode
                        };

                        string result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Upload result: {result}");

                        return opResult.StatusCode;
                    }
                }
            }
        }
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

                if (cbxSelectionType.SelectedItem != null || !string.IsNullOrWhiteSpace(cbxSelectionType.Text))
                {
                    selectionType = cbxSelectionType.Text;
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
            info = content;
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
                Console.WriteLine("Error joQ1: " + ex.Message);
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
                Console.WriteLine("Error joQ2: " + ex.Message);
            }
            string args_valQ2 = joQ2.ToString();

            // Read the ComboBox selection
            string selectedQuery = comboBoxQuery.SelectedItem?.ToString() ?? "";

            string result = "";
            switch (selectedQuery)
            {
                case "Radar":
                    result = manager.dataServiceManager.GetData(
                        manager.authenticationManager.userData,
                        "radar",
                        "ERP.SaleOrders.Dbl.OrdsLists",
                        ref bOk
                    );
                    labelQuery.Text = $"Query: {selectedQuery}\nData: {ordDate.ToShortDateString()}";
                    break;

                case "Q1":
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
                    MessageBox.Show("Please select a query from the list.");
                    return;
            }
            ShowResult($"Result {selectedQuery}:\n{result}", bOk);
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
            var pdfDirectory = RsManager.PdfDirectory;

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


        private async void CbxDmsApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    manager.tbFsServiceManager.selApp = (CbxDmsApp.SelectedItem == null) ? string.Empty : CbxDmsApp.SelectedItem.ToString();


            //    if (manager.tbFsServiceManager.selApp != "Application")
            //        await FillModules(manager.tbFsServiceManager.selApp);

        }
        //___________________________________________________________
        private async void cbxDmsMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //manager.tbFsServiceManager.selMod = (cbxDmsMod.SelectedItem == null) ? string.Empty : cbxDmsMod.SelectedItem.ToString();


            //if (manager.tbFsServiceManager.selMod != "Module")
            //{
            //    string application = manager.tbFsServiceManager.selApp;
            //    string module = manager.tbFsServiceManager.selMod;
            //    if (manager.tbFsServiceManager.DocumentPath != null && manager.tbFsServiceManager.DocumentPath.Count > 0 && cbxDmsMod != null && cbxDmsMod.SelectedIndex > -1)
            //    {
            //        manager.tbFsServiceManager.CurrentDocNS = manager.tbFsServiceManager.DocumentNamespace[cbxDmsDoc.SelectedIndex];
            //    }
            //    await FillDocuments(application, module);

            //}


        }
        //___________________________________________________________
        private async void cbxDmsDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //manager.tbFsServiceManager.selDoc = (cbxDmsDoc.SelectedItem == null) ? string.Empty : cbxDmsDoc.SelectedItem.ToString();

            //if (cbxDmsDoc.Items.Count == 0 || cbxDmsDoc.SelectedIndex < 0)
            //{
            //    return; 
            //}
            //if (manager.tbFsServiceManager.selDoc != "Document")
            //{
            //    string application = manager.tbFsServiceManager.selApp;
            //    string module = manager.tbFsServiceManager.selMod;
            //    string folderName = manager.tbFsServiceManager.selDoc;
            //    if (manager.tbFsServiceManager.DocumentNamespace != null && manager.tbFsServiceManager.DocumentNamespace.Count > 0 && cbxDocReport != null && cbxDocReport.SelectedIndex > -1)
            //    {
            //        manager.tbFsServiceManager.CurrentDocNS = manager.tbFsServiceManager.DocumentNamespace[cbxDocReport.SelectedIndex - 1];
            //    }
            //    await FillProfiles(application, module, folderName);
            //}
        }

        private async void btnGetBinary_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            string archiveDocId = txtArchiveDocId.Text.Trim(); // Prende il valore dall'interfaccia

            if (string.IsNullOrEmpty(archiveDocId))
            {
                MessageBox.Show("Please enter an ArchiveDocId.");
                return;
            }

            try
            {
                string responseBody = await manager.dmsManager.GetBinary(manager.authenticationManager.userData, archiveDocId);

                if (!string.IsNullOrEmpty(responseBody))
                {
                    JObject jsonResponse = JObject.Parse(responseBody);

                    if (jsonResponse["Content"]?["Item1"] != null && jsonResponse["Content"]?["Item2"] != null)
                    {
                        base64Data = jsonResponse["Content"]["Item1"].ToString();
                        fileName = jsonResponse["Content"]["Item2"].ToString();
                        byte[] fileBytes = Convert.FromBase64String(base64Data);

                        string extension = Path.GetExtension(fileName).ToLower();

                        switch (extension)
                        {
                            case ".jpg":
                            case ".jpeg":
                            case ".png":
                            case ".bmp":
                            case ".gif":
                                System.Drawing.Image image = Base64ToImage(base64Data);
                                ShowImage(image, fileName);
                                break;

                            case ".pdf":
                                string pdfPath = SaveFile(fileBytes, fileName);
                                OpenFile(pdfPath);
                                break;

                            case ".txt":
                            case ".log":
                                string textContent = Encoding.UTF8.GetString(fileBytes);
                                ShowText(textContent, fileName);
                                break;

                            default:
                                string filePath = SaveFile(fileBytes, fileName);
                                MessageBox.Show($"File saved: {filePath}", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                        textBoxfilename.Text = fileName;
                    }
                    else
                    {
                        MessageBox.Show("Invalid response format.");
                    }
                }
                else
                {
                    MessageBox.Show("Error retrieving DmsSetting.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void btnAttachBinary_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }

            string responseBody = await manager.dmsManager.AttachBinarycontent(manager.authenticationManager.userData, base64Data, textBoxfilename.Text, txtBoxErpTbGuid.Text, txtBoxERPDocNs.Text, txtBoxERPpkv.Text);

            return;
        }

        private async void btnArchiveBinary_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            fileName = textBoxfilename.Text;
            string responseBody = await manager.dmsManager.ArchiveBinarycontent(manager.authenticationManager.userData, base64Data, textBoxfilename.Text);
            return;
        }

        // Funzione per convertire base64 in immagine
        private System.Drawing.Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        // Funzione per salvare il file ricevuto su disco
        private string SaveFile(byte[] fileBytes, string fileName)
        {
            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            File.WriteAllBytes(savePath, fileBytes);
            return savePath;
        }

        // Funzione per mostrare il file di testo in un MessageBox o TextBox
        private void ShowText(string text, string fileName)
        {
            Form textForm = new Form
            {
                Text = $"Text Preview: {fileName}",
                Size = new Size(600, 400)
            };

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox
            {
                Multiline = true,
                ScrollBars = System.Windows.Forms.ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Text = text
            };

            textForm.Controls.Add(textBox);
            textForm.ShowDialog();
        }

        // Funzione per aprire file PDF o altri file con il programma predefinito
        private void OpenFile(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot open file: {ex.Message}");
            }
        }

        // Funzione per mostrare l'immagine in una PictureBox
        private void ShowImage(System.Drawing.Image image, string fileName)
        {
            Form imageForm = new Form
            {
                Text = $"Preview: {fileName}",
                Size = new Size(600, 400)
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            imageForm.Controls.Add(pictureBox);
            imageForm.ShowDialog();
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();

        }

        private void btnTableSchema_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            TbResponse responseS = manager.dmMMSManager.Schema(manager.authenticationManager.userData, MA_CustSupp.TableName).Result;
            if (responseS == null || !responseS.Success)
            {
                btnTableSchema.ForeColor = Color.Red;
                return;
            }

            string schemaContentBody = responseS.PlainResult ?? "No data available";

            // Display success message
            ShowResult($"TableSchema {MA_CustSupp.TableName} OK");

            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
            if (SelectResponse == null || !SelectResponse.Success)
            {
                btnSelect.ForeColor = Color.Red;
                return;
            }
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
            if (CountResponse == null || !CountResponse.Success)
            {
                btnCount.ForeColor = Color.Red;
                return;
            }
            string CountContentBody = (string)CountResponse.ReturnValue;
            string contentBody = CountContentBody;
            labelCount.Text = "Count " + MA_CustSupp.TableName + " = " + contentBody;
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
            if (selectByKeyResponse == null || !selectByKeyResponse.Success)
            {
                btnSelectAllByKey.ForeColor = Color.Red;
                return;
            }
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
                DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
                if (updateResponse.Success != true)
                    MessageBox.Show($"Table not Updated ({updateResponse.StatusCode})");
                else
                    MessageBox.Show($"Table Updated Successfully ({updateResponse.StatusCode})");
                return;
            }
            else
            {
                TbResponse addResponse = manager.dmMMSManager.Add(manager.authenticationManager.userData, crudData).Result;
                DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
        }

        private void btnMultipleAdd_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please login!", "Authentication Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "This action will add 400 fields. Do you want to continue?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                MultipleAdd();
                DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
            }
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
                DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
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
                // ComboBox element
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
            //Inventory Entry = 3801093
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
            DmMMSUrl.Text = manager.dmMMSManager.requestDMMS.ToString();
        }

        private void btnGetEnumsInfo_Click(object sender, EventArgs e)
        {
            string content = $"\n-getEnumsTable: {UrlSManager.EnumsTableUrl}enums-service/getEnumsTable/\n\nThis endpoint is used to retrieve the list of available Archive Type";
            ShowResult(content, false, true, true);
        }


        private void cbxServicesWeb_DropDown(object sender, EventArgs e)
        {
            PopulateServicesComboBox();
        }

        private void PopulateServicesComboBox()
        {
            ServiceManager serviceManager = new ServiceManager();
            var servicesStatus = serviceManager.GetServicesStatus();

            cbxServicesWeb.Items.Clear();

            foreach (var (serviceName, status) in servicesStatus)
            {
                string displayText = $"{serviceName} - {status}";

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
                //  Regex  JSON
                var matches = Regex.Matches(fileContent, @"\{.*?\}(?=\s*\{|\s*$)", RegexOptions.Singleline);

                foreach (Match match in matches)
                {
                    try
                    {
                        Function function = JsonConvert.DeserializeObject<Function>(match.Value);

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

            if (btnExpandDynamicQueries.Text == "Try")
            {
                string content =
                  "The OrderLists is not a Mago document.\r\nIt was created for this example you can find it in the Docs folder in this project\n" +
                  "You can use it by adding it to your environment at the following path:\n" +
                  "YourEnvironment\\Standard\\Applications\\ERP\\SaleOrders\\ReferenceObjects";
                ShowResult(content, false, true, true);

                btnExpandDynamicQueries.Text = "Close";
                DynamicQueriesPanel.Dock = DockStyle.None;
                DynamicQueriesPanel.Visible = true;
            }
            else
            {
                btnExpandDynamicQueries.Text = "Try";
                DynamicQueriesPanel.Dock = DockStyle.None;
                DynamicQueriesPanel.Visible = false;
            }
        }



        private void btnSaveXmlTbServer_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;

            string docsDirectory = Path.Combine(projectDirectory, "Docs");

            // Determine the name of the subfolder based on the label text
            string subFolderName = string.Empty;
            if (labelCallTbResult.Text == "Result GetXmlParams:")
            {
                subFolderName = "GetXmlParams";
            }
            else if (labelCallTbResult.Text == "Result GetXmlData:")
            {
                subFolderName = "GetXmlData";
            }
            else if (labelCallTbResult.Text == "Result SetXmlData:")
            {
                subFolderName = "SetXmlData";
            }

            // Set the full path of the directory
            string targetDirectory = string.IsNullOrEmpty(subFolderName) ? docsDirectory : Path.Combine(docsDirectory, subFolderName);

            // Create the folder if it doesn't exist
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            // Set the file path
            string filePath = Path.Combine(targetDirectory, manager.tbFsServiceManager.selDoc + ".xml");

            // Save the XML file
            File.WriteAllText(filePath, xmlEditorTbResult.TextContent);

            MessageBox.Show($"The file has been saved in the folder:\n{targetDirectory}", "Save Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            string docsDirectory = Path.Combine(projectDirectory, "Docs");

            if (Directory.Exists(docsDirectory))
            {
                Process.Start("explorer.exe", docsDirectory);
            }
            else
            {
                MessageBox.Show("The 'Docs' folder does not exist.", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //////////////////////////
        ///DOC BUSINESS OBJECT///
        /////////////////////////

        private async void btnBusinessObj_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:1234/OttieniToken-MOToken-service/OttieniTokenMOTokenDocOttieniToken/ApriSaleOrdExt";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestData = new JObject();
                    var content = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    labelBObjUrl.Text = url.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Documento aperto: " + result);
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eccezione: {ex.Message}");
                }
            }
        }

        private async void btnTokenEsterno_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:1234/OttieniToken-MOToken-service/OttieniTokenMOTokenDocOttieniToken/PrendoIlToken";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestData = new JObject();
                    var content = new StringContent(requestData.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    labelBObjUrl.Text = url.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Token ricevuto: " + result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eccezione: {ex.Message}");
                }
            }
        }


        ////////////////////
        ///TODO LOGS Btn///
        //////////////////

        private void AppendToLog(string text)
        {
            if (richTextLog.InvokeRequired)
            {
                richTextLog.Invoke(new Action(() => AppendToLog(text)));
            }
            else
            {
                richTextLog.AppendText($"{text}{Environment.NewLine}");
                richTextLog.ScrollToCaret();
            }
        }


        private void btnClearLog_Click(object sender, EventArgs e)
        {
            if (manager.tbServerManager != null)
            {
                manager.logsManager.ClearLogs();
                richTextLog.Text = string.Empty;
            }

        }
        private void btnTbServerLog_Click(object sender, EventArgs e)
        {
            richTextLog.Text = string.Empty;
            richTextLog.Text = string.Empty;

            bool isTbServerEmpty = manager.tbServerManager.requestTbList.Count == 0 && manager.tbServerManager.responseTbList.Count == 0;
            bool isWebMethodsEmpty = manager.webMethodsManager.requestTbList.Count == 0 && manager.webMethodsManager.responseTbList.Count == 0;

            if (isTbServerEmpty && isWebMethodsEmpty)
            {
                AppendToLog("⚠️ Nessun log disponibile.");
                return;
            }

            StringBuilder logBuilder = new StringBuilder();

            // Log to tbServerManager
            if (!isTbServerEmpty)
            {
                logBuilder.AppendLine("===== 📡 TB SERVER LOG =====");
                for (int i = 0; i < manager.tbServerManager.requestTbList.Count; i++)
                {
                    logBuilder.AppendLine($"🟢 REQUEST: {manager.tbServerManager.requestTbList[i]}");

                    if (i < manager.tbServerManager.responseTbList.Count)
                    {
                        logBuilder.AppendLine($"🔵 RESPONSE: {manager.tbServerManager.responseTbList[i]}");
                    }
                    else
                    {
                        logBuilder.AppendLine("⚠️ No Response");
                    }
                    logBuilder.AppendLine(new string('=', 60));
                }
            }

            // Log to webMethodsManager
            if (!isWebMethodsEmpty)
            {
                logBuilder.AppendLine("===== 🌐 WEB METHODS LOG =====");
                for (int i = 0; i < manager.webMethodsManager.requestTbList.Count; i++)
                {
                    logBuilder.AppendLine($"🟢 REQUEST: {manager.webMethodsManager.requestTbList[i]}");

                    if (i < manager.webMethodsManager.responseTbList.Count)
                    {
                        logBuilder.AppendLine($"🔵 RESPONSE: {manager.webMethodsManager.responseTbList[i]}");
                    }
                    else
                    {
                        logBuilder.AppendLine("⚠️ No Response");
                    }
                    logBuilder.AppendLine(new string('=', 60));
                }
            }

            AppendToLog(logBuilder.ToString());
        }


        private void btnDataServiceLogs_Click(object sender, EventArgs e)
        {
            richTextLog.Text = string.Empty;
            if (manager.dataServiceManager.requestDsList.Count == 0 && manager.dataServiceManager.requestDsList.Count == 0)
            {
                AppendToLog("⚠️");
                return;
            }

            StringBuilder logBuilder = new StringBuilder();

            for (int i = 0; i < manager.dataServiceManager.requestDsList.Count; i++)
            {
                logBuilder.AppendLine($"🟢 REQUEST: {manager.dataServiceManager.requestDsList[i]}");

                if (i < manager.dataServiceManager.responseDsList.Count)
                {
                    logBuilder.AppendLine($"🔵 RESPONSE: {manager.dataServiceManager.responseDsList[i]}");
                }
                else
                {
                    logBuilder.AppendLine($"⚠️ No Response");
                }
                logBuilder.AppendLine(new string('=', 60)); // Separatore
            }

            AppendToLog(logBuilder.ToString());
        }

        private void btnReportingServiceLog_Click(object sender, EventArgs e)
        {
            richTextLog.Text = string.Empty;
            if (manager.rsManager.requestRsList.Count == 0 && manager.rsManager.requestRsList.Count == 0)
            {
                AppendToLog("⚠️");
                return;
            }

            StringBuilder logBuilder = new StringBuilder();

            for (int i = 0; i < manager.rsManager.requestRsList.Count; i++)
            {
                logBuilder.AppendLine($"🟢 REQUEST: {manager.rsManager.requestRsList[i]}");

                if (i < manager.rsManager.responseRsList.Count)
                {
                    logBuilder.AppendLine($"🔵 RESPONSE: {manager.rsManager.responseRsList[i]}");
                }
                else
                {
                    logBuilder.AppendLine($"⚠️ No Response");
                }
                logBuilder.AppendLine(new string('=', 60)); // Separatore
            }

            AppendToLog(logBuilder.ToString());
        }

        private void btnDataManagerLog_Click(object sender, EventArgs e)
        {
            richTextLog.Text = string.Empty;
            if (manager.rsManager.requestRsList.Count == 0 && manager.rsManager.requestRsList.Count == 0)
            {
                AppendToLog("⚠️");
                return;
            }

            StringBuilder logBuilder = new StringBuilder();

            for (int i = 0; i < manager.dmMMSManager.requestDMMSList.Count; i++)
            {
                logBuilder.AppendLine($"🟢 REQUEST: {manager.dmMMSManager.requestDMMSList[i]}");

                if (i < manager.dmMMSManager.responseDMMSList.Count)
                {
                    logBuilder.AppendLine($"🔵 RESPONSE: {manager.dmMMSManager.responseDMMSList[i]}");
                }
                else
                {
                    logBuilder.AppendLine($"⚠️ No Response");
                }
                logBuilder.AppendLine(new string('=', 60)); // Separatore
            }

            AppendToLog(logBuilder.ToString());

        }

        
    }
}




