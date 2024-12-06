using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class UserDataMessage : Message
    {
        public readonly string Username;
        public readonly List<Subject> Subjects = new List<Subject>();
        public readonly JObject Json;

        public UserDataMessage (string username, JObject json)
        {
            Username = username;
            Json = json;
        }

        public UserDataMessage(JObject json)
        {
            if (!json.ContainsKey("username") || !json.ContainsKey("type")) throw new ArgumentNullException("Invalid User Data Message Data");
            MessageType type = (MessageType)Enum.Parse(typeof(MessageType), json.GetValue("type")?.ToString() ?? throw new ArgumentException("type"));
            if (type != MessageType.FetchUserData) throw new ArgumentException("Invalid type for UserDataMessage");
            this.Type = type;

            Username = json.GetValue("username")?.ToString() ?? throw new ArgumentException("username");

            if (User.currentUser == null || User.currentUser.Username != Username) throw new ArgumentNullException("Current User is null");

            foreach (var subjectJson in json)
            {
                if (subjectJson.Value == null || subjectJson.Key == "username" || subjectJson.Key == "type") continue;

                string subjectName = subjectJson.Key;
                Subject subject = new Subject(User.currentUser, subjectName);

                JToken activities = subjectJson.Value["Activities"] ?? new JObject();
                foreach (var activityJson in activities.Children<JProperty>())
                {
                    string name = activityJson.Name;
                    DateTime dueDate = activityJson.Value["DueDate"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(dueDate));
                    string status = activityJson.Value["Status"]?.ToString() ?? throw new ArgumentNullException(nameof(status));
                    string fileName = activityJson.Value["FileName"]?.ToString() ?? throw new ArgumentNullException(nameof(fileName));
                    DateTime lastUpdated = activityJson.Value["LastUpdated"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(lastUpdated));
                    byte[] fileData = Convert.FromBase64String(activityJson.Value["FileData"]?.ToString() ?? throw new ArgumentNullException(nameof(fileData)));

                    Activity activity = new Activity(name, subject, fileName, dueDate, status, lastUpdated, fileData);
                    subject.Activities.Add(activity);
                }

                JToken reviewers = subjectJson.Value["Reviewers"] ?? new JObject();
                foreach (var reviewerJson in reviewers.Children<JProperty>())
                {
                    string name = reviewerJson.Name;
                    string fileName = reviewerJson.Value["FileName"]?.ToString() ?? throw new ArgumentNullException(nameof(fileName));
                    DateTime lastUpdated = reviewerJson.Value["LastUpdated"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(lastUpdated));
                    byte[] fileData = Convert.FromBase64String(reviewerJson.Value["FileData"]?.ToString() ?? throw new ArgumentNullException(nameof(fileData)));

                    Reviewer reviewer = new Reviewer(name, subject, fileName, lastUpdated, fileData);
                    subject.Reviewers.Add(reviewer);
                }

                Subjects.Add(subject);
            }
            this.Json = json;
        }

        public override JObject ToJson()
        {
            return Json;
        }


    }
}
