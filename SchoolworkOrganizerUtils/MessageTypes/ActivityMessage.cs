using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class ActivityMessage : Message
    {
        public readonly string Username;
        public readonly string PreviousName;
        public readonly string Name;
        public readonly string Subject;
        public readonly string FileName;
        public readonly DateTime DueDate;
        public readonly string Status;
        public readonly DateTime LastUpdated;
        public readonly bool WithFile;
        public readonly byte[]? FileData;

        public ActivityMessage(MessageType type, Activity activity, string currentName = "", bool withFile = false)
        {
            Type = type;
            Username = activity.Subject.User.Username;
            Name = activity.Name;
            Subject = activity.Subject.SubjectName;
            FileName = activity.FileName;
            DueDate = activity.DueDate;
            Status = activity.Status;
            PreviousName = currentName == "" ? activity.Name : currentName;
            WithFile = withFile;
            if (withFile)
            {
                if (!File.Exists(activity.FilePath)) throw new ArgumentException("File does not exist");
                LastUpdated = File.GetLastWriteTime(activity.FilePath);
                FileData = File.ReadAllBytes(activity.FilePath);
            }
        }

        public ActivityMessage(JObject json)
        {
            if (!json.ContainsKey("type") || 
                !json.ContainsKey("username") || 
                !json.ContainsKey("name") || 
                !json.ContainsKey("subject") || 
                !json.ContainsKey("fileName") || 
                !json.ContainsKey("dueDate") || 
                !json.ContainsKey("status") ||
                !json.ContainsKey("withFile") ||
                !json.ContainsKey("fileData") ||
                !json.ContainsKey("lastUpdated"))
                throw new ArgumentException("Invalid Activity Message Data");
            if (json.Count != 11) throw new ArgumentException("Invalid key count in json");

            Type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentNullException("type in " + this.GetType()));
            if (Type != MessageType.AddActivity && Type != MessageType.UpdateActivity && Type != MessageType.DeleteActivity && Type != MessageType.DeleteActivity) throw new ArgumentException("Invalid type for ActivityMessage");
            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentNullException("username in " + this.GetType());
            Name = json.GetValue("name")?.ToString() ?? throw new ArgumentNullException("name in " + this.GetType());
            Subject = json.GetValue("subject")?.ToString() ?? throw new ArgumentNullException("subject in " + this.GetType());
            FileName = json.GetValue("fileName")?.ToString() ?? throw new ArgumentNullException("fileName in " + this.GetType());
            DueDate = DateTime.Parse(json.GetValue("dueDate")?.ToString() ?? throw new ArgumentNullException("dueDate in " + this.GetType()));
            Status = json.GetValue("status")?.ToString() ?? throw new ArgumentNullException("status in " + this.GetType());
            PreviousName = json.GetValue("previousName")?.ToString() ?? throw new ArgumentNullException("previousName in " + this.GetType());
            WithFile = json.GetValue("withFile")?.ToString() == "True";
            FileData = Convert.FromBase64String(json.GetValue("fileData")?.ToString() ?? string.Empty);
            LastUpdated = DateTime.Parse(json.GetValue("lastUpdated")?.ToString() ?? throw new ArgumentNullException("lastUpdated in " + this.GetType()));
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();
            json.Add("type", Type.ToString());
            json.Add("username", Username);
            json.Add("name", Name);
            json.Add("subject", Subject);
            json.Add("fileName", FileName);
            json.Add("dueDate", DueDate.ToString());
            json.Add("status", Status);
            json.Add("previousName", PreviousName);
            json.Add("withFile", WithFile);
            json.Add("fileData", Convert.ToBase64String(FileData ?? new byte[0]));
            json.Add("lastUpdated", LastUpdated.ToString());
            return json;
        }

        public Activity GetReviewer()
        {
            return new Activity(this);
        }

    }
}
