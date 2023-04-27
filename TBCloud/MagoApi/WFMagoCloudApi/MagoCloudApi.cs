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


        public MagoCloudApi()
        {
            InitializeComponent();
           
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            tabNavigation.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(4, 0, tabNavigation.Width, tabNavigation.Height, 0, 20));
            tabNavigation.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabNavigation.DrawItem += tabNavigation_DrawItem;
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
            labelMagicLinkGet.Text = "The TbServerGate microservice exposes the possibility to menage\n" +
                                     "business objects based on MagicLink desktop technology.\n" +
                                     "GetXmlData: retrives the entire business object data defined in the\n" +
                                     "export profile.\n" +
                                     "SetXmlData: allows the data of a business object to be\n" +
                                     "written to MagoCloud using the Xml payload.";

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
        bool  mousedown;
        public long defPriceHandle = 0;
        public Process p = null;

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
            Font tabFont = new Font("Century Gothic", 10, FontStyle.Bold);
            RectangleF tf =
                new RectangleF(paddedBounds.X + paddedBounds.Width + 354,
                paddedBounds.Y - 1, this.Width - (paddedBounds.X + paddedBounds.Width) -1 , paddedBounds.Height + 11);
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
                p = Process.Start(solutionPath, filePath);
                Thread.Sleep(2000);
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
        private void button_Login_Click(object sender, System.EventArgs e)
        {
            if (AreParametersOk())
                manager.authenticationManager.DoLogin(text_http.Text, text_user.Text, text_pwd.Text, text_subscription.Text, text_producer.Text, text_app.Text);
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
            Application.Exit();
        }

        ////////////////////////
        ///// RESULT WINDOW ////
        ////////////////////////
        private void ShowResult(string content, bool bOk = true, bool bBlue=false)
        {
            Form form = new WindowsFormsResult.FormResult(content, bOk, bBlue);
            form.ShowDialog(this);
            Cursor = Cursors.Default;
        }

        //////////////////////
        ///// CODE WINDOW ////
        //////////////////////
        private void ShowCode(string content, bool bOk = false, bool bBlue = true, Image image =null)
        {
            Form form = new WindowsFormsResult.FormResult(content, bOk, bBlue, image);
            form.ShowDialog(this);
        }

        ////////////////////////
        ///// TBSERVER BTN /////
        ////////////////////////

        private async void BtnGetParams_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            //string fileName = Path.Combine(Application.StartupPath, "CustomersGetParams.xml");
            string fileName = Path.Combine(Application.StartupPath, "NewCurrGetParams.xml");

            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);
            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            string contentBody = await manager.tbServerManager.GetXmlParams(manager.authenticationManager.userData, DateTime.Now, fileContent);
            labelTbUrl.Text = UrlSManager.TbServerUrl;
            ShowResult(contentBody != null ? "GetXMLParams\n" + contentBody : "Unable to retrieve GetXMLParams\n" + contentBody, contentBody != null);
        }
        private async void buttonGetTb_Click(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            //string fileName = Path.Combine(Application.StartupPath, "CustomersGet.xml");
            string fileName = Path.Combine(Application.StartupPath, "NewCurrGet.xml");


            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);
            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            string contentBody = await manager.tbServerManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
            
            ShowResult(contentBody != null ? "Get XML:\n" + contentBody : "Unable to retrieve Get XML\n" + contentBody, contentBody != null);
            labelTbUrl.Text = UrlSManager.TbServerUrl;
        }

        private void LabelbuttonGetParam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, "CustomersSet.xml");

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
            //string fileName = Path.Combine(Application.StartupPath, "Customers1.xml");
            string fileName = Path.Combine(Application.StartupPath, "NewCurrSet.xml");


            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);
            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            string contentBody = manager.tbServerManager.SetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
            labelTbUrl.Text = UrlSManager.TbServerUrl;
            ShowResult(contentBody != null ? "Set XML\n" + contentBody : "Unable to retrieve Set XML\n" + contentBody, contentBody != null);
        }

        private void LabelbuttonSetParam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, "Customers1.xml");

            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);

            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            XDocument doc = XDocument.Parse(fileContent);
            ShowResult(doc != null ? "SetParam:\n" + doc : "Unable to retrieve SetParam\n" + doc, doc != null);
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
            DateTime now = new DateTime(2022,12,31);
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
            string contentBody = manager.webMethodsManager.ClosingDateFiscalYear(manager.authenticationManager.userData,DateTime.Now);
           
            ShowResult(contentBody != null ? "ClosingDate\n"+ contentBody : "Unable to retrieve ClosingDate\n" + contentBody, contentBody != null);
        }
         
        ///// DEFPRICE BTN ///////
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
                + "You have created the handle number : \n" + defPriceHandle.ToString(), defPriceHandle >= 1); if (defPriceHandle < 1);
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
            }else
            ShowResult(res, contentBody);
        }

        ///////////////////////////////
        ////// DATA SERVICE BTN ///////
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
                string contentBody = "DataServiceGetData: " + selectionType +"\n"+ manager.dataServiceManager.GetData(manager.authenticationManager.userData, selectionType, textBoxNameSpace.Text, ref bOk);
                ShowResult(contentBody,bOk);
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
                string.IsNullOrEmpty(text_app.Text)||
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
            //manager.rsManager.RetriveRsUrl(manager.authenticationManager.userData, DateTime.Now);
            string contentBody= manager.rsManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, 0);
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
            ShowResult(contentBody != null ? "DmsSetting: \n "+ contentBody : "Error retrieving DmsSetting", contentBody != null);
        }

        ///////////////////////
        //// BTN SOURCECODE  //
        //////////////////////
        private void linkHelpTb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string contentBody = manager.exampleManager.ExampleTb();
            OpenVisualStudio(@"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\WFMagoCloudApi.sln", @"C:\mago\tbde-samples\TBCloud\MagoApi\WFMagoCloudApi\TbServerManager.cs");
            ////ShowCode(contentBody);
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
