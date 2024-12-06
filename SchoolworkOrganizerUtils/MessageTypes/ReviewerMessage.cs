using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class ReviewerMessage : Message
    {
        public readonly string Username;
        public readonly string PreviousName;
        public readonly string Name;
        public readonly string Subject;
        public readonly string FileName;
        public readonly DateTime LastUpdated;
        public readonly bool WithFile;
        public readonly byte[]? FileData;
        public ReviewerMessage(MessageType type, Reviewer reviewer, string currentName = "", bool withFile = false)
        {
            this.Type = type;
            Username = reviewer.Subject.User.Username;
            Name = reviewer.Name;
            Subject = reviewer.Subject.SubjectName;
            FileName = reviewer.FileName;
            PreviousName = currentName == "" ? reviewer.Name : currentName;
            WithFile = withFile;
            if (withFile)
            {
                if (!File.Exists(reviewer.FilePath)) throw new ArgumentException("File does not exist");
                LastUpdated = File.GetLastWriteTime(reviewer.FilePath);
                FileData = File.ReadAllBytes(reviewer.FilePath);
            }
        }

        public ReviewerMessage(JObject json)
        {
            if (!json.ContainsKey("type") ||
                !json.ContainsKey("username") ||
                !json.ContainsKey("name") || 
                !json.ContainsKey("subject") || 
                !json.ContainsKey("fileName") || 
                !json.ContainsKey("withFile") || 
                !json.ContainsKey("fileData") || 
                !json.ContainsKey("lastUpdated")) throw new ArgumentNullException("Invalid Reviewer Message Data");

            if (json.Count != 9) throw new ArgumentException("Invalid key count in json");
            Type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type"));
            if (Type != MessageType.AddReviewer && Type != MessageType.UpdateReviewer && Type != MessageType.DeleteReviewer && Type != MessageType.DeleteReviewer) throw new ArgumentException("Invalid type for ReviewerMessage");

            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentException("username");
            Name = json.GetValue("name")?.ToString() ?? throw new ArgumentException("name");
            Subject = json.GetValue("subject")?.ToString() ?? throw new ArgumentException("subject");
            FileName = json.GetValue("fileName")?.ToString() ?? throw new ArgumentException("fileName");
            PreviousName = json.GetValue("previousName")?.ToString() ?? throw new ArgumentException("previousName");
            WithFile = json.GetValue("withFile")?.ToString() == "True";
            FileData = Convert.FromBase64String(json.GetValue("fileData")?.ToString() ?? string.Empty);
            LastUpdated = DateTime.Parse(json.GetValue("lastUpdated")?.ToString() ?? throw new ArgumentException("lastUpdated"));
        }

        public override JObject ToJson()
        {
            JObject json = new JObject();
            json.Add("type", Type.ToString());
            json.Add("username", Username);
            json.Add("name", Name);
            json.Add("subject", Subject);
            json.Add("fileName", FileName);
            json.Add("previousName", PreviousName);
            json.Add("withFile", WithFile);
            json.Add("fileData", Convert.ToBase64String(FileData ?? new byte[0]));
            json.Add("lastUpdated", LastUpdated.ToString());
            return json;
        }

        public Reviewer GetReviewer()
        {
            return new Reviewer(this);
        }
    }
}
