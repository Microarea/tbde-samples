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
            tabNavigation.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabNavigation.DrawItem += tabNavigation_DrawItem;
            this.tabNavigation.TabPages.Remove(this.tabMSH);
          
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


        public long defPriceHandle = 0;
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
            paddedBounds = new Rectangle(paddedBounds.X, paddedBounds.Y + 4, paddedBounds.Width, paddedBounds.Height - 4);
            Font tabFont = new Font("Century Gothic", 10, FontStyle.Bold);
            RectangleF tf =
                new RectangleF(paddedBounds.X + paddedBounds.Width + 354,
                paddedBounds.Y - 1, this.Width - (paddedBounds.X + paddedBounds.Width) - 1, paddedBounds.Height + 1);
            Brush b;
            b = new SolidBrush(Color.FromArgb(22, 118, 186));
            e.Graphics.DrawString(tabName, tabFont, tabBrush, paddedBounds, stringFormat);
            e.Graphics.FillRectangle(b, tf);
        }

          ///////////////////////
         ///// FORM BTN ////////
        ///////////////////////
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
        private void ShowResult(string content, bool bOk = true)
        {
            Form form = new WindowsFormsApp1.FormResult(content, bOk);
            form.ShowDialog(this);
        }

          ////////////////////////
         ///// TBSERVER BTN /////
        ////////////////////////
        private async void buttonXmlTb_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string fileName = Path.Combine(Application.StartupPath, "Customers.xml");

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
            string fileName = Path.Combine(Application.StartupPath, "Customers.xml");

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
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string fileName = Path.Combine(Application.StartupPath, "Customers1.xml");

            (bool loaded, string fileContent) = manager.tbServerManager.LoadMagicLinkFile(fileName);
            if (!loaded)
            {
                MessageBox.Show(fileContent);
                return;
            }
            string contentBody = manager.tbServerManager.SetXmlData(manager.authenticationManager.userData, DateTime.Now, fileContent);
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
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            defPriceHandle = manager.webMethodsManager.DefaultSalesPricesCreate(manager.authenticationManager.userData, DateTime.Now);
            ShowResult(defPriceHandle < 1 ? "The creation is not successful : \n" + defPriceHandle.ToString() : "Successful \n" 
                + "You have created the frame number : \n" + defPriceHandle.ToString(), defPriceHandle >= 1); if (defPriceHandle < 1);
        }     
        private void btnGetDefPrice_Click(object sender, EventArgs e)
        {
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
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            long handle = defPriceHandle;
            bool contentBody = manager.webMethodsManager.DefaultSalesPricesDispose(manager.authenticationManager.userData, DateTime.Now, handle);
            string res = "Dispose successful: \n " + contentBody + "\nThe canceled sales price is: " + defPriceHandle.ToString();
            ShowResult(res, contentBody);
        }

          ///////////////////////////////
         ////// DATA SERVICE BTN ///////
        ///////////////////////////////

        private void buttonDSGetData_Click(object sender, EventArgs e)
        {
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
                string.IsNullOrEmpty(text_http.Text) ||
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
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            manager.rsManager.RetriveRsUrl(manager.authenticationManager.userData, DateTime.Now);
            string contentBody= manager.rsManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, 0);
            ShowResult(contentBody != null && contentBody != "" ? contentBody : "Unable to retrieve items\n" + contentBody, contentBody != null && contentBody != "");
            labelRsUrl.Text = UrlSManager.DataServiceUrl;
        }

        private void btnGetRsCustomers_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.rsManager.GetXmlData(manager.authenticationManager.userData, DateTime.Now, 1);
            ShowResult(contentBody != null && contentBody != "" ? "GetRsCustomer\n" + contentBody : "Unable to retrieve customer\n" + contentBody, contentBody != null && contentBody != "");
        }

          ///////////////////////
         /////   DMS BTN  //////
        ///////////////////////
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

        private void cbxSelectionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
