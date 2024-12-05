using MySqlConnector;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class User
    {
        public static User? currentUser = null;
        private static readonly string UserDataPath = "UserData.data";
        public string UserPath;
        public string Email;
        private string _username = "";
        public Image? WinformImage { get; private set; }
        private SKImage? _userImage;

        [JsonPropertyName("username")]
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                string newPath = "Data/" + value;
                if (UserPath != null) Utilities.RenameFolder(UserPath, newPath);
                UserPath = newPath;
            }
        }
        [JsonPropertyName("password")]
        public string Password;
        private byte[]? UserImageData;
        public List<Subject> Subjects = new List<Subject>();

      


        public SKImage? UserImage
        {
            get { return _userImage; }
            set
            {
                _userImage = value;

                if (!OperatingSystem.IsWindows()) return;
                WinformImage = value != null ? Utilities.ConvertToImage(value) : null;
            }
        }

        

        public User(string Email, string Username, string Password, SKImage? UserImage)
        {
            this.Email = Email;
            this.Username = Username;
            this.Password = Password;
            this.UserImage = UserImage;
            UserPath = "Data/" + Username;
        }

        public void RemoveSubject(Subject selectedSubject)
        {
            selectedSubject.DeleteFolder();
            selectedSubject.DeleteFromDatabase();
            Subjects.Remove(selectedSubject);
        }

        public void CheckForFiles()
        {
            foreach (Subject subject in Subjects)
            {
                subject.CheckForFiles();
            }
        }

        public static void Logout()
        {
            currentUser = null;
        }
        public JObject ToJson()
        {
            JObject json = new JObject();
            json.Add("username", Username);
            json.Add("password", Password);
            json.Add("email", Email);
            json.Add("imageData", UserImage != null ? Convert.ToBase64String(Utilities.SKImageToByteArray(UserImage)) : null);
            return json;
        }

        public static User ParseJson(JObject json)
        {
            string username = json["username"]?.ToString() ?? throw new ArgumentNullException(nameof(username));
            string password = json["password"]?.ToString() ?? throw new ArgumentNullException(nameof(password));
            string email = json["email"]?.ToString() ?? throw new ArgumentNullException(nameof(email));
            string imageDataBase64 = json["imageData"]?.ToString() ?? string.Empty;
            byte[] imageData = Convert.FromBase64String(imageDataBase64);
            SKImage? userImage;

            if (imageData != null) userImage = (Utilities.ByteArrayToSKImage(imageData)) ?? null;
            else userImage = null;

            return new User(email, username, password, userImage);
        }
    }
}
