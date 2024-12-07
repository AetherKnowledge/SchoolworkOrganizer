using MySqlConnector;
using SchoolworkOrganizerUtils.MessageTypes;
using System.IO;
using System.Xml.Linq;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Reviewer
    {
        public string FileName { get; private set; }
        private Subject _subject;
        public DateTime LastUpdated { get; private set; }
        public string Name;

        public Subject Subject
        {
            get { return _subject; }
            set
            {
                if (value == _subject) return;

                string oldFileName = "";
                if (FilePath == null) Path.GetFileName(FilePath);

                Subject oldSubject = _subject;
                if (FilePath != null) oldSubject.Reviewers.Remove(this);

                _subject = value;
                _subject.Reviewers.Add(this);

                if (oldSubject == null || FilePath == null) return;

                Utilities.MoveFile(oldSubject.FolderPath + "/Reviewer" + oldFileName, FilePath);
            }
        }

        public string FolderPath
        {
            get
            {
                if (Subject == null) return "";
                return Subject.FolderPath + "/Reviewer";
            }
        }

        public string FilePath
        {
            get
            {
                if (FolderPath == null) return "";
                return FolderPath + "/" + FileName;
            }
        }

        public Reviewer(string name, Subject subject, string path, bool isFileName = false)
        {
            Name = name;
            _subject = subject;
            Subject = subject;

            if (isFileName) FileName = path;
            else
            {
                string fileName = Path.GetFileName(path);
                FileName = fileName;

                if (path != FilePath)
                {
                    Utilities.CopyFile(path, FolderPath + "/" + fileName);
                }
            }

            if (!File.Exists(FilePath)) LastUpdated = DateTime.MinValue;
            else LastUpdated = File.GetLastWriteTime(FilePath);
        }

        public Reviewer(string name, Subject subject, string fileName, DateTime lastUpdated, byte[] fileData)
        {
            Name = name;
            _subject = subject;
            Subject = subject;
            FileName = fileName;
            LastUpdated = lastUpdated;

            if (!Directory.Exists(subject.FolderPath + "/Reviewer")) Directory.CreateDirectory(subject.FolderPath + "/Reviewer");

            if (!File.Exists(FilePath))
            {
                File.WriteAllBytes(FilePath, fileData);
                File.SetLastWriteTime(FilePath, LastUpdated);
            }
            else if (File.Exists(FilePath) && lastUpdated > File.GetLastWriteTime(FilePath))
            {
                File.WriteAllBytes(FilePath, fileData);
                File.SetLastWriteTime(FilePath, LastUpdated);
            }
            else if (File.Exists(FilePath) && lastUpdated < File.GetLastWriteTime(FilePath))
            {
                UpdateToDatabase(Name);
            }
        }

        public Reviewer(ReviewerMessage message)
        {
            if (User.currentUser == null || User.currentUser.Username != message.Username) throw new InvalidOperationException("Invalid User");
            Subject subject = User.currentUser.Subjects.FirstOrDefault(s => s.SubjectName == message.Subject) ?? throw new InvalidOperationException("Invalid Subject");

            Name = message.Name;
            _subject = subject;
            Subject = subject;
            FileName = message.FileName;

            if (message.FileData == null || !message.WithFile) return;
            if (!Directory.Exists(subject.FolderPath + "/Reviewer")) Directory.CreateDirectory(subject.FolderPath + "/Reviewer");
            if (!File.Exists(FilePath))
            {
                File.WriteAllBytes(FilePath, message.FileData);
                File.SetLastWriteTime(FilePath, message.LastUpdated);
            }
            else if (message.LastUpdated > LastUpdated)
            {
                File.WriteAllBytes(FilePath, message.FileData);
                File.SetLastWriteTime(FilePath, message.LastUpdated);
            }
        }

        public void ChangeFile(string sourcePath)
        {
            try
            {
                if (sourcePath == FilePath) return;
                if (!File.Exists(sourcePath)) return;

                File.Delete(FilePath);
                string fileName = Path.GetFileName(sourcePath);
                FileName = fileName;
                Utilities.CopyFile(sourcePath, FolderPath + "/" + fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DeleteFile()
        {
            try
            {
                File.Delete(FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void AddToDatabase()
        {
            ReviewerMessage message = new ReviewerMessage(MessageType.AddReviewer, this, Name, true);
            Client.SendMessageAsync(message);
        }

        public void UpdateToDatabase(string previousName)
        {
            bool withFile = false;
            if (File.Exists(FilePath) && LastUpdated < File.GetLastWriteTime(FilePath))
            {
                withFile = true;
                LastUpdated = File.GetLastWriteTime(FilePath);
            }

            ReviewerMessage message = new ReviewerMessage(MessageType.UpdateReviewer, this, previousName, withFile);
            Client.SendMessageAsync(message);
        }

        public void DeleteFromDatabase()
        {
            ReviewerMessage message = new ReviewerMessage(MessageType.DeleteReviewer, this);
            Client.SendMessageAsync(message);
        }
    }
}
