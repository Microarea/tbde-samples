namespace MagoCloudApi
{
    partial class StartMagoApi
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
            this.panelDevEnv = new MspzComponent.OrangePanel();
            this.btnDevEnv = new System.Windows.Forms.PictureBox();
            this.panelCloud = new MspzComponent.OrangePanel();
            this.btnCloud = new System.Windows.Forms.PictureBox();
            this.panelWeb = new MspzComponent.OrangePanel();
            this.btnWeb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDevEnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDevEnv)).BeginInit();
            this.panelCloud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloud)).BeginInit();
            this.panelWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWeb)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDevEnv
            // 
            this.panelDevEnv.BackColor = System.Drawing.Color.White;
            this.panelDevEnv.Controls.Add(this.btnDevEnv);
            this.panelDevEnv.Location = new System.Drawing.Point(367, 70);
            this.panelDevEnv.Name = "panelDevEnv";
            this.panelDevEnv.Size = new System.Drawing.Size(164, 91);
            this.panelDevEnv.TabIndex = 0;
            // 
            // btnDevEnv
            // 
            this.btnDevEnv.BackColor = System.Drawing.Color.White;
            this.btnDevEnv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDevEnv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevEnv.Image = global::MagoCloudApi.Properties.Resources.DevEnvBtn;
            this.btnDevEnv.Location = new System.Drawing.Point(3, 3);
            this.btnDevEnv.Name = "btnDevEnv";
            this.btnDevEnv.Size = new System.Drawing.Size(158, 88);
            this.btnDevEnv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDevEnv.TabIndex = 3;
            this.btnDevEnv.TabStop = false;
            this.btnDevEnv.Click += new System.EventHandler(this.btnDevEnv_Click);
            // 
            // panelCloud
            // 
            this.panelCloud.BackColor = System.Drawing.Color.White;
            this.panelCloud.Controls.Add(this.btnCloud);
            this.panelCloud.Location = new System.Drawing.Point(10, 70);
            this.panelCloud.Name = "panelCloud";
            this.panelCloud.Size = new System.Drawing.Size(164, 91);
            this.panelCloud.TabIndex = 1;
            // 
            // btnCloud
            // 
            this.btnCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloud.Image = global::MagoCloudApi.Properties.Resources.MagoCloud;
            this.btnCloud.Location = new System.Drawing.Point(2, 3);
            this.btnCloud.Name = "btnCloud";
            this.btnCloud.Size = new System.Drawing.Size(159, 85);
            this.btnCloud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCloud.TabIndex = 4;
            this.btnCloud.TabStop = false;
            this.btnCloud.Click += new System.EventHandler(this.btnCloud_Click);
            // 
            // panelWeb
            // 
            this.panelWeb.BackColor = System.Drawing.Color.White;
            this.panelWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWeb.Controls.Add(this.btnWeb);
            this.panelWeb.Location = new System.Drawing.Point(187, 70);
            this.panelWeb.Name = "panelWeb";
            this.panelWeb.Size = new System.Drawing.Size(164, 91);
            this.panelWeb.TabIndex = 2;
            // 
            // btnWeb
            // 
            this.btnWeb.BackColor = System.Drawing.Color.White;
            this.btnWeb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeb.Image = global::MagoCloudApi.Properties.Resources.MagoWeb;
            this.btnWeb.Location = new System.Drawing.Point(8, 3);
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Padding = new System.Windows.Forms.Padding(5);
            this.btnWeb.Size = new System.Drawing.Size(145, 83);
            this.btnWeb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnWeb.TabIndex = 4;
            this.btnWeb.TabStop = false;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose the environment to use with the Mago platform APIs";
            // 
            // StartMagoApi
            // 
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(540, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelWeb);
            this.Controls.Add(this.panelCloud);
            this.Controls.Add(this.panelDevEnv);
            this.Name = "StartMagoApi";
            this.Text = "PlatformMagoApi";
            this.panelDevEnv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDevEnv)).EndInit();
            this.panelCloud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCloud)).EndInit();
            this.panelWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnWeb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
       
        private MspzComponent.OrangePanel orangePanel3;
        private MspzComponent.OrangePanel panelDevEnv;
        private MspzComponent.OrangePanel panelCloud;
        private MspzComponent.OrangePanel panelWeb;
        private System.Windows.Forms.PictureBox btnDevEnv;
        private System.Windows.Forms.PictureBox btnCloud;
        private System.Windows.Forms.PictureBox btnWeb;
        private System.Windows.Forms.Label label1;
    }
}