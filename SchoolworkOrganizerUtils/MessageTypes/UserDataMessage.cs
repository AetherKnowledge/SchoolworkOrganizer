using Newtonsoft.Json.Linq;

namespace SchoolworkOrganizerUtils.MessageTypes
{
    public class UserDataMessage : Message
    {
        public readonly string Username;
        public readonly JObject Json;
        
        public UserDataMessage (string username, JObject json) : base(MessageType.FetchUserData)
        {
            json.Add("type", MessageType.FetchUserData.ToString());
            Username = username;
            Json = json;
        }

        public UserDataMessage(JObject json) : base (TypeFromJson(json))
        {
            this.Json = json;
            if (!Json.ContainsKey("username")) throw new ArgumentNullException("Invalid User Data Message Data");
            Username = Json.GetValue("username")?.ToString() ?? throw new ArgumentException("username in " + this.GetType());
        }

        public List<Subject> GetSubjects(User user)
        {
            List<Subject> subjects = new List<Subject>();
            if (user.Username != Username) throw new ArgumentNullException("Current User is null in " + this.GetType());

            foreach (var subjectJson in Json)
            {
                if (subjectJson.Value == null || subjectJson.Key == "username" || subjectJson.Key == "type") continue;

                string subjectName = subjectJson.Key;
                Subject subject = new Subject(user, subjectName);

                JToken activities = subjectJson.Value["Activities"] ?? new JObject();
                foreach (var activityJson in activities.Children<JProperty>())
                {
                    string name = activityJson.Name;
                    DateTime dueDate = activityJson.Value["DueDate"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(dueDate) + " is null in " + this.GetType());
                    string status = activityJson.Value["Status"]?.ToString() ?? throw new ArgumentNullException(nameof(status) + " is null in  in " + this.GetType());
                    string fileName = activityJson.Value["FileName"]?.ToString() ?? throw new ArgumentNullException(nameof(fileName) + " is null in  in " + this.GetType());
                    DateTime lastUpdated = activityJson.Value["LastUpdated"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(lastUpdated));
                    byte[] fileData = Convert.FromBase64String(activityJson.Value["FileData"]?.ToString() ?? throw new ArgumentNullException(nameof(fileData) + " is null in " + this.GetType()));

                    Activity activity = new Activity(name, subject, fileName, dueDate, status, lastUpdated, fileData);
                    subject.Activities.Add(activity);
                }

                JToken reviewers = subjectJson.Value["Reviewers"] ?? new JObject();
                foreach (var reviewerJson in reviewers.Children<JProperty>())
                {
                    string name = reviewerJson.Name;
                    string fileName = reviewerJson.Value["FileName"]?.ToString() ?? throw new ArgumentNullException(nameof(fileName) + " is null in " + this.GetType());
                    DateTime lastUpdated = reviewerJson.Value["LastUpdated"]?.ToObject<DateTime>() ?? throw new ArgumentNullException(nameof(lastUpdated) + " is null " + this.GetType());
                    byte[] fileData = Convert.FromBase64String(reviewerJson.Value["FileData"]?.ToString() ?? throw new ArgumentNullException(nameof(fileData) + " is null in " + this.GetType()));

                    Reviewer reviewer = new Reviewer(name, subject, fileName, lastUpdated, fileData);
                    subject.Reviewers.Add(reviewer);
                }

                subjects.Add(subject);
            }

            return subjects;
        }

        public override JObject ToJson()
        {
            return Json;
        }


    }
}
