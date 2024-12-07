using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils.MessageTypes;
using SkiaSharp;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Timers;
using System.Xml.Linq;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class User
    {

        public string UserPath;
        public string Email;
        private string _username = "";
        public Image? WinformImage { get; private set; }
        private SKImage? _userImage;
        public Client? client { get; internal set; }

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

        public User(UserMessage message)
        {
            this.Email = message.Email;
            this.Username = message.Username;
            this.Password = message.Password;
            this.UserImage = message.UserImageData != null ? Utilities.ByteArrayToSKImage(message.UserImageData) : null;
            UserPath = "Data/" + Username;
        }

        public async Task<bool> UpdateUser(User user)
        {
            if (client == null) return false;
            bool success = await client.UpdateUser(user, Username);
            if (success)
            {
                Email = user.Email;
                Password = user.Password;
                UserImage = user.UserImage;
                Username = user.Username;
            }
            return success;
        }
    }
}
