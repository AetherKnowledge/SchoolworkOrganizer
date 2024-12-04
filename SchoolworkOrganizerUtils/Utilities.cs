using SkiaSharp;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Versioning;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolworkOrganizerUtils
{
    public class Utilities
    {
        public readonly static string SqlConnectionString;
        private readonly static string settingsPath = "appsettings.json";
        public const int BufferSize = 1024 * 1024 * 5;

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

        [SupportedOSPlatform("windows")]
        public static System.Drawing.Image? ConvertToImage(SKImage skImage)
        {
            using (var data = skImage.Encode())
            using (var ms = new MemoryStream(data.ToArray()))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        [SupportedOSPlatform("windows")]
        public static SKImage ConvertToSKImage(System.Drawing.Image image)
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

        public static byte[] SKImageToByteArray(SKImage image)
        {
            using (var ms = new MemoryStream())
            {
                using (var skImage = SKImage.FromBitmap(SKBitmap.FromImage(image)))
                using (var data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                {
                    data.SaveTo(ms);
                }
                return ms.ToArray();
            }
        }

        public static async Task<byte[]> SKImageToByteArrayAsync(SKImage image)
        {
            return await Task.Run(() =>
            {
                using (var ms = new MemoryStream())
                {
                    using (var skImage = SKImage.FromBitmap(SKBitmap.FromImage(image)))
                    using (var data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                    {
                        data.SaveTo(ms);
                    }
                    return ms.ToArray();
                }
            });
        }

        public static async Task<SKImage?> ByteArrayToSKImageAsync(byte[] byteArray)
        {
            if (byteArray == null) return null;
            return await Task.Run(() =>
            {
                using (var ms = new MemoryStream(byteArray))
                {
                    return SKImage.FromEncodedData(ms);
                }
            });
        }

        public static SKImage? ByteArrayToSKImage(byte[] byteArray)
        {
            try
            {
                if (byteArray == null) return null;
                using (var ms = new MemoryStream(byteArray))
                {
                    SKImage image = SKImage.FromEncodedData(ms);
                    return image;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
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
                Console.WriteLine("File does not exist.", "Error");
                return;
            }
            Process.Start(new ProcessStartInfo(Path.GetFullPath(path)) { UseShellExecute = true });
        }


    }
}
