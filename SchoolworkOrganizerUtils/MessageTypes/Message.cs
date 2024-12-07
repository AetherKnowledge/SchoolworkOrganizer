using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public abstract class Message
    {
        public readonly MessageType Type;

        protected Message(MessageType type)
        {
            this.Type = type;
        }

        public static Message? Parse(string rawData)
        {
            JObject json = JObject.Parse(rawData);
            MessageType type = TypeFromJson(json);
            switch (type)
            {
                case MessageType.Login:
                    return new LoginMessage(json);
                case MessageType.Logout:
                    throw new NotImplementedException("logout message not implemented");
                case MessageType.Register:
                    return new UserMessage(json);
                case MessageType.AddSubject:
                    return new SubjectMessage(json);
                case MessageType.AddActivity:
                    return new ActivityMessage(json);
                case MessageType.AddReviewer:
                    return new ReviewerMessage(json);
                case MessageType.UpdateUser:
                    return new UserMessage(json);
                case MessageType.UpdateSubject:
                    return new SubjectMessage(json);
                case MessageType.UpdateActivity:
                    return new ActivityMessage(json);
                case MessageType.UpdateReviewer:
                    return new ReviewerMessage(json);
                case MessageType.DeleteUser:
                    return new ReviewerMessage(json);
                case MessageType.DeleteSubject:
                    return new SubjectMessage(json);
                case MessageType.DeleteActivity:
                    return new ActivityMessage(json);
                case MessageType.DeleteReviewer:
                    return new ReviewerMessage(json);
                case MessageType.FetchUser:
                    return new UserMessage(json);
                case MessageType.FetchUserData:
                    return new UserDataMessage(json);
                case MessageType.Status:
                    return new StatusMessage(json);
                default:
                    throw new ArgumentException("Invalid MessageType");
            }
        }

        protected static MessageType TypeFromJson(JObject json)
        {
            if (!json.ContainsKey("type")) throw new ArgumentException("Type of recieved message is null");
            return (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type of recieved json is null"));
        }

        public abstract JObject ToJson();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(ToJson(), Formatting.None);
        }

        public string ToJsonNoData()
        {
            JObject json = ToJson();
            if (json.ContainsKey("password")) json["password"] = "Hidden";
            if (json.ContainsKey("userImageData")) json["userImageData"] = json["userImageData"] != null ? "Has Image" : "No Image";

            if (this.Type is MessageType.FetchUserData)
            {
                JObject userData = new JObject();
                userData.Add("type", json.GetValue("type"));
                userData.Add("username", json.GetValue("username"));
                return JsonConvert.SerializeObject(userData, Formatting.Indented);
            }

            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        protected static void AddToJson(JObject to, JObject from)
        {
            foreach (var item in from)
            {
                to[item.Key] = item.Value?.DeepClone();
            }
        }
    }
}
