using MySqlConnector;
using Newtonsoft.Json.Linq;
using SchoolworkOrganizerUtils.MessageTypes;
using System.Diagnostics;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Subject
    {
        private string _subjectName;
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
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
        public Client? client => User.client;

        public Subject(User user, string subjectName)
        {
            User = user;
            _subjectName = subjectName;
            SubjectName = subjectName;
            FolderPath = "Data/" + User.Username + "/" + SubjectName;
        }
        private void DeleteFolder()
        {
            Utilities.DeleteFolder(FolderPath);
        }

        public async void CheckForUpdates()
        {
            if (client == null)
            {
                Console.WriteLine("Client is null");
                return;
            }
            CheckForNewActivities();
            CheckForNewReviewers();

            foreach (Activity activity in Activities)
            {
                if (!File.Exists(activity.FilePath)) continue;
                if (File.GetLastWriteTime(activity.FilePath) <= activity.LastUpdated) continue;
                if (await client.UpdateActivity(activity)) Console.WriteLine("Updated activity: " + activity.Name);
                else Console.WriteLine("Failed to update activity: " + activity.Name);
            }

            foreach (Reviewer reviewer in Reviewers)
            {
                if (!File.Exists(reviewer.FilePath)) continue;
                if (File.GetLastWriteTime(reviewer.FilePath) <= reviewer.LastUpdated) continue;
                if (await client.UpdateReviewer(reviewer)) Console.WriteLine("Updated reviewer: " + reviewer.Name);
                else Console.WriteLine("Failed to update reviewer: " + reviewer.Name);
            }
        }

        public async void CheckForNewActivities()
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
                    if(await activity.AddActivity()) Console.WriteLine("Added activity: " + activity.Name);
                    else Console.WriteLine("Failed to add activity: " + activity.Name);
                }
            }
        }

        public async void CheckForNewReviewers()
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
                    if (await reviewer.AddReviewer()) Console.WriteLine("Added reviewer: " + reviewer.Name);
                    else Console.WriteLine("Failed to add reviewer: " + reviewer.Name);
                }

            }
            
        }

        public async Task<bool> AddSubject()
        {
            if (client == null) return false;
            bool success = await client.AddSubject(this);
            if (success) User.Subjects.Add(this);
            return success;
        }

        public async Task<bool> UpdateSubject(Subject newSubject)
        {
            if (client == null) return false;
            bool success = await client.UpdateSubject(newSubject, SubjectName);
            if (success)
            {
                this.SubjectName = newSubject.SubjectName;
                this.FolderPath = newSubject.FolderPath;
                this.Reviewers = newSubject.Reviewers;
                this.Activities = newSubject.Activities;
            }
            return success;
        }

        public async Task<bool> DeleteSubject()
        {
            if (client == null) return false;
            bool success = await client.DeleteSubject(this);
            if (success)
            {
                this.DeleteFolder();
                User.Subjects.Remove(this);
            }
            return success;
        }

    }
}
