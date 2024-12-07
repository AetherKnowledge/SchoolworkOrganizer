using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class SubjectMessage : Message
    {
        public readonly string SubjectName;
        public readonly string Username;
        public readonly string PreviousSubjectName;

        public SubjectMessage(MessageType type, string SubjectName, string Username, string PreviousSubjectName = "")
        {
            this.Type = type;
            this.SubjectName = SubjectName;
            this.Username = Username;
            this.PreviousSubjectName = PreviousSubjectName;
        }

        public SubjectMessage(JObject json)
        {
            if (!json.ContainsKey("type") || !json.ContainsKey("username") || !json.ContainsKey("subjectName")) throw new ArgumentNullException("Invalid Subject Message Data");
            if (json.Count > 4) throw new ArgumentException("Invalid key count in json");
            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentNullException("type in " + this.GetType()));
            if (type != MessageType.AddSubject && type != MessageType.DeleteSubject && type != MessageType.UpdateSubject) throw new ArgumentNullException("Invalid type for SubjectMessage");
            if (type == MessageType.UpdateSubject && !json.ContainsKey("previousSubjectName")) throw new ArgumentNullException("Invalid key count in json");

            Type = type;

            SubjectName = json.GetValue("subjectName")?.ToString() ?? throw new ArgumentNullException("subjectName in " + this.GetType());
            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentNullException("username in " + this.GetType());
            PreviousSubjectName = json.GetValue("previousSubjectName")?.ToString() ?? "";
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();
            json.Add("type", Type.ToString());
            json.Add("subjectName", SubjectName);
            json.Add("username", Username);
            json.Add("previousSubjectName", PreviousSubjectName);
            return json;
        }
    }
}
