using MySqlConnector;
using SchoolworkOrganizerUtils.MessageTypes;
using System.IO;
using System.Xml.Linq;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Reviewer
    {
        private string _fileName;
        private Subject _subject;
        public DateTime LastUpdated { get; internal set; }
        public string Name;
        public Client? client => Subject.client;

        public string FileName
        {
            get => _fileName;
            private set
            {
                if (value == _fileName) return;
                string oldPath = FilePath;
                _fileName = value;
                if (File.Exists(FilePath)) Utilities.MoveFile(oldPath, FilePath);
            }
        }
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

            if (isFileName) _fileName = path;
            else
            {
                string fileName = Path.GetFileName(path);
                _fileName = fileName;

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
            _fileName = fileName;
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

        public async Task<bool> AddReviewer()
        {
            if (client == null) return false;
            bool success = await client.AddReviewer(this);
            if (success) Subject.Reviewers.Add(this);
            return success;
        }

        public async Task<bool> UpdateReviewer(string previousName = "")
        {
            if (client == null) return false;
            return await client.UpdateReviewer(this);
        }

        public async Task<bool> DeleteReviewer()
        {
            if (client == null) return false;
            bool success = await client.DeleteReviewer(this);
            if (success) 
            {
                this.DeleteFile();
                Subject.Reviewers.Remove(this);
            }
            return success;
        }
    }
}
