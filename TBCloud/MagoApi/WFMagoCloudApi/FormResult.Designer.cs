
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
            this.labelFormContent = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.richXmlTextBox = new System.Windows.Forms.RichTextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonExitForm = new System.Windows.Forms.Button();
            this.panelTitleResult = new System.Windows.Forms.Panel();
            this.btnUploadXml = new System.Windows.Forms.Button();
            this.labelSmile = new System.Windows.Forms.Label();
            this.labelTitleResult = new System.Windows.Forms.Label();
            this.buttonResize = new System.Windows.Forms.Button();
            this.pictureBoxRequest = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxToken = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            this.panelTitleResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToken)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFormContent
            // 
            resources.ApplyResources(this.labelFormContent, "labelFormContent");
            this.labelFormContent.Name = "labelFormContent";
            this.labelFormContent.UseCompatibleTextRendering = true;
            // 
            // panelContent
            // 
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Controls.Add(this.pictureBoxToken);
            this.panelContent.Controls.Add(this.pictureBoxRequest);
            this.panelContent.Controls.Add(this.pictureBox2);
            this.panelContent.Controls.Add(this.richXmlTextBox);
            this.panelContent.Controls.Add(this.pictureBox1);
            this.panelContent.Controls.Add(this.textBoxCode);
            this.panelContent.Controls.Add(this.labelFormContent);
            this.panelContent.Name = "panelContent";
            // 
            // richXmlTextBox
            // 
            this.richXmlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richXmlTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.richXmlTextBox, "richXmlTextBox");
            this.richXmlTextBox.Name = "richXmlTextBox";
            // 
            // textBoxCode
            // 
            resources.ApplyResources(this.textBoxCode, "textBoxCode");
            this.textBoxCode.Name = "textBoxCode";
            // 
            // buttonExitForm
            // 
            this.buttonExitForm.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.buttonExitForm, "buttonExitForm");
            this.buttonExitForm.FlatAppearance.BorderSize = 0;
            this.buttonExitForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExitForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExitForm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonExitForm.Name = "buttonExitForm";
            this.buttonExitForm.UseVisualStyleBackColor = false;
            this.buttonExitForm.Click += new System.EventHandler(this.buttonExitForm_Click);
            // 
            // panelTitleResult
            // 
            this.panelTitleResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(159)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.panelTitleResult, "panelTitleResult");
            this.panelTitleResult.Controls.Add(this.btnUploadXml);
            this.panelTitleResult.Controls.Add(this.labelSmile);
            this.panelTitleResult.Controls.Add(this.labelTitleResult);
            this.panelTitleResult.Controls.Add(this.buttonResize);
            this.panelTitleResult.Controls.Add(this.buttonExitForm);
            this.panelTitleResult.Name = "panelTitleResult";
            this.panelTitleResult.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleResult_MouseDown);
            this.panelTitleResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleResult_MouseMove);
            this.panelTitleResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleResult_MouseUp);
            // 
            // btnUploadXml
            // 
            this.btnUploadXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            resources.ApplyResources(this.btnUploadXml, "btnUploadXml");
            this.btnUploadXml.FlatAppearance.BorderSize = 0;
            this.btnUploadXml.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(192)))), ((int)(((byte)(146)))));
            this.btnUploadXml.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUploadXml.Name = "btnUploadXml";
            this.btnUploadXml.UseVisualStyleBackColor = false;
            this.btnUploadXml.Click += new System.EventHandler(this.btnUploadXml_Click);
            // 
            // labelSmile
            // 
            resources.ApplyResources(this.labelSmile, "labelSmile");
            this.labelSmile.ForeColor = System.Drawing.Color.White;
            this.labelSmile.Name = "labelSmile";
            // 
            // labelTitleResult
            // 
            resources.ApplyResources(this.labelTitleResult, "labelTitleResult");
            this.labelTitleResult.ForeColor = System.Drawing.Color.White;
            this.labelTitleResult.Name = "labelTitleResult";
            // 
            // buttonResize
            // 
            this.buttonResize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(159)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.buttonResize, "buttonResize");
            this.buttonResize.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.buttonResize.FlatAppearance.BorderSize = 0;
            this.buttonResize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonResize.Name = "buttonResize";
            this.buttonResize.UseVisualStyleBackColor = false;
            this.buttonResize.Click += new System.EventHandler(this.buttonResize_Click);
            // 
            // pictureBoxRequest
            // 
            resources.ApplyResources(this.pictureBoxRequest, "pictureBoxRequest");
            this.pictureBoxRequest.Name = "pictureBoxRequest";
            this.pictureBoxRequest.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxToken
            // 
            resources.ApplyResources(this.pictureBoxToken, "pictureBoxToken");
            this.pictureBoxToken.Name = "pictureBoxToken";
            this.pictureBoxToken.TabStop = false;
            // 
            // FormResult
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panelTitleResult);
            this.Controls.Add(this.panelContent);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResult";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelTitleResult.ResumeLayout(false);
            this.panelTitleResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxToken)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pictureBoxToken;
    }
}