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
        

        public FormResult(string content,  bool bOk = false, bool bBlue = false, bool bHelp = false)
        {

            InitializeComponent();
            
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.btnUploadXml.Hide();
            this.richXmlTextBox.Hide();
            labelFormContent.Text = content;
            //this.xmlEditorWpf1.textEditor.AppendText(content);
            richXmlTextBox.AppendText(content);
            
            //xmlViewer = new XmlEditor
            //{
            //    ContextMenuStrip = optionsContextMenu,
            //    Dock = DockStyle.Fill
            //};

            //tabPage = new TabPage
            //{
            //    Text = "Output"
            //};
            //tabResults.TabPages.Add(tabPage);
            //UpdateButtons();


            this.content = content;
            if(bHelp)
            {
                this.btnUploadXml.Hide();
                panelTitleResult.BackColor = Color.LightSteelBlue;
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
                this.btnUploadXml.Visible = true;
                this.richXmlTextBox.Visible = true;
                panelTitleResult.BackColor = Color.FromArgb(28, 28, 28);
                this.labelFormContent.Hide();
                this.richXmlTextBox.ForeColor = Color.Blue;
               
                this.labelTitleResult.Text = "Xml";
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

            if (buttonClicked)
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
