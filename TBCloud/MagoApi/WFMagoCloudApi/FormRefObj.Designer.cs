using TbApiTester;

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
            this.xmlEditorWpfRef = new  XmlEditor();
            this.ContainerBtnUpload = new MspzComponent.OrangePanel();
            this.btnUploadXmlRefObj = new System.Windows.Forms.Button();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.btnModifyXml = new System.Windows.Forms.Button();
            this.xmlEditorResult = new  XmlEditor();
            this.panelTitleResult = new System.Windows.Forms.Panel();
            this.labelTitleResult = new System.Windows.Forms.Label();
            this.panelTitleResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // xmlEditorWpfRef
            // 
            this.xmlEditorWpfRef.Location = new System.Drawing.Point(0, 0);
            this.xmlEditorWpfRef.Name = "xmlEditorWpfRef";
            this.xmlEditorWpfRef.Size = new System.Drawing.Size(750, 300);
            this.xmlEditorWpfRef.TabIndex = 0;
            this.xmlEditorWpfRef.TextContent = "";
            // 
            // ContainerBtnUpload
            // 
            this.ContainerBtnUpload.AutoSize = true;
            this.ContainerBtnUpload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContainerBtnUpload.BackColor = System.Drawing.Color.AliceBlue;
            this.ContainerBtnUpload.Dock = System.Windows.Forms.DockStyle.Top;
            this.ContainerBtnUpload.Location = new System.Drawing.Point(0, 0);
            this.ContainerBtnUpload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.ContainerBtnUpload.Name = "ContainerBtnUpload";
            this.ContainerBtnUpload.Size = new System.Drawing.Size(600, 0);
            this.ContainerBtnUpload.TabIndex = 1;
            // 
            // btnUploadXmlRefObj
            // 
            this.btnUploadXmlRefObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnUploadXmlRefObj.FlatAppearance.BorderSize = 0;
            this.btnUploadXmlRefObj.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnUploadXmlRefObj.ForeColor = System.Drawing.Color.White;
            this.btnUploadXmlRefObj.Location = new System.Drawing.Point(268, 3);
            this.btnUploadXmlRefObj.Margin = new System.Windows.Forms.Padding(0);
            this.btnUploadXmlRefObj.Name = "btnUploadXmlRefObj";
            this.btnUploadXmlRefObj.Size = new System.Drawing.Size(80, 49);
            this.btnUploadXmlRefObj.TabIndex = 2;
            this.btnUploadXmlRefObj.Text = "Upload";
            this.btnUploadXmlRefObj.UseVisualStyleBackColor = false;
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnSaveXml.FlatAppearance.BorderSize = 0;
            this.btnSaveXml.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveXml.ForeColor = System.Drawing.Color.White;
            this.btnSaveXml.Location = new System.Drawing.Point(144, 3);
            this.btnSaveXml.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(80, 49);
            this.btnSaveXml.TabIndex = 1;
            this.btnSaveXml.Text = "Save";
            this.btnSaveXml.UseVisualStyleBackColor = false;
            // 
            // btnModifyXml
            // 
            this.btnModifyXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.btnModifyXml.FlatAppearance.BorderSize = 0;
            this.btnModifyXml.Font = new System.Drawing.Font("Century Gothic", 8.75F, System.Drawing.FontStyle.Bold);
            this.btnModifyXml.ForeColor = System.Drawing.Color.White;
            this.btnModifyXml.Location = new System.Drawing.Point(392, 3);
            this.btnModifyXml.Margin = new System.Windows.Forms.Padding(0);
            this.btnModifyXml.Name = "btnModifyXml";
            this.btnModifyXml.Size = new System.Drawing.Size(80, 49);
            this.btnModifyXml.TabIndex = 0;
            this.btnModifyXml.Text = "Modify";
            this.btnModifyXml.UseVisualStyleBackColor = false;
            // 
            // xmlEditorResult
            // 
            this.xmlEditorResult.BackColor = System.Drawing.Color.AliceBlue;
            this.xmlEditorResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlEditorResult.Location = new System.Drawing.Point(0, 0);
            this.xmlEditorResult.Name = "xmlEditorResult";
            this.xmlEditorResult.Padding = new System.Windows.Forms.Padding(20, 70, 0, 0);
            this.xmlEditorResult.Size = new System.Drawing.Size(600, 366);
            this.xmlEditorResult.TabIndex = 2;
            this.xmlEditorResult.TextContent = "444";
            // 
            // panelTitleResult
            // 
            this.panelTitleResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(118)))), ((int)(((byte)(186)))));
            this.panelTitleResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelTitleResult.Controls.Add(this.btnModifyXml);
            this.panelTitleResult.Controls.Add(this.btnSaveXml);
            this.panelTitleResult.Controls.Add(this.btnUploadXmlRefObj);
            this.panelTitleResult.Controls.Add(this.labelTitleResult);
            this.panelTitleResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleResult.Location = new System.Drawing.Point(0, 0);
            this.panelTitleResult.Name = "panelTitleResult";
            this.panelTitleResult.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelTitleResult.Size = new System.Drawing.Size(600, 54);
            this.panelTitleResult.TabIndex = 3;
            // 
            // labelTitleResult
            // 
            this.labelTitleResult.AutoSize = true;
            this.labelTitleResult.Font = new System.Drawing.Font("Century Gothic", 15.2F, System.Drawing.FontStyle.Bold);
            this.labelTitleResult.ForeColor = System.Drawing.Color.White;
            this.labelTitleResult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTitleResult.Location = new System.Drawing.Point(12, 14);
            this.labelTitleResult.Name = "labelTitleResult";
            this.labelTitleResult.Size = new System.Drawing.Size(70, 25);
            this.labelTitleResult.TabIndex = 9;
            this.labelTitleResult.Text = "Result";
            this.labelTitleResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormRefObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panelTitleResult);
            this.Controls.Add(this.ContainerBtnUpload);
            this.Controls.Add(this.xmlEditorResult);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRefObj";
            this.Text = "FormRefObj";
            this.panelTitleResult.ResumeLayout(false);
            this.panelTitleResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private XmlEditor xmlEditorWpfRef;
        private TbApiTester TbApiTester;
        private MspzComponent.OrangePanel ContainerBtnUpload;
        private System.Windows.Forms.Button btnUploadXmlRefObj;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.Button btnModifyXml;
        private XmlEditor xmlEditorResult;
        private System.Windows.Forms.Panel panelTitleResult;
        private System.Windows.Forms.Label labelTitleResult;
    }
}