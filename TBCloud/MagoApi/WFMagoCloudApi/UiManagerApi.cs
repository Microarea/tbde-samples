using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MagoCloudApi
{
    public class UiManagerApi
    {
        private Control.ControlCollection controls;

        public UiManagerApi() { }

        public void SetControls(Control.ControlCollection controls)
        {
            this.controls = controls;
        }

        public void ReplaceColor(Color oldColor, Color newColor)
        {
            if (controls == null)
                throw new InvalidOperationException("Controls have not been set.");

            ReplaceColorRecursive(this.controls, oldColor, newColor);
        }

        private void ReplaceColorRecursive(Control.ControlCollection controls, Color oldColor, Color newColor)
        {
            foreach (Control control in controls)
            {
                if (control.BackColor == oldColor)
                {
                    control.BackColor = newColor;
                }

                if (control.HasChildren)
                {
                    ReplaceColorRecursive(control.Controls, oldColor, newColor);
                }
            }
        }
    }

    public class CbxUi
    {
        private ComboBox cbxApplication;
        private ComboBox cbxModule;
        private ComboBox cbxDocReport;
        private ComboBox cbxProfile;

        public CbxUi(ComboBox cbxApplication, ComboBox cbxModule, ComboBox cbxDocReport, ComboBox cbxProfile)
        {
            this.cbxApplication = cbxApplication;
            this.cbxModule = cbxModule;
            this.cbxDocReport = cbxDocReport;
            this.cbxProfile = cbxProfile;
        }

        public void BtnTbfs_MouseHover(object sender, EventArgs e)
        {
            SetComboBoxForeColor(Color.FromArgb(232, 159, 0));
        }

        public void BtnTbfs_MouseLeave(object sender, EventArgs e)
        {
            SetComboBoxForeColor(Color.White);
        }

        private void SetComboBoxForeColor(Color color)
        {
            cbxApplication.ForeColor = color;
            cbxModule.ForeColor = color;
            cbxDocReport.ForeColor = color;
            cbxProfile.ForeColor = color;
        }
    }
}
