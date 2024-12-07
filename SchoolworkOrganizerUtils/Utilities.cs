using SkiaSharp;
using System.Diagnostics;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.Versioning;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolworkOrganizerUtils
{
    public class Utilities
    {
        public readonly static string SqlConnectionString;
        public readonly static string WebHost;
        public readonly static string WebSocket;
        private readonly static string connectionsPath = "connection.json";
        private readonly static string settingsPath = "settings.json";
        public const int BufferSize = 1024 * 1024 * 5;
        public static bool Debug;
        public static bool ShowDataStream;

        static Utilities()
        {
            string? debugString = Environment.GetEnvironmentVariable("DebugSWO");
            if (debugString == "true" || debugString == "false") Debug = debugString == "true";
            else Debug = GetSettingsFromJson("Debug", settingsPath) == "true";

            string? showDataStreamString = Environment.GetEnvironmentVariable("ShowDataStreamSWO");
            if (showDataStreamString == "true" || showDataStreamString == "false") ShowDataStream = showDataStreamString == "true";
            else ShowDataStream = GetSettingsFromJson("ShowDataStream", settingsPath) == "true";

            SqlConnectionString = GetSettingsFromJson("SqlConnectionString", connectionsPath);
            WebHost = GetSettingsFromJson("WebHost", connectionsPath);
            WebSocket = GetSettingsFromJson("WebSocket", connectionsPath);
        }

        private static string GetSettingsFromJson(string settingsName, string jsonPath)
        {
            try
            {
                var json = File.ReadAllText(connectionsPath);
                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    var root = doc.RootElement;
                    return root.GetProperty(settingsName).GetString() ?? throw new ArgumentNullException(nameof(settingsName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the connection string: {ex.Message} {settingsName}");
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
            try
            {
                if (byteArray == null || byteArray.Length == 0)
                {
                    Console.WriteLine("Byte array is null or empty.");
                    return null;
                }

                return await Task.Run(() =>
                {
                    using (var ms = new MemoryStream(byteArray))
                    {
                        var skImage = SKImage.FromEncodedData(ms);
                        if (skImage == null)
                        {
                            Console.WriteLine("Failed to create SKImage from byte array.");
                        }
                        return skImage;
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in ByteArrayToSKImageAsync: {e.Message}");
                Console.WriteLine(e.StackTrace);
                return null;
            }
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
                Console.WriteLine(e.StackTrace); 
                Console.WriteLine(e.Message);
                return null;
            }
        }

        [SupportedOSPlatform("windows")]
        public static byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
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
                if (Directory.Exists(newPath)) Directory.Delete(newPath, true);
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
