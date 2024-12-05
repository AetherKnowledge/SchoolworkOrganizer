using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class StatusMessage : Message
    {
        public readonly Status Status;

        public StatusMessage(Status status)
        {
            Type = MessageType.Status;
            this.Status = status;
        }

        public StatusMessage(JObject json)
        {
            if (!json.ContainsKey("status")) throw new ArgumentNullException("Invalid Status Message Data");
            if (json.Count != 2) throw new ArgumentException("Invalid key count in json");

            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type"));
            this.Type = type;

            if (type != MessageType.Status) throw new ArgumentException("Invalid type for StatusMessage");
            Status = (Status)Enum.Parse(typeof(Status), json.GetValue("status")?.ToString() ?? throw new ArgumentException("status"));
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();
            json.Add("type", Type.ToString());
            json.Add("status", Status.ToString());
            return json;
        }
    }
}
