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
            this.tabNavigation.TabPages.Remove(this.tabDMS);
            this.tabNavigation.TabPages.Remove(this.tabMSH);

        }
       

        private void tabNavigation_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.CadetBlue, e.Bounds);
                e.DrawFocusRectangle();
                e.DrawBackground();
                Color tabTextColor = Color.FromArgb(22, 118, 186);
                var color = Color.FromArgb(255, 255, 255);

                TextRenderer.DrawText(e.Graphics, tabNavigation.TabPages[e.Index].Text, e.Font, e.Bounds, color, tabTextColor);
            }
            else
            {
                // Draw the background for an unselected item.
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.DrawFocusRectangle();
                var color = Color.FromArgb(22, 118, 186);

                TextRenderer.DrawText(e.Graphics, tabNavigation.TabPages[e.Index].Text, e.Font, e.Bounds, color);
            }
        }

       


                private void button_Login_Click(object sender, System.EventArgs e)
                {
                    if (AreParametersOk())
                       manager.authenticationManager.DoLogin(text_user.Text, text_pwd.Text, text_subscription.Text, text_producer.Text, text_app.Text);   
                }

                private void button_Token_Click(object sender, EventArgs e)
                {
                    if (manager.authenticationManager.IsLogged())
                        manager.authenticationManager.ValidToken();
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
                        manager.authenticationManager.DoLogout();
                    else
                        MessageBox.Show("User is not logged, please Login!");
                }

                private void buttonDSGetData_Click(object sender, EventArgs e)
                {
                    if (!manager.authenticationManager.IsLogged())
                    {
                       MessageBox.Show("User is not logged, please Login!");
                        return;
                    }
                    if (labelDataService != null)
                    {
                        string selectionType = "default";
                        if (cbxSelectionType.SelectedItem != null && string.Compare(cbxSelectionType.SelectedItem.ToString(), "radar", true) == 0)
                            selectionType = "radar";
                        string contentBody =  manager.dataServiceManager.GetData(manager.authenticationManager.userData, selectionType, labelNameSpace.Text);
                        ShowResult(contentBody);
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
                       string.IsNullOrEmpty(text_app.Text)
                   )
                 
                   {
                    MessageBox.Show("Please enter your authority information to continue (user name, passowrd, subscription key, producer key and app key)");
                    text_user.Focus();
                   }
                   return true;
        }

        private void DoExit()
        {
            manager.authenticationManager.DoLogout();
            Application.Exit();
        }

        private void ShowResult(string content)
        {
            Form form = new WindowsFormsApp1.FormResult(content);
            form.ShowDialog(this);
        }

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
            ShowResult(contentBody);
        }

        private async void buttonSetTb_Click(object sender, EventArgs e)
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
            string contentBody = await manager.tbServerManager.SetXmlDataAsync(manager.authenticationManager.userData, DateTime.Now, fileContent);
            ShowResult(contentBody);
        }


        private void buttonDSVersion_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dataServiceManager.GetVersion(manager.authenticationManager.userData);
            ShowResult(contentBody);
        }

        private void buttonMicrHome_Click(object sender, EventArgs e)
        {
            if (!manager.authenticationManager.IsLogged())
            {
                MessageBox.Show("User is not logged, please Login!");
                return;
            }
            string contentBody = manager.dataServiceManager.GetHome(manager.authenticationManager.userData);
            ShowResult(contentBody);

        }
    }
}
