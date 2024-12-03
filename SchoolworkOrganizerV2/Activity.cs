using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolworkOrganizer
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        private Subject _subject;

        public Subject Subject
        {
            get { return _subject; }
            set
            {
                if (value == _subject) return;

                string oldFileName = null;
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
                if (Subject == null) return null;
                return Subject.FolderPath + "/Activity"; 
            }
        }

        public string FileName { get; private set; }
        public string FilePath
        {
            get
            {
                if (FolderPath == null) return null;
                return FolderPath + "/" + FileName;
            }
        }

        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public Activity(string name, Subject subject, string sourcePath, DateTime dueDate, string status)
        {
            Name = name;
            Subject = subject;
            DueDate = dueDate;
            Status = status;

            string fileName = Path.GetFileName(sourcePath);
            FileName = fileName;

            if (sourcePath != FilePath)
            {
                Utilities.CopyFile(sourcePath, FolderPath + "/" + fileName);
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
    }
}
