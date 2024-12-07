using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class UserMessage : Message
    {
        public readonly string Username;
        public readonly string Password;
        public readonly string Email;
        public readonly byte[]? UserImageData;
        public readonly string PreviousUsername;

        public UserMessage(MessageType type, string Username, string Password, string Email, byte[]? UserImageData, string previousUsername = "") : base(type)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.UserImageData = UserImageData;
            PreviousUsername = previousUsername;
        }

        public UserMessage(MessageType type, User user, string previousUsername = "") : base(type)
        {
            this.Username = user.Username;
            this.Password = user.Password;
            this.Email = user.Email;
            this.UserImageData = user.UserImage != null ? Utilities.SKImageToByteArray(user.UserImage) : null;
            PreviousUsername = previousUsername;
        }

        public User GetUser()
        {
            return new User(this);
        }

        public UserMessage(JObject json) : base(TypeFromJson(json))
        {
            if (!json.ContainsKey("username") || !json.ContainsKey("password") || !json.ContainsKey("email") || !json.ContainsKey("userImageData")) throw new ArgumentNullException("Invalid User Message Data");
            if (json.Count != 6) throw new ArgumentException("Invalid key count in json");

            if (Type != MessageType.FetchUser && Type != MessageType.Register && Type != MessageType.UpdateUser && Type != MessageType.DeleteUser) throw new ArgumentException("Invalid type for UserMessage");
            if (Type == MessageType.UpdateUser && !json.ContainsKey("previousUsername")) throw new ArgumentException("Invalid key count in json");

            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentNullException("usernamel in " + this.GetType());
            Password = json.GetValue("password")?.ToString() ?? throw new ArgumentNullException("password in " + this.GetType());
            Email = json.GetValue("email")?.ToString() ?? throw new ArgumentNullException("email in " + this.GetType());
            UserImageData = json.GetValue("userImageData")?.ToObject<byte[]>() ?? Array.Empty<byte>();
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
