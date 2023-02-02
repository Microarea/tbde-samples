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
using static MspzComponent.OrangePanel;

namespace WindowsFormsApp1
{
    public partial class FormResult : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottomRect,
           int nWhidthEllipse,
           int nHeightEllipse
           );
       

        public FormResult(string content,  bool bOk = false)
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
           
            labelFormContent.Text = content;
            this.Height = 300;
          
            this.content = content;
           
            if (bOk)
            { panelTitleResult.BackColor = Color.Green;
                this.labelSmile.Text = "😎";
            }
            else
            { panelTitleResult.BackColor = Color.Red;
                this.labelSmile.Text = "🙁";
            }
           
        }

        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool buttonClicked = false;
        private string content;
      

        private void buttonResize_Click(object sender, EventArgs e)
        {
            buttonClicked = !buttonClicked;
            
            if(buttonClicked)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 704, 600, 20, 20));
                this.Height = 600;
                this.Width = 704;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 587, 300, 20, 20));
                this.Height = 300;
                this.Width = 384;
            }
        }

    }
}
