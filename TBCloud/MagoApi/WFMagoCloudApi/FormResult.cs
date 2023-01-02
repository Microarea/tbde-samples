using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class FormResult : Form
    {
        public FormResult(string content)
        {
            InitializeComponent();
            labelFormContent.Text = content;
            this.Height = 300;
            this.Width = 500;
        }


        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            Close();
        }

      private bool buttonClicked = false;

        private void buttonResize_Click(object sender, EventArgs e)
        {
            if (buttonClicked) 
            {
                buttonClicked = true;
            }
            else
            {
                this.Height = 600;
                this.Width = 684;
            }
        }

       
    }
}
