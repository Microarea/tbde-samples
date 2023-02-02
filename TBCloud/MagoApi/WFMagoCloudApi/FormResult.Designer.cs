
namespace WindowsFormsApp1
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
            this.buttonExitForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleResult = new System.Windows.Forms.Panel();
            this.labelSmile = new System.Windows.Forms.Label();
            this.labelTitleResult = new System.Windows.Forms.Label();
            this.buttonResize = new System.Windows.Forms.Button();
            this.panelContent.SuspendLayout();
            this.panelTitleResult.SuspendLayout();
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
            this.panelContent.Controls.Add(this.labelFormContent);
            this.panelContent.Name = "panelContent";
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
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelTitleResult
            // 
            this.panelTitleResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(159)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.panelTitleResult, "panelTitleResult");
            this.panelTitleResult.Controls.Add(this.labelSmile);
            this.panelTitleResult.Controls.Add(this.labelTitleResult);
            this.panelTitleResult.Controls.Add(this.buttonResize);
            this.panelTitleResult.Controls.Add(this.label1);
            this.panelTitleResult.Controls.Add(this.buttonExitForm);
            this.panelTitleResult.Name = "panelTitleResult";
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
            // FormResult
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panelTitleResult);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResult";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelTitleResult.ResumeLayout(false);
            this.panelTitleResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelFormContent;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonExitForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitleResult;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.Label labelTitleResult;
        private System.Windows.Forms.Label labelSmile;
    }
}