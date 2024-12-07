using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class LoginMessage : Message
    {
        public readonly string Username;
        public readonly string Password;
        public LoginMessage(string Username, string Password) : base(MessageType.Login)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public LoginMessage(JObject json) : base(TypeFromJson(json))
        {
            if (!json.ContainsKey("username") || !json.ContainsKey("password")) throw new ArgumentException("Invalid Login Message Data");
            if (json.Count != 3) throw new ArgumentException("Invalid key count in json");
            if (Type != MessageType.Login) throw new ArgumentException("Invalid type for LoginMessage");

            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentNullException("username in " + this.GetType());
            Password = json.GetValue("password")?.ToString() ?? throw new ArgumentNullException("password in " + this.GetType());
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();

            json.Add("type", Type.ToString());
            json.Add("username", Username);
            json.Add("password", Password);

            return json;
        }

    }
}
