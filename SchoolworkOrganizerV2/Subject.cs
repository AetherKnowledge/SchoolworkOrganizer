using SchoolworkOrganizerV2.Panels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizerV2
{
    [Serializable]
    public class Subject
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                string newPath = "Data/" + Username + "/" + value;
                Utilities.RenameFolder(FolderPath, newPath);
                FolderPath = newPath;
            }
        }
        public String Username;
        public String FolderPath;
        public List<Reviewer> Reviewers = new List<Reviewer>();
        public List<Activity> Activities = new List<Activity>();

        public Subject(string username, string subjectName)
        {
            Username = username;
            Name = subjectName;
            FolderPath = "Data/" + Username + "/" + Name;
            CheckForFiles();
        }

        public void DeleteFolder()
        {
            Utilities.DeleteFolder(FolderPath);
        }

        public void RemoveReviewer(Reviewer selectedReviewer)
        {
            selectedReviewer.DeleteFile();
            Reviewers.Remove(selectedReviewer);
        }

        public void RemoveActivity(Activity selectedActivity)
        {
            selectedActivity.DeleteFile();
            Activities.Remove(selectedActivity);
        }

        public void CheckForFiles()
        {
            string activityPath = FolderPath + "/Activity";
            string reviewerPath = FolderPath + "/Reviewer";

            if (!Directory.Exists(activityPath)) Directory.CreateDirectory(activityPath);
            if (!Directory.Exists(reviewerPath)) Directory.CreateDirectory(reviewerPath);

            string[] activityFiles = Directory.GetFiles(activityPath);

            foreach (string file in activityFiles) 
            {
                string filePath = file;
                if (filePath.Contains("\\")) filePath = filePath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(filePath);
                if (!Activities.Any(activity => filePath == activity.FilePath))
                {
                    new Activity(name, this, file, DateTime.Now, "Incomplete");
                }
            }

            string[] reviewerFiles = Directory.GetFiles(reviewerPath);
            foreach (string file in reviewerFiles)
            {
                string filePath = file;
                if (filePath.Contains("\\")) filePath = filePath.Replace("\\", "/");
                string name = Path.GetFileNameWithoutExtension(filePath);
                if (!Reviewers.Any(reviewer => filePath == reviewer.FilePath))
                {
                    new Reviewer(name, this, file);
                }
            }
        }
    }
}
