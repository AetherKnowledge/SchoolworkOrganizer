using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class LoginMessage : Message
    {
        public readonly string Username;
        public readonly string Password;
        public LoginMessage(string Username, string Password)
        {
            this.Type = MessageType.Login;
            this.Username = Username;
            this.Password = Password;
        }

        public LoginMessage(JObject json)
        {
            if (!json.ContainsKey("type") || !json.ContainsKey("username") || !json.ContainsKey("password")) throw new ArgumentException("Invalid Login Message Data");
            if (json.Count != 3) throw new ArgumentException("Invalid key count in json");
            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentNullException("type in " + this.GetType()));
            if (type != MessageType.Login) throw new ArgumentException("Invalid type for LoginMessage");

            Type = type;
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
