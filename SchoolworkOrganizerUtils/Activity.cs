using MySqlConnector;
using SchoolworkOrganizerUtils.MessageTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Activity
    {
        public DateTime LastUpdated { get; private set; }
        public string Name;
        private Subject _subject;
        public string FileName { get; private set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public Subject Subject
        {
            get { return _subject; }
            set
            {
                if (value == _subject) return;

                string oldFileName = "";
                if (FilePath == null) Path.GetFileName(FilePath);

                Subject oldSubject = _subject;
                if (FilePath != null) oldSubject.Activities.Remove(this);

                _subject = value;
                _subject.Activities.Add(this);

                if (oldSubject == null || FilePath == null) return;

                Utilities.MoveFile(oldSubject.FolderPath + "/Activity" + oldFileName, FilePath);
            }
        }

        public string FolderPath
        {
            get 
            {
                if (Subject == null) return "";
                return Subject.FolderPath + "/Activity"; 
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

        public Activity(string name, Subject subject, string path, DateTime dueDate, string status, bool isFileName = false)
        {
            Name = name;
            _subject = subject;
            Subject = subject;
            DueDate = dueDate;
            Status = status;

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

        public Activity(string name, Subject subject, string fileName, DateTime dueDate, string status, DateTime lastUpdated, byte[] fileData)
        {
            Name = name;
            _subject = subject;
            Subject = subject;
            DueDate = dueDate;
            Status = status;
            FileName = fileName;
            LastUpdated = lastUpdated;

            if (!Directory.Exists(subject.FolderPath + "/Activity")) Directory.CreateDirectory(subject.FolderPath + "/Activity");
            if (!File.Exists(FilePath)) File.WriteAllBytes(FilePath, fileData);
            else if (File.Exists(FilePath) && lastUpdated > File.GetLastWriteTime(FilePath)) File.WriteAllBytes(FilePath, fileData);
            else if (File.Exists(FilePath) && lastUpdated < File.GetLastWriteTime(FilePath)) UpdateToDatabase(Name);
        }

        public Activity(ActivityMessage message)
        {
            if (User.currentUser == null || User.currentUser.Username != message.Username) throw new InvalidOperationException("Invalid User");
            Subject subject = User.currentUser.Subjects.FirstOrDefault(s => s.SubjectName == message.Subject) ?? throw new InvalidOperationException("Invalid Subject");

            Name = message.Name;
            _subject = subject;
            Subject = subject;
            FileName = message.FileName;
            DueDate = message.DueDate;
            Status = message.Status;

            if (message.FileData == null || !message.WithFile) return;
            if (!Directory.Exists(subject.FolderPath + "/Reviewer")) Directory.CreateDirectory(subject.FolderPath + "/Reviewer");
            if (!File.Exists(FilePath)) File.WriteAllBytes(FilePath, message.FileData);
            else if (message.LastUpdated > LastUpdated) File.WriteAllBytes(FilePath, message.FileData);
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
            ActivityMessage message = new ActivityMessage(MessageType.AddActivity, this, Name, true);
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

            ActivityMessage message = new ActivityMessage(MessageType.UpdateActivity, this, previousName, withFile);
            Client.SendMessageAsync(message);
        }

        public void DeleteFromDatabase()
        {
            ActivityMessage message = new ActivityMessage(MessageType.DeleteActivity, this);
            Client.SendMessageAsync(message);
        }
    }
}
