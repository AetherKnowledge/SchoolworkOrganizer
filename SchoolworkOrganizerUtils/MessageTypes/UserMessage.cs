using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class UserMessage : Message
    {
        public readonly string Username;
        public readonly string Password;
        public readonly string Email;
        public readonly byte[]? UserImageData;
        public readonly string PreviousUsername;

        public UserMessage(MessageType type, string Username, string Password, string Email, byte[] UserImageData, string previousUsername = "")
        {
            this.Type = type;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.UserImageData = UserImageData;
            PreviousUsername = previousUsername;
        }

        public UserMessage(MessageType type, User user, string previousUsername = "")
        {
            this.Type = type;
            this.Username = user.Username;
            this.Password = user.Password;
            this.Email = user.Email;
            this.UserImageData = user.UserImage != null ? Utilities.SKImageToByteArray(user.UserImage) : null;
            PreviousUsername = previousUsername;
        }

        public User GetUser()
        {
            return new User(Email, Username, Password, UserImageData != null ? Utilities.ByteArrayToSKImage(UserImageData) : null);
        }

        public UserMessage(JObject json)
        {
            if (!json.ContainsKey("type") || !json.ContainsKey("username") || !json.ContainsKey("password") || !json.ContainsKey("email") || !json.ContainsKey("userImageData")) throw new ArgumentNullException("Invalid User Message Data");
            if (json.Count != 6) throw new ArgumentException("Invalid key count in json");

            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type"));
            if (type != MessageType.FetchUser && type != MessageType.Register && type != MessageType.UpdateUser && type != MessageType.DeleteUser) throw new ArgumentException("Invalid type for UserMessage");
            if (type == MessageType.UpdateUser && !json.ContainsKey("previousUsername")) throw new ArgumentException("Invalid key count in json");

            Type = type;
            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentException("username");
            Password = json.GetValue("password")?.ToString() ?? throw new ArgumentException("password");
            Email = json.GetValue("email")?.ToString() ?? throw new ArgumentException("email");
            UserImageData = json.GetValue("userImageData")?.ToObject<byte[]>() ?? throw new ArgumentException("userImageData");
            PreviousUsername = json.GetValue("previousUsername")?.ToString() ?? "";
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();

            json.Add("type", Type.ToString());
            json.Add("username", Username);
            json.Add("password", Password);
            json.Add("email", Email);
            json.Add("userImageData", UserImageData != null ? Convert.ToBase64String(UserImageData) : null);
            json.Add("previousUsername", PreviousUsername);

            return json;
        }
    }
}
