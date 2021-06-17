using MyApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyWinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = "";
                List<string> messages = CheckData();
                if (messages?.Count == 0)
                {
                    if (await MyClient.Execute(txtUrl.Text, txtAccount.Text, txtPwd.Text, txtSubKey.Text))
                        lblResult.Text = "Text executed correctly!";
                }
                else
                {
                    lblResult.Text = "Invalid Input! Please fix following problems:";
                    foreach (string msg in messages)
                        lblResult.Text += "\r\n - " + msg;
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
                throw;
            }
  
        }

        private List<string> CheckData()
        {
            List<string> messages = new List<string>();
            if (string.IsNullOrEmpty(txtUrl.Text))
                messages.Add("Missing Instance or GWAM Url field");

            if (string.IsNullOrEmpty(txtAccount.Text))
                messages.Add("Missing Provisioning Account Name field");

            if (string.IsNullOrEmpty(txtPwd.Text))
                messages.Add("Missing Provisioning Account Password field");
            
            if (string.IsNullOrEmpty(txtSubKey.Text))
                messages.Add("Missing Subscription Key field");
            return messages;
        }
    }

}
