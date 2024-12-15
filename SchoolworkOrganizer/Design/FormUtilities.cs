using MaterialSkin.Controls;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer.Design
{
    internal class FormUtilities
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

        public static void InitializeTextBoxWithPlaceholder(TextBox textBox)
        {
            string placeholder = textBox.Text;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };

        }

        public static void InitializeTextBoxWithPlaceholder(MaterialTextBox2 textBox)
        {
            string placeholder = textBox.Text;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };

        }

        public static void ChangeButtonColors(Button button)
        {
            //normal
            button.MouseLeave += (sender, e) => { button.BackColor = Color.FromArgb(52, 63, 82); };
            button.MouseUp += (sender, e) => { button.BackColor = Color.FromArgb(52, 63, 82); };

            //hover
            button.MouseEnter += (sender, e) => { button.BackColor = Color.FromArgb(43, 49, 65); };

            //press
            button.MouseDown += (sender, e) => { button.BackColor = Color.FromArgb(34, 40, 54); };

            button.EnabledChanged += (sender, e) =>
            {
                if (!button.Enabled)
                {

                }
            };

        }

        public static void customButtonPaint(object? sender, PaintEventArgs e)
        {
            if (sender == null) return;
            Button btn = (Button) sender;

            if (!btn.Enabled)
            {
                Color disabledColor = Color.Gray;
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, disabledColor,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            if (btn.Enabled)
            {

            }
        }

        public static SKImage ConvertToSKImage(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                ms.Seek(0, SeekOrigin.Begin);
                using (var skBitmap = SKBitmap.Decode(ms))
                {
                    return SKImage.FromBitmap(skBitmap);
                }
            }
        }



    }
}
