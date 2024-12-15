using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.CustomControls
{
    public static class CustomControlUtilities
    {
        public static Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        internal static GraphicsPath CreateRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();
            return path;
        }
        internal static GraphicsPath CreateFRoundedPath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Top-left corner
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();
            return path;
        }

        internal static GraphicsPath CreateDropDownPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddLine(rect.Left - radius, rect.Top, rect.Right - radius, rect.Top); //Top-Left to Top-right
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // Top-right corner
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddLine(rect.Right - radius, rect.Bottom, rect.Left - radius, rect.Bottom);//Bottom-right to Bottom Left
            path.AddLine(rect.Left - radius, rect.Top, rect.Left - radius, rect.Bottom);//Bottom left to Top left
            path.CloseFigure();

            return path;
        }

        internal static void DrawRoundedRect(PaintEventArgs pevent, Rectangle rect, int radius, int borderThickness, Color btnColor, Color borderColor)
        {
            if (radius < 1) return;
            
            using (GraphicsPath path = CreateRoundedPath(rect, radius))
            {
                using (SolidBrush brush = new SolidBrush(btnColor))
                {
                    pevent.Graphics.FillPath(brush, path);
                }

                // Draw the border
                if (borderThickness > 0)
                {
                    using (Pen pen = new Pen(borderColor, borderThickness))
                    {
                        pevent.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        internal static void DrawRect(PaintEventArgs pevent, Rectangle rect, int borderThickness, Color btnColor, Color borderColor)
        {

            using (SolidBrush brush = new SolidBrush(btnColor))
            {
                pevent.Graphics.FillRectangle(brush, rect);
            }

            if (borderThickness > 0)
            {
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    pevent.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        internal static Color BlendColors(Color color1, Color color2, float progress)
        {
            int r = (int)(color1.R + (color2.R - color1.R) * progress);
            int g = (int)(color1.G + (color2.G - color1.G) * progress);
            int b = (int)(color1.B + (color2.B - color1.B) * progress);
            return Color.FromArgb(r, g, b);
        }


        public static Color Brighter(Color color, double factor = 0.7)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            int alpha = color.A;

            int i = (int)(1.0 / (1.0 - factor));
            if (r == 0 && g == 0 && b == 0)
            {
                return Color.FromArgb(alpha, i, i, i);
            }
            if (r > 0 && r < i) r = i;
            if (g > 0 && g < i) g = i;
            if (b > 0 && b < i) b = i;

            return Color.FromArgb(
                alpha,
                Math.Min((int)(r / factor), 255),
                Math.Min((int)(g / factor), 255),
                Math.Min((int)(b / factor), 255));
        }

        public static Color Darker(Color color, double factor = 0.7)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;
            int alpha = color.A;

            return Color.FromArgb(
                alpha,
                Math.Max((int)(r * factor), 0),
                Math.Max((int)(g * factor), 0),
                Math.Max((int)(b * factor), 0));
        }

        public static GraphicsPath CreateRectanglePath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }

        public static GraphicsPath CreateRectangleFPath(RectangleF rectF)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rectF);
            return path;
        }

        public static void AppendStyledText(RichTextBox richTextBox, string text, FontStyle style)
        {
            int start = richTextBox.TextLength;
            richTextBox.AppendText(text);
            richTextBox.Select(start, text.Length);
            richTextBox.SelectionFont = new Font(richTextBox.Font, style);
            richTextBox.Select(richTextBox.TextLength, 0); // Deselect text
        }


        private const int WS_VSCROLL = 0x00200000;
        private const int WS_HSCROLL = 0x00100000;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        public static void HidePanelScrollBars(Panel panel)
        {
            int style = GetWindowLong(panel.Handle, GWL_STYLE);
            style &= ~WS_HSCROLL; // Remove horizontal scrollbar
            style &= ~WS_VSCROLL; // Remove vertical scrollbar
            SetWindowLong(panel.Handle, GWL_STYLE, style);
        }
    }
}
