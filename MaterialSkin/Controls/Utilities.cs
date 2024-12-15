using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialSkin.Controls
{
    internal class Utilities
    {
        public static Color BlendColors(Color color1, Color color2, float progress)
        {
            int r = (int)(color1.R + (color2.R - color1.R) * progress);
            int g = (int)(color1.G + (color2.G - color1.G) * progress);
            int b = (int)(color1.B + (color2.B - color1.B) * progress);
            return Color.FromArgb(r, g, b);
        }
        public static Image ChangeColor(Image image, Color toColor, bool small = false)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap bufferedImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bufferedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(image, 0, 0, width, height);
            }

            BitmapData data = bufferedImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] pixels = new int[width * height];
            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            int toRGB = toColor.ToArgb();
            int toRed = (toRGB >> 16) & 0xFF;
            int toGreen = (toRGB >> 8) & 0xFF;
            int toBlue = toRGB & 0xFF;

            for (int i = 0; i < pixels.Length; i++)
            {
                int pixel = pixels[i];
                int alpha;

                if (small) alpha = ((pixel >> 24) & 0xFF) > 100 ? 255 : 0;
                else alpha = (pixel >> 24) & 0xFF;

                int red = (pixel >> 16) & 0xFF;
                int green = (pixel >> 8) & 0xFF;
                int blue = pixel & 0xFF;

                int newRed = (toRed * alpha + red * (255 - alpha)) / 255;
                int newGreen = (toGreen * alpha + green * (255 - alpha)) / 255;
                int newBlue = (toBlue * alpha + blue * (255 - alpha)) / 255;

                pixels[i] = (alpha << 24) | (newRed << 16) | (newGreen << 8) | newBlue;
            }

            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            bufferedImage.UnlockBits(data);

            return bufferedImage;
        }

        public static Image ChangeAlpha(Image image, int alpha)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap bufferedImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bufferedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(image, 0, 0, width, height);
            }

            BitmapData data = bufferedImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] pixels = new int[width * height];
            Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            for (int i = 0; i < pixels.Length; i++)
            {
                int pixel = pixels[i];
                int originalAlpha = (pixel >> 24) & 0xFF;
                int red = (pixel >> 16) & 0xFF;
                int green = (pixel >> 8) & 0xFF;
                int blue = pixel & 0xFF;

                // Adjust the alpha value while keeping the original colors
                int newAlpha = (originalAlpha * alpha) / 255;

                pixels[i] = (newAlpha << 24) | (red << 16) | (green << 8) | blue;
            }

            Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            bufferedImage.UnlockBits(data);

            return bufferedImage;
        }
    }
}
