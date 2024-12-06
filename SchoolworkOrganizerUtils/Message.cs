using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils.MessageTypes;
using System.Text.Json.Nodes;

namespace SchoolworkOrganizerUtils
{
    public abstract class Message
    {
        public MessageType Type { get; internal set; }

        public static Message? Parse(string rawData)
        {
            JObject json = JObject.Parse(rawData);
            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type"));
            switch (type)
            {
                case MessageType.Login:
                    return new LoginMessage(json);
                case MessageType.Logout:
                    return null;
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


        public abstract JObject ToJson();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(ToJson(), Formatting.None);
        }

        public string ToJsonNoData()
        {
            JObject json = ToJson();
            json["userImageData"] = json["userImageData"] != null ? "Has Image" : "No Image";
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
