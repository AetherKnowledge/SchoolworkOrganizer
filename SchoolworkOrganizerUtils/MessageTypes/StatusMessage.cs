using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class StatusMessage : Message
    {
        public readonly Status Status;

        public StatusMessage(Status status) : base(MessageType.Status)
        {
            this.Status = status;
        }

        public StatusMessage(JObject json) : base(TypeFromJson(json))
        {
            if (!json.ContainsKey("status")) throw new ArgumentNullException("Invalid Status Message Data");
            if (json.Count != 2) throw new ArgumentException("Invalid key count in json");

            if (Type != MessageType.Status) throw new ArgumentException("Invalid type for StatusMessage");
            Status = (Status)Enum.Parse(typeof(Status), json.GetValue("status")?.ToString() ?? throw new ArgumentNullException("status in " + this.GetType()));
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
