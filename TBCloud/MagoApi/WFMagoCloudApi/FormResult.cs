 using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TbApiTester.Properties;

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


        public FormResult(string content, bool bOk = false, bool bBlue = false, bool bHelp = false, bool showImage = false)
        {

            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.btnUploadXml.Hide();
            this.richXmlTextBox.Hide();
            labelFormContent.Text = content;
            richXmlTextBox.AppendText(content);
            this.pictureBoxToken.Visible = showImage;
            this.pictureBoxToken.Image = Resources.ImgTokenExt;




            this.content = content;
            if (bHelp)
            {

                this.btnUploadXml.Hide();
                panelTitleResult.BackColor = Color.LightSteelBlue;
                this.buttonResize.Hide();
                this.labelSmile.Text = "?";
                this.labelTitleResult.Text = "Calls Info";
                this.buttonExitForm.BackColor = Color.LightSteelBlue;
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 800, 400, 20, 20));
                this.Height = 400;
                this.Width = 800;
                return;
            }


            if (bOk)
            {
                panelTitleResult.BackColor = Color.Green;
                this.richXmlTextBox.BackColor = Color.White;
                this.labelTitleResult.Text = "Result";
                this.labelSmile.Text = "😎";
                this.buttonResize.BackColor = Color.Green;
                this.buttonExitForm.BackColor = Color.Green;
            }
            else
            {
                panelTitleResult.BackColor = Color.Red;
                this.labelTitleResult.Text = "Result";
                this.labelSmile.Text = "🙁";
                this.buttonResize.BackColor = Color.Red;
                this.buttonExitForm.BackColor = Color.Red;
            }
            if (bBlue)
            {
                this.richXmlTextBox.Visible = true;
                this.richXmlTextBox.Dock = DockStyle.Fill;
                panelTitleResult.BackColor = Color.FromArgb(28, 28, 28);
                this.labelFormContent.Hide();
                this.labelTitleResult.Text = "Useful";
                this.labelSmile.Text = "🤔";
                this.buttonResize.BackColor = Color.FromArgb(28, 28, 28);
                this.buttonExitForm.BackColor = Color.FromArgb(28, 28, 28);
                this.panelContent.Padding = new System.Windows.Forms.Padding(10, 70, 0, 0);

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

        private string content;
        bool mousedown;

        private void btnUploadXml_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richXmlTextBox.Text);
            btnUploadXml.Text = "✔ copied";
            btnUploadXml.Font = new Font("Arial", 8, FontStyle.Bold);
            btnUploadXml.ForeColor = Color.FromArgb(65, 192, 146);
        }
        private bool buttonClicked = false;
        private void buttonResize_Click(object sender, EventArgs e)
        {
            buttonClicked = !buttonClicked;

            float scaleFactor = this.DeviceDpi / 96f; // 96 DPI è lo standard

            if (buttonClicked)
            {
                this.Width = (int)(1000 * scaleFactor);
                this.Height = (int)(560 * scaleFactor);
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, (int)(20 * scaleFactor), (int)(20 * scaleFactor)));
            }
            else
            {
                this.Width = (int)(584 * scaleFactor);
                this.Height = (int)(300 * scaleFactor);
                this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, (int)(20 * scaleFactor), (int)(20 * scaleFactor)));
            }
        }

    }
}
