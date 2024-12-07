namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Activity
    {
        public DateTime LastUpdated { get; internal set; }
        public string Name;
        private Subject _subject;
        private string _fileName;
        public string FileName {
            get => _fileName;
            private set 
            {
                if (value == _fileName) return;
                string oldPath = FilePath;
                _fileName = value;
                if (File.Exists(FilePath)) Utilities.MoveFile(oldPath, FilePath);
            } 
        }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public Client? client => Subject.client;

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
            DueDate = dueDate;
            Status = status;

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

        public Activity(string name, Subject subject, string fileName, DateTime dueDate, string status, DateTime lastUpdated, byte[] fileData)
        {
            Name = name;
            _subject = subject;
            DueDate = dueDate;
            Status = status;
            _fileName = fileName;
            LastUpdated = lastUpdated;

            if (!Directory.Exists(subject.FolderPath + "/Activity")) Directory.CreateDirectory(subject.FolderPath + "/Activity");

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
                _ = UpdateActivity(this);
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
                _fileName = fileName;
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

        public async Task<bool> AddActivity()
        {
            if (client == null) return false;
            bool success = await client.AddActivity(this);
            if (success) Subject.Activities.Add(this);
            return success;
        }

        public async Task<bool> UpdateActivity(Activity newActivity)
        {
            if (client == null) return false;
            bool success = await client.UpdateActivity(newActivity, Name);
            if (success)
            {
                this.Subject = newActivity.Subject;
                this.Name = newActivity.Name;
                this.FileName = newActivity.FileName;
                this.DueDate = newActivity.DueDate;
                this.Status = newActivity.Status;
                this.LastUpdated = newActivity.LastUpdated;
            }
            return success;
        }

        public async Task<bool> DeleteActivity()
        {
            if (client == null) return false;
            bool success = await client.DeleteActivity(this);
            if (success)
            {
                this.DeleteFile();
                Subject.Activities.Remove(this);
            }
            return await client.DeleteActivity(this);
        }
    }
}
