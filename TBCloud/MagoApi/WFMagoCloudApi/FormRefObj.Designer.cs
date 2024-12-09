namespace TbApiTester
{
    partial class FormRefObj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.xmlEditorWpfRef = new XmlEditorWpf();
            this.ContainerBtnUpload = new MspzComponent.OrangePanel();
            this.btnUploadXmlRefObj = new System.Windows.Forms.Button();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.btnModifyXml = new System.Windows.Forms.Button();
            this.ContainerBtnUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(600, 366);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.xmlEditorWpfRef;
            // 
            // ContainerBtnUpload
            // 
            this.ContainerBtnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ContainerBtnUpload.BackColor = System.Drawing.Color.AliceBlue;
            this.ContainerBtnUpload.Controls.Add(this.btnUploadXmlRefObj);
            this.ContainerBtnUpload.Controls.Add(this.btnSaveXml);
            this.ContainerBtnUpload.Controls.Add(this.btnModifyXml);
            this.ContainerBtnUpload.Location = new System.Drawing.Point(511, 11);
            this.ContainerBtnUpload.Margin = new System.Windows.Forms.Padding(2);
            this.ContainerBtnUpload.Name = "ContainerBtnUpload";
            this.ContainerBtnUpload.Size = new System.Drawing.Size(64, 153);
            this.ContainerBtnUpload.TabIndex = 1;
            // 
            // btnUploadXmlRefObj
            // 
            this.btnUploadXmlRefObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnUploadXmlRefObj.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnUploadXmlRefObj.ForeColor = System.Drawing.Color.White;
            this.btnUploadXmlRefObj.Location = new System.Drawing.Point(-8, 104);
            this.btnUploadXmlRefObj.Margin = new System.Windows.Forms.Padding(2);
            this.btnUploadXmlRefObj.Name = "btnUploadXmlRefObj";
            this.btnUploadXmlRefObj.Size = new System.Drawing.Size(80, 54);
            this.btnUploadXmlRefObj.TabIndex = 2;
            this.btnUploadXmlRefObj.Text = "Upload";
            this.btnUploadXmlRefObj.UseVisualStyleBackColor = false;
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnSaveXml.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveXml.ForeColor = System.Drawing.Color.White;
            this.btnSaveXml.Location = new System.Drawing.Point(-8, 51);
            this.btnSaveXml.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(80, 49);
            this.btnSaveXml.TabIndex = 1;
            this.btnSaveXml.Text = "Save";
            this.btnSaveXml.UseVisualStyleBackColor = false;
            // 
            // btnModifyXml
            // 
            this.btnModifyXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnModifyXml.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnModifyXml.ForeColor = System.Drawing.Color.White;
            this.btnModifyXml.Location = new System.Drawing.Point(-8, -6);
            this.btnModifyXml.Margin = new System.Windows.Forms.Padding(2);
            this.btnModifyXml.Name = "btnModifyXml";
            this.btnModifyXml.Size = new System.Drawing.Size(80, 52);
            this.btnModifyXml.TabIndex = 0;
            this.btnModifyXml.Text = "Modify";
            this.btnModifyXml.UseVisualStyleBackColor = false;
            this.btnModifyXml.Click += new System.EventHandler(this.btnModifyXml_Click);
            // 
            // FormRefObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.ContainerBtnUpload);
            this.Controls.Add(this.elementHost1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRefObj";
            this.Text = "FormRefObj";
            this.ContainerBtnUpload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private XmlEditorWpf xmlEditorWpfRef;
        private MspzComponent.OrangePanel ContainerBtnUpload;
        private System.Windows.Forms.Button btnUploadXmlRefObj;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.Button btnModifyXml;
    }
}