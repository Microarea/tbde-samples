using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MspzComponent
{
    public class RoundedPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Graphics g = e.Graphics)
            {
                using (Brush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(255, 255, 255), Color.FromArgb(22, 118, 186), 25f))
                {
                    g.FillPath(brush, GetRoundedRectanglePath(this.ClientRectangle, 15));
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // top left arc  
            path.AddArc(arcRect, 180, 90);

            // top right arc  
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // bottom right arc  
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // bottom left arc 
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
    }

    public class OrangePanel : Panel
    {
        public static object Control { get; internal set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Graphics g = e.Graphics)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(232, 159, 0)))
                {
                    g.FillPath(brush, GetRoundedRectanglePath(this.ClientRectangle, 15));
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // top left arc  
            path.AddArc(arcRect, 180, 90);

            // top right arc  
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // bottom right arc  
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // bottom left arc 
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }
          
    }


}
