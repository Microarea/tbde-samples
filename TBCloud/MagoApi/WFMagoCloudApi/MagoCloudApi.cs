using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using static MspzComponent.RoundedPanel;
using static MspzComponent.OrangePanel;
using System.Diagnostics;
using System.Security.Policy;
using System.Reflection;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;
using Microsoft.VisualStudio.TextManager.Interop;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Net.Mime.MediaTypeNames.Application;
using EnvDTE;
using Microsoft.VisualStudio.OLE.Interop;
using EnvDTE90;
using System.Web.Caching;
using System.Linq;

namespace MagoCloudApi
{
    public partial class MagoCloudApi : Form
    {
        MagoCloudApiManager manager = new MagoCloudApiManager();


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
        public object docinfo { get; private set; }

        bool mousedown;
        public long defPriceHandle = 0;
        public System.Diagnostics.Process p = null;
        private string folderPath = @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\Docs";
        private string inFileName;
        private string outFileName;
        private bool isFolderOpened = false;
        private bool isFullScreen = false;
        public MagoCloudApi()
        {
            InitializeComponent();

            manager.tbServerManager.folderPath = folderPath;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.tabNavigation.TabPages.Remove(this.tabMSH);
            this.cbxSelectionType.SelectedIndex = 0;

            labelTbUrl.Text = "ServiceUrl:";
            labelDmsUrl.Text = "ServiceUrl:";
            labelDataUrl.Text = "ServiceUrl:";
            labelWbUrl.Text = "ServiceUrl:";
            labelRsUrl.Text = "ServiceUrl:";

            //////////// Label descriptive GET DATA SERVICE (DataServiceManager)
            labelDataService.Text = "The DataService microservice exposes the possibility of extracting \n" +
                                    "data that are defined through standard and custom xml contained \n" +
                                    "in the reference objects folder. It then allows you to extract\n" +
                                    "the data defined by a hotlink or radar query.";

            //////////// Label descriptive Microservice (Assembly-version)
            labelAVersion.Text = "Micro-service exposes an API called assemblyVersion that allows\n" +
                                 "the current version of the micro-service to be returned.";

            //////////// Label descriptive MAGIC LINK GETXMLDATA (TbServerManager)
            labelMagicLinkGet.Text = "The TbServerGate microservice exposes the possibility to menage business objects\n" +
                                     "based on MagicLink desktop technology.";
           

            //////////// Label descriptive REPORTING SERVICE (RsManager)
            labelRS.Text = "The ReportingServices microservice exposes the possibility\n" +
                           "of launching a report and obtaining the extracted data.\n" +
                           "The microservice supports both Xml and Json format.\n";

            //////////// Label descriptive  (WebMethod)
            labelWmDescription.Text = "The TbServerGate microservice exposes the possibility to access\n" +
                                      "TbWebMethods (previously SOAP/WCF) via Rest.";

            //////////// Label descriptive  (DMS)
            labelDms.Text = "The DMS (Document Management System) it allows for storing, sharing,\n" +
                            "and managing electronic documents.\n" +
                            "Is a solution for digital document management.";

        }
        private void MagoCloudApi_Load(object sender, EventArgs e)
        {
            // Assegna il testo del tooltip al controllo Tooltip
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.SetToolTip(BtnRefDoc, "Refresh folder");
            myToolTip.SetToolTip(BtnOpenFolder, "Open folder");
            myToolTip.SetToolTip(BtnQuestionCall, "Questions about calls?");
            myToolTip.SetToolTip(BtnFillContent, "Resize TabControl");

            cbxApplication.Items.Add("Application");
            cbxApplication.SelectedIndex = 0;

            cbxModule.Items.Add("Module");
            cbxModule.SelectedIndex = 0;

            cbxDocReport.Items.Add("Document");
            cbxDocReport.SelectedIndex = 0;

            cbxProfile.Items.Add("Profile");
            cbxProfile.SelectedIndex = 0;
            //PopulateComboBox();
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
            if (BtnFillContent.Text == "⬅")//chiude LoginPanel
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
                bok = manager.authenticationManager.DoLogin(text_http.Text, text_user.Text, text_pwd.Text, text_subscription.Text, text_producer.Text, text_app.Text);
            if (bok) _ = FillApplications();
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
        }
        private void button_Logout_Click(object sender, EventArgs e)
        {
            if (manager.authenticationManager.IsLogged())
                manager.authenticationManager.DoLogout(text_http.Text);
            else
                MessageBox.Show("User is not logged, please Login!");
        }
        private void DoExit()
        {
            manager.authenticationManager.DoLogout(text_http.Text);
            System.Windows.Forms.Application.Exit();
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

        //////////////////////
        ///// CODE WINDOW ////
        //////////////////////
        //private void ShowCode(string content, bool bOk = false, bool bBlue = true)
        //{
        //    Form form = new WindowsFormsResult.FormResult(content, bOk, bBlue);
        //    form.ShowDialog(this);
        //}

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

            cbxModule.DataSource = null;
            cbxDocReport.DataSource = null;
            cbxProfile.DataSource = null;
            if (manager.tbFsServiceManager.selApp != "Application")
                await FillModules(manager.tbFsServiceManager.selApp);

        }
        //___________________________________________________________
        private async void cbxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selMod = (cbxModule.SelectedItem == null) ? string.Empty : cbxModule.SelectedItem.ToString();
            cbxDocReport.DataSource = null;
            cbxProfile.DataSource = null;

            if (manager.tbFsServiceManager.selMod != "Module")
            {
                string application = manager.tbFsServiceManager.selApp;
                string module = manager.tbFsServiceManager.selMod;

                await FillDocuments(application, module);

            }
        }
        //___________________________________________________________
        private async void cbxDocReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selDoc = (cbxDocReport.SelectedItem == null) ? string.Empty : cbxDocReport.SelectedItem.ToString();
            cbxProfile.DataSource = null;

            if (manager.tbFsServiceManager.selDoc != "Document")
            {
                string application = manager.tbFsServiceManager.selApp;
                string module = manager.tbFsServiceManager.selMod;
                string folderName = manager.tbFsServiceManager.selDoc;
                if (manager.tbFsServiceManager.DocumentNamespace.Count > 0 && cbxDocReport.SelectedIndex > -1)
                {
                    manager.tbFsServiceManager.CurrentDocNS = manager.tbFsServiceManager.DocumentNamespace[cbxDocReport.SelectedIndex];
                }
                await FillProfiles(application, module, folderName);
            }
        }
        //___________________________________________________________
        private void cbxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            manager.tbFsServiceManager.selProfile = (cbxProfile.SelectedItem == null) ? string.Empty : cbxProfile.SelectedItem.ToString();

            if (manager.tbFsServiceManager.selProfile != "Profile")
            {
                manager.tbFsServiceManager.selProfile = (cbxProfile.SelectedItem == null) ? string.Empty : cbxProfile.SelectedItem.ToString();
            }
        }


        private void BtnRefDoc_Click(object sender, EventArgs e)
        {
            BtnRefDoc.ForeColor = Color.FromArgb(65, 192, 146);
        }
        

        private async void BtnGetParams_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            //Check if a file is selected in the ComboBox
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

            TextBoxDocument.Text = contentBody;
            Cursor = Cursors.Default;
            labelTbUrl.Text = UrlSManager.TbServerUrl;
        }

        private void buttonGetTb_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            // Check if a file is selected in the ComboBox
            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                return;
            }
            string fileContent = TextBoxDocument.Text;
            if (fileContent == string.Empty)
                return;

            TextBoxDocument.Text = fileContent;
            string modifiedXml = TextBoxDocument.Text;

            string contentBody = manager.tbServerManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, modifiedXml);
            labelCallTbResult.Text = "Result GetXmlData:";
            TextBoxDocument.Text = contentBody;
            Cursor = Cursors.Default;
            labelTbUrl.Text = UrlSManager.TbServerUrl;
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
                return;
            }
            // Check if a file is selected in the ComboBox
            if (cbxProfile.SelectedItem == null)
            {
                MessageBox.Show("Please select a file from the list!");
                return;
            }

            string fileContent = TextBoxDocument.Text;
            if (fileContent == string.Empty)
                return;

            TextBoxDocument.Text = fileContent;
            string modifiedXml = TextBoxDocument.Text; // Ottieni il contenuto modificato dalla RichTextBox
            string contentBody = manager.tbServerManager.SetXmlData(manager.authenticationManager.userData, DateTime.Now, modifiedXml);
            labelCallTbResult.Text = "Result SetXmlData:";

            TextBoxDocument.Text = contentBody;
            Cursor = Cursors.Default;
            labelTbUrl.Text = UrlSManager.TbServerUrl;
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

        //////////////////////////////
        ///// TBFSSERVICE MANAGER ////
        //////////////////////////////
        private async Task FillApplications()
        {
            try
            {
                List<string> applications = await manager.tbFsServiceManager.GetApplications(manager.authenticationManager.userData, DateTime.Now);
                if (applications == null)
                    return;

                cbxApplication.DataSource = applications;
                if (applications.Count > 0)

                    cbxApplication.SelectedIndex = 0;
            }
            catch (Exception)
            {
            }
        }

        private async Task FillModules(string application)
        {

            List<string> modules = await manager.tbFsServiceManager.GetModules(manager.authenticationManager.userData, DateTime.Now, application);
            if (modules == null)
                return;

            cbxModule.DataSource = modules;
            if (modules.Count > 0)
                cbxModule.SelectedIndex = 0;
        }

        private async Task FillDocuments(string application, string module)
        {
            (List<string> folderNames, List<string> folderObjectsNS) = await manager.tbFsServiceManager.GetDocumentsFolders(manager.authenticationManager.userData, DateTime.Now, application, module);

            if (folderNames == null)
                return;

            cbxDocReport.DataSource = folderNames; // Remove the DataSource before editing the collection of items
            manager.tbFsServiceManager.DocumentNamespace = folderObjectsNS;
            if (folderNames.Count > 0)
                cbxDocReport.SelectedIndex = 0;
        }

        private async Task FillProfiles(string application, string module, string folderName)
        {
            List<string> profile = await manager.tbFsServiceManager.GetProfiles(manager.authenticationManager.userData, DateTime.Now, application, module, folderName);
            if (profile == null)
                return;
            cbxProfile.DataSource = profile; // Rimuovi il DataSource prima di modificare la raccolta degli elementi

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

            ShowResult(contentBody != null ? "CurrentOpeningDate\n" + contentBody : "Unable to retrieve ClosingDate\n" + contentBody, contentBody != null);
            labelWbUrl.Text = UrlSManager.TbServerUrl;
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

        private void buttonDSGetData_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            else if (textBoxNameSpace.Text != null && textBoxNameSpace.Text != "")
            {
                string selectionType = "default";
                if (cbxSelectionType.SelectedItem != null && string.Compare(cbxSelectionType.SelectedItem.ToString(), "radar", true) == 0)
                    selectionType = "radar";
                else if (cbxSelectionType.SelectedItem != null && string.Compare(cbxSelectionType.SelectedItem.ToString(), "MyQry", true) == 0)
                    selectionType = "MyQry";
                bool bOk = false;
                string contentBody = "DataServiceGetData: " + selectionType + "\n" + manager.dataServiceManager.GetData(manager.authenticationManager.userData, selectionType, textBoxNameSpace.Text, ref bOk);
                ShowResult(contentBody, bOk);
                labelDataUrl.Text = UrlSManager.DataServiceUrl;
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
            labelRsUrl.Text = UrlSManager.ReportingServiceUrl;
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

        ///////////////////////
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

       
    }
}

