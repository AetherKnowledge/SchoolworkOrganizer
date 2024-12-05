using MySqlConnector;
using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Subject
    {
        private string _subjectName;
        private string previousName = "";
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                if (previousName == "") previousName = value;
                else if (previousName != _subjectName) previousName = _subjectName;

                _subjectName = value;
                string newPath = "Data/" + User.Username + "/" + value;
                if (FolderPath != null) Utilities.RenameFolder(FolderPath, newPath);
                FolderPath = newPath;
            }
        }

        public User User;
        public string FolderPath;
        public List<Reviewer> Reviewers = new List<Reviewer>();
        public List<Activity> Activities = new List<Activity>();

        public Subject(User user, string subjectName)
        {
            User = user;
            _subjectName = subjectName;
            SubjectName = subjectName;
            FolderPath = "Data/" + User.Username + "/" + SubjectName;
        }

        public void DeleteFolder()
        {
            Utilities.DeleteFolder(FolderPath);
        }

        public void RemoveReviewer(Reviewer selectedReviewer)
        {
            selectedReviewer.DeleteFile();
            selectedReviewer.DeleteFromDatabase();
            Reviewers.Remove(selectedReviewer);
        }

        public void RemoveActivity(Activity selectedActivity)
        {
            selectedActivity.DeleteFile();
            selectedActivity.DeleteFromDatabase();
            Activities.Remove(selectedActivity);
        }

        public void CheckForFiles()
        {
            CheckForActivities();
            CheckForReviewers();
        }

        public void CheckForActivities()
        {
            string activityPath = FolderPath + "/Activity";
            if (!Directory.Exists(activityPath)) Directory.CreateDirectory(activityPath);
            string[] activityFiles = Directory.GetFiles(activityPath);

            foreach (string file in activityFiles)
            {
                string filePath = file;
                if (filePath.Contains("\\")) filePath = filePath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(filePath);
                if (!Activities.Any(activity => filePath == activity.FilePath))
                {
                    Activity activity = new Activity(name, this, file, DateTime.Now, "Incomplete");
                    Activities.Add(activity);
                    activity.AddToDatabase();
                }
            }
        }

        public void CheckForReviewers()
        {
            string reviewerPath = FolderPath + "/Reviewer";
            if (!Directory.Exists(reviewerPath)) Directory.CreateDirectory(reviewerPath);
            string[] reviewerFiles = Directory.GetFiles(reviewerPath);
            foreach (string file in reviewerFiles)
            {
                string filePath = file;
                if (filePath.Contains("\\")) filePath = filePath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(filePath);
                if (!Reviewers.Any(reviewer => filePath == reviewer.FilePath))
                {
                    Reviewer reviewer = new Reviewer(name, this, file);
                    Reviewers.Add(reviewer);
                    reviewer.AddToDatabase();
                }

            }
            
        }
        public void AddToDatabase()
        {
            SubjectMessage message = new SubjectMessage(MessageType.AddSubject, SubjectName, User.Username);
            Client.SendMessageAsync(message);
        }

        public void UpdateToDatabase()
        {
            SubjectMessage message = new SubjectMessage(MessageType.UpdateSubject, SubjectName, User.Username, previousName);
            Client.SendMessageAsync(message);
        }

        public void DeleteFromDatabase()
        {
            SubjectMessage message = new SubjectMessage(MessageType.DeleteSubject, SubjectName, User.Username);
            Client.SendMessageAsync(message);
        }

        public JObject ToJson(List<string> subjects, string username)
        {
            JObject json = new JObject();
            json.Add("username", username);
            json.Add("subjects", new JArray(subjects));
            return json;
        }
    }
}
