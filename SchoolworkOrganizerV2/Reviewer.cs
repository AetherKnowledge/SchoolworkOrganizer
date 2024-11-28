using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using SchoolworkOrganizerV2.Panels;

namespace SchoolworkOrganizerV2
{
    [Serializable]
    public class Reviewer
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
                if (FilePath != null) oldSubject.Reviewers.Remove(this);

                _subject = value;
                _subject.Reviewers.Add(this);

                if (oldSubject == null || FilePath == null) return;
                
                Utilities.MoveFile(oldSubject.FolderPath + "/Reviewer" + oldFileName, FilePath);
            }
        }

        private string _folderPath;
        public string FolderPath
        {
            get 
            {
                if (Subject == null) return null;
                return Subject.FolderPath + "/Reviewer"; 
            }
        }

        private string _filePath;
        public string FilePath
        {
            get
            {
                if (FolderPath == null) return null;
                return FolderPath + "/" + _filePath;
            }
            private set { _filePath = value; }
        }

        public Reviewer(string name, Subject subject, string sourcePath)
        {
            Name = name;
            Subject = subject;

            string fileName = Path.GetFileName(sourcePath);
            FilePath = fileName;

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
                FilePath = fileName;
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
