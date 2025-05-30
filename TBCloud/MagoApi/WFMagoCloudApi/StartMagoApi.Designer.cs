namespace TbApiTester
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
            label1 = new Label();
            panelWeb = new MspzComponent.OrangePanel();
            btnWeb = new PictureBox();
            panelCloud = new MspzComponent.OrangePanel();
            btnCloud = new PictureBox();
            panelDevEnv = new MspzComponent.OrangePanel();
            btnDevEnv = new PictureBox();
            panelWeb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnWeb).BeginInit();
            panelCloud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCloud).BeginInit();
            panelDevEnv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnDevEnv).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 179);
            label1.Name = "label1";
            label1.Size = new Size(350, 16);
            label1.TabIndex = 3;
            label1.Text = "Choose the environment to use with the Mago platform APIs";
            // 
            // panelWeb
            // 
            panelWeb.BackColor = Color.White;
            panelWeb.BorderStyle = BorderStyle.FixedSingle;
            panelWeb.Controls.Add(btnWeb);
            panelWeb.Location = new Point(9, 58);
            panelWeb.Name = "panelWeb";
            panelWeb.Size = new Size(164, 91);
            panelWeb.TabIndex = 2;
            // 
            // btnWeb
            // 
            btnWeb.BackColor = Color.White;
            btnWeb.BackgroundImageLayout = ImageLayout.Center;
            btnWeb.Cursor = Cursors.Hand;
            btnWeb.Image = Properties.Resources.MagoWeb;
            btnWeb.Location = new Point(5, 6);
            btnWeb.Name = "btnWeb";
            btnWeb.Padding = new Padding(5, 5, 5, 30);
            btnWeb.Size = new Size(151, 84);
            btnWeb.SizeMode = PictureBoxSizeMode.StretchImage;
            btnWeb.TabIndex = 4;
            btnWeb.TabStop = false;
            btnWeb.Click += btnWeb_Click;
            // 
            // panelCloud
            // 
            panelCloud.BackColor = Color.White;
            panelCloud.Controls.Add(btnCloud);
            panelCloud.Location = new Point(189, 58);
            panelCloud.Name = "panelCloud";
            panelCloud.Size = new Size(164, 91);
            panelCloud.TabIndex = 1;
            // 
            // btnCloud
            // 
            btnCloud.BackgroundImageLayout = ImageLayout.Zoom;
            btnCloud.Cursor = Cursors.Hand;
            btnCloud.Image = Properties.Resources.MagoCloud;
            btnCloud.Location = new Point(2, 3);
            btnCloud.Name = "btnCloud";
            btnCloud.Size = new Size(159, 85);
            btnCloud.SizeMode = PictureBoxSizeMode.Zoom;
            btnCloud.TabIndex = 4;
            btnCloud.TabStop = false;
            btnCloud.Click += btnCloud_Click;
            // 
            // panelDevEnv
            // 
            panelDevEnv.BackColor = Color.White;
            panelDevEnv.Controls.Add(btnDevEnv);
            panelDevEnv.Location = new Point(367, 58);
            panelDevEnv.Name = "panelDevEnv";
            panelDevEnv.Size = new Size(164, 91);
            panelDevEnv.TabIndex = 0;
            // 
            // btnDevEnv
            // 
            btnDevEnv.BackColor = Color.White;
            btnDevEnv.BackgroundImageLayout = ImageLayout.Zoom;
            btnDevEnv.Cursor = Cursors.Hand;
            btnDevEnv.Image = Properties.Resources.DevEnvBtn;
            btnDevEnv.Location = new Point(3, 3);
            btnDevEnv.Name = "btnDevEnv";
            btnDevEnv.Size = new Size(158, 88);
            btnDevEnv.SizeMode = PictureBoxSizeMode.Zoom;
            btnDevEnv.TabIndex = 3;
            btnDevEnv.TabStop = false;
            btnDevEnv.Click += btnDevEnv_Click;
            // 
            // StartMagoApi
            // 
            BackColor = Color.SteelBlue;
            ClientSize = new Size(540, 255);
            Controls.Add(label1);
            Controls.Add(panelWeb);
            Controls.Add(panelCloud);
            Controls.Add(panelDevEnv);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "StartMagoApi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TbApi-Tester";
            panelWeb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnWeb).EndInit();
            panelCloud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnCloud).EndInit();
            panelDevEnv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnDevEnv).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MspzComponent.OrangePanel panelDevEnv;
        private MspzComponent.OrangePanel panelCloud;
        private System.Windows.Forms.PictureBox btnDevEnv;
        private System.Windows.Forms.PictureBox btnCloud;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnWeb;
        private MspzComponent.OrangePanel panelWeb;
    }
}