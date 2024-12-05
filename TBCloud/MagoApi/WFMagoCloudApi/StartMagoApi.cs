using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbApiTester
{

    public partial class StartMagoApi : Form
    {
        public static bool IsCloudButtonClicked { get; set; }
        
        public StartMagoApi()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void btnCloud_Click(object sender, EventArgs e)
        {

            ClickBtn(GlobalSettings.ButtonState.Cloud);
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            ClickBtn(GlobalSettings.ButtonState.Web);
        }

        private void btnDevEnv_Click(object sender, EventArgs e)
        {
            ClickBtn(GlobalSettings.ButtonState.DevEnv);
        }

        public void ClickBtn(GlobalSettings.ButtonState click)
        {
            this.Hide(); // Nascondi il form attuale
            GlobalSettings.CurrentButtonState = click;
            TbApiTester mainForm = new TbApiTester(IsCloudButtonClicked);
            mainForm.ShowDialog();
            this.Close();
        }

    }
    public static class GlobalSettings
    {
        public static ButtonState CurrentButtonState { get; set; }

        public enum ButtonState
        {
            None,
            Cloud,
            Web,
            DevEnv
        }
    }
}
