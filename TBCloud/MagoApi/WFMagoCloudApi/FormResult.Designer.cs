
namespace WindowsFormsResult
{
    public partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResult));
            labelFormContent = new Label();
            panelContent = new Panel();
            pictureBoxToken = new PictureBox();
            pictureBoxRequest = new PictureBox();
            pictureBox2 = new PictureBox();
            richXmlTextBox = new RichTextBox();
            pictureBox1 = new PictureBox();
            textBoxCode = new TextBox();
            buttonExitForm = new Button();
            panelTitleResult = new Panel();
            btnUploadXml = new Button();
            labelSmile = new Label();
            labelTitleResult = new Label();
            buttonResize = new Button();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxToken).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRequest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleResult.SuspendLayout();
            SuspendLayout();
            // 
            // labelFormContent
            // 
            resources.ApplyResources(labelFormContent, "labelFormContent");
            labelFormContent.Name = "labelFormContent";
            labelFormContent.UseCompatibleTextRendering = true;
            // 
            // panelContent
            // 
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Controls.Add(pictureBoxToken);
            panelContent.Controls.Add(pictureBoxRequest);
            panelContent.Controls.Add(pictureBox2);
            panelContent.Controls.Add(richXmlTextBox);
            panelContent.Controls.Add(pictureBox1);
            panelContent.Controls.Add(textBoxCode);
            panelContent.Controls.Add(labelFormContent);
            panelContent.Name = "panelContent";
            // 
            // pictureBoxToken
            // 
            resources.ApplyResources(pictureBoxToken, "pictureBoxToken");
            pictureBoxToken.Name = "pictureBoxToken";
            pictureBoxToken.TabStop = false;
            // 
            // pictureBoxRequest
            // 
            resources.ApplyResources(pictureBoxRequest, "pictureBoxRequest");
            pictureBoxRequest.Name = "pictureBoxRequest";
            pictureBoxRequest.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // richXmlTextBox
            // 
            richXmlTextBox.BorderStyle = BorderStyle.None;
            resources.ApplyResources(richXmlTextBox, "richXmlTextBox");
            richXmlTextBox.ForeColor = Color.FromArgb(28, 28, 28);
            richXmlTextBox.Name = "richXmlTextBox";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // textBoxCode
            // 
            resources.ApplyResources(textBoxCode, "textBoxCode");
            textBoxCode.Name = "textBoxCode";
            // 
            // buttonExitForm
            // 
            buttonExitForm.BackColor = Color.Transparent;
            resources.ApplyResources(buttonExitForm, "buttonExitForm");
            buttonExitForm.FlatAppearance.BorderSize = 0;
            buttonExitForm.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            buttonExitForm.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            buttonExitForm.ForeColor = SystemColors.ControlLightLight;
            buttonExitForm.Name = "buttonExitForm";
            buttonExitForm.UseVisualStyleBackColor = false;
            buttonExitForm.Click += buttonExitForm_Click;
            // 
            // panelTitleResult
            // 
            panelTitleResult.BackColor = Color.FromArgb(232, 159, 0);
            resources.ApplyResources(panelTitleResult, "panelTitleResult");
            panelTitleResult.Controls.Add(btnUploadXml);
            panelTitleResult.Controls.Add(labelSmile);
            panelTitleResult.Controls.Add(labelTitleResult);
            panelTitleResult.Controls.Add(buttonResize);
            panelTitleResult.Controls.Add(buttonExitForm);
            panelTitleResult.Name = "panelTitleResult";
            panelTitleResult.MouseDown += panelTitleResult_MouseDown;
            panelTitleResult.MouseMove += panelTitleResult_MouseMove;
            panelTitleResult.MouseUp += panelTitleResult_MouseUp;
            // 
            // btnUploadXml
            // 
            btnUploadXml.BackColor = Color.FromArgb(28, 28, 28);
            resources.ApplyResources(btnUploadXml, "btnUploadXml");
            btnUploadXml.FlatAppearance.BorderSize = 0;
            btnUploadXml.FlatAppearance.MouseDownBackColor = Color.FromArgb(65, 192, 146);
            btnUploadXml.ForeColor = SystemColors.ControlLightLight;
            btnUploadXml.Name = "btnUploadXml";
            btnUploadXml.UseVisualStyleBackColor = false;
            btnUploadXml.Click += btnUploadXml_Click;
            // 
            // labelSmile
            // 
            resources.ApplyResources(labelSmile, "labelSmile");
            labelSmile.ForeColor = Color.White;
            labelSmile.Name = "labelSmile";
            // 
            // labelTitleResult
            // 
            resources.ApplyResources(labelTitleResult, "labelTitleResult");
            labelTitleResult.ForeColor = Color.White;
            labelTitleResult.Name = "labelTitleResult";
            // 
            // buttonResize
            // 
            buttonResize.BackColor = Color.FromArgb(232, 159, 0);
            resources.ApplyResources(buttonResize, "buttonResize");
            buttonResize.Cursor = Cursors.SizeNESW;
            buttonResize.FlatAppearance.BorderSize = 0;
            buttonResize.ForeColor = SystemColors.ControlLightLight;
            buttonResize.Name = "buttonResize";
            buttonResize.UseVisualStyleBackColor = false;
            buttonResize.Click += buttonResize_Click;
            // 
            // FormResult
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(panelTitleResult);
            Controls.Add(panelContent);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormResult";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxToken).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRequest).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleResult.ResumeLayout(false);
            panelTitleResult.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFormContent;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonExitForm;
        private System.Windows.Forms.Panel panelTitleResult;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Label labelTitleResult;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richXmlTextBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxRequest;
        private System.Windows.Forms.Button btnUploadXml;
        private System.Windows.Forms.Label labelSmile;
        private PictureBox pictureBoxToken;
        private TextBox textBox1;
    }
}