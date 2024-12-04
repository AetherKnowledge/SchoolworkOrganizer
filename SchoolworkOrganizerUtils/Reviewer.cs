
using MySqlConnector;

namespace SchoolworkOrganizerUtils
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

        public string FolderPath
        {
            get 
            {
                if (Subject == null) return null;
                return Subject.FolderPath + "/Reviewer"; 
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

        public Reviewer(string name, Subject subject, string sourcePath)
        {
            Name = name;
            _subject = subject;
            Subject = subject;

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

        public async void AddToDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `reviewers` (name, username, subject, name, filename) VALUES (@Name, @Username, @Subject, @Name, @FileName)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Username", Subject.User);
                        command.Parameters.AddWithValue("@Subject", Subject.Name);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@FileName", FileName);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async void UpdateToDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `reviewers` SET name = @Name, filename = @FileName WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Username", Subject.User.Username);
                        command.Parameters.AddWithValue("@Subject", Subject.Name);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@FileName", FileName);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async void DeleteFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `reviewers` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Subject.User);
                        command.Parameters.AddWithValue("@Subject", Subject.Name);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }
    }
}
