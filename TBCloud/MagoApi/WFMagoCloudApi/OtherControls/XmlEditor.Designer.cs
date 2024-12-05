using TbApiTester.Libraries;
using System.ComponentModel;
using System.Windows.Markup;


namespace TbApiTester.OtherControls
{
    partial class XmlEditor
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

         

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlEditor));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsText = new System.Windows.Forms.ToolStripTextBox();
            this.tsNextFind = new System.Windows.Forms.ToolStripButton();
            this.tsPreviousFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tslblMatched = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.optionsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.optionsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(418, 163);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(418, 187);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Enabled = false;
            
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(30, 21);
            this.toolStripLabel1.Text = "Find";
            this.toolStripLabel1.ToolTipText = "Find (Ctrl+F)";
            // 
            // tsText
            // 
            this.tsText.Name = "tsText";
            this.tsText.Size = new System.Drawing.Size(200, 24);
            this.tsText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TsText_KeyDown);
            this.tsText.TextChanged += new System.EventHandler(this.TsText_TextChanged);
            // 
            // tsNextFind
            // 
            this.tsNextFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNextFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNextFind.Name = "tsNextFind";
            this.tsNextFind.Size = new System.Drawing.Size(23, 21);
            this.tsNextFind.Text = ">>";
            this.tsNextFind.ToolTipText = "Next (F3)";
            this.tsNextFind.Click += new System.EventHandler(this.TsNextFind_Click);
            // 
            // tsPreviousFind
            // 
            this.tsPreviousFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPreviousFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPreviousFind.Name = "tsPreviousFind";
            this.tsPreviousFind.Size = new System.Drawing.Size(23, 21);
            this.tsPreviousFind.Text = "<<";
            this.tsPreviousFind.ToolTipText = "Previous (Shift + F3)";
            this.tsPreviousFind.Click += new System.EventHandler(this.TsPreviousFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(20, 25);
            // 
            // tsClose
            // 
            this.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.White;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(23, 21);
            this.tsClose.Text = "X";
            this.tsClose.ToolTipText = "Close";
            this.tsClose.Click += new System.EventHandler(this.TsClose_Click);
            // 
            // tslblMatched
            // 
            this.tslblMatched.Name = "tslblMatched";
            this.tslblMatched.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 21);
            this.toolStripButton1.Text = "Save xml as..";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // optionsContextMenu
            this.optionsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSelectAll,
            this.toolStripCopy,
            this.toolStripPaste});
            this.optionsContextMenu.Name = "optionsContextMenu";
            this.optionsContextMenu.Size = new System.Drawing.Size(165, 70);
            this.optionsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OptionsContextMenu_Opening);
            // 
            // toolStripSelectAll
            // 
            this.toolStripSelectAll.Name = "toolStripSelectAll";
            this.toolStripSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.toolStripSelectAll.Size = new System.Drawing.Size(164, 22);
            this.toolStripSelectAll.Text = "Select All";
            this.toolStripSelectAll.Click += new System.EventHandler(this.ToolStripSelectAll_Click);
            // 
            // toolStripCopy
            // 
            this.toolStripCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCopy.Image")));
            this.toolStripCopy.Name = "toolStripCopy";
            this.toolStripCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripCopy.Size = new System.Drawing.Size(164, 22);
            this.toolStripCopy.Text = "Copy";
            this.toolStripCopy.Click += new System.EventHandler(this.ToolStripCopy_Click);
            //
            //toolStripPaste
            //
            this.toolStripPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPaste.Image")));
            this.toolStripPaste.Name = "toolStripPaste";
            this.toolStripPaste.ShortcutKeyDisplayString = "Ctrl+V";
            this.toolStripPaste.Size = new System.Drawing.Size(164, 22);
            this.toolStripPaste.Text = "Paste";
            this.toolStripPaste.Click += new System.EventHandler(this.ToolStripPaste_Click);
            // 
            // XmlEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Name = "XmlEditor";
            this.Size = new System.Drawing.Size(750, 300);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.optionsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsText;
        private System.Windows.Forms.ToolStripButton tsNextFind;
        private System.Windows.Forms.ToolStripButton tsPreviousFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ContextMenuStrip optionsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripPaste;
		private System.Windows.Forms.ToolStripLabel tslblMatched;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}
