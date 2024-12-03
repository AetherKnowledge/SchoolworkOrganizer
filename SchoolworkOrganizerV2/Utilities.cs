using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace SchoolworkOrganizer
{
    public class Utilities
    {
        internal readonly static string SqlConnectionString;
        private readonly static string settingsPath = "appsettings.json";

        static Utilities()
        {
            SqlConnectionString = GetSettingsFromJson("DefaultConnection");
        }

        private static string GetSettingsFromJson(string connectionName)
        {
            try
            {
                var json = File.ReadAllText(settingsPath);
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var root = doc.RootElement;
                    return root.GetProperty(connectionName).GetString() ?? throw new ArgumentNullException(nameof(connectionName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the connection string: {ex.Message}");
                return string.Empty;
            }
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

        public static void customButtonPaint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;

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

        public static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null) return null;
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public static void MakeFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void RenameFolder(string oldPath, string newPath)
        {
            try
            {
                if (!Directory.Exists(oldPath)) MakeFolder(newPath);
                Directory.Move(oldPath, newPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void DeleteFolder(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

        }

        public static void CopyFile(string sourcePath, string destinationPath, bool overwrite = false)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    if (!Directory.Exists(destinationPath)) MakeFolder(Path.GetDirectoryName(destinationPath));
                    File.Copy(sourcePath, destinationPath, overwrite);
                }
                else
                {
                    Console.WriteLine("Source file does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MoveFile(string sourcePath, string destinationPath)
        {
            try
            {
                if (File.Exists(sourcePath))
                {
                    if (!Directory.Exists(destinationPath)) MakeFolder(Path.GetDirectoryName(destinationPath));
                    File.Move(sourcePath, destinationPath);
                }
                else
                {
                    Console.WriteLine("Source file does not exist.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void OpenFile(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist.", "Error");
                return;
            }
            Process.Start(new ProcessStartInfo(Path.GetFullPath(path)) { UseShellExecute = true });
        }

    }
}
