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
using MagoCloudApi;
using System.Drawing.Drawing2D;

namespace WindowsFormsResult
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
        

        public FormResult(string content,  bool bOk = false, bool bBlue = true, bool bHelp = false)
        {

            InitializeComponent();
           
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            labelFormContent.Text = content;
            richTextBoxCode.AppendText(content);
            richTextBoxCode.Dock = DockStyle.Fill;
            richTextBoxCode.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Both;
            richTextBoxCode.SelectionColor = Color.Red;
            richTextBoxCode.BackColor= Color.FromArgb(28, 28, 28);
            richTextBoxCode.Multiline = true;
            richTextBoxCode.WordWrap = false;
            richTextBoxCode.Padding = new Padding(15, 5, 55, 5); 

            this.content = content;
            if(bHelp)
            {
                
                this.btnCopyCode.Hide();
                panelTitleResult.BackColor = Color.LightSteelBlue;
                this.richTextBoxCode.Hide();
                this.pictureBox3Req.Hide();
                this.pictureBoxHea.Hide();
                this.buttonResize.Hide();
                this.labelSmile.Text = "?";
                this.labelTitleResult.Text = "Calls Info";
                this.buttonExitForm.BackColor = Color.LightSteelBlue;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 750, 300, 20, 20));
                this.Height = 280;
                this.Width = 750;
                return;
            }


            if (bOk)
            {
                this.btnCopyCode.Hide();
                panelTitleResult.BackColor = Color.Green;
                this.richTextBoxCode.Hide();
                this.pictureBox3Req.Hide();
                this.pictureBoxHea.Hide();
                this.labelTitleResult.Text = "Result";
                this.labelSmile.Text = "😎";
                this.buttonResize.BackColor = Color.Green;
                this.buttonExitForm.BackColor = Color.Green;
            }
            else
            {
                this.btnCopyCode.Hide();
                panelTitleResult.BackColor = Color.Red;
                this.richTextBoxCode.Hide();
                this.pictureBox3Req.Hide();
                this.pictureBoxHea.Hide();
                this.labelTitleResult.Text = "Result";
                this.labelSmile.Text = "🙁";
                this.buttonResize.BackColor = Color.Red;
                this.buttonExitForm.BackColor = Color.Red;
            }
            if (bBlue)
            {

                this.pictureBox3Req.Hide();/* = image;*/
                this.pictureBox3Req.Hide();/* = image;SizeMode = PictureBoxSizeMode.Zoom;*/
                panelTitleResult.BackColor = Color.FromArgb(28, 28, 28);
                this.panelContent.BackColor = Color.FromArgb(28, 28, 28);
                this.labelFormContent.Hide();
                this.richTextBoxCode.Font = new System.Drawing.Font("Consolas", 10);
                this.labelTitleResult.Text = "Question";
                this.labelSmile.Text = "🤔";
                this.buttonResize.BackColor = Color.FromArgb(28, 28, 28);
                this.buttonExitForm.BackColor = Color.FromArgb(28, 28, 28);

            }
        }

        //////////// customize draggable
        private void panelTitleResult_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void panelTitleResult_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X - 250;
                int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);
            }
        }
        private void panelTitleResult_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        
        private void buttonExitForm_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool buttonClicked = false;
        private string content;
        bool mousedown;

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBoxCode.Text);
            btnCopyCode.Text = "✔ copied";
            btnCopyCode.Font = new Font("Arial", 8, FontStyle.Bold);
            btnCopyCode.ForeColor = Color.FromArgb(65, 192, 146);
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            buttonClicked = !buttonClicked;
            
            if(buttonClicked)
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 704, 560, 20, 20));
                this.Height = 560;
                this.Width = 704;
            }
            else
            {
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 587, 300, 20, 20));
                this.Height = 300;
                this.Width = 384;
            }
        }

       
    }
}
