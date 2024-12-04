

using MySqlConnector;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class Subject
    {
        private string _name;
        private string previousName = "";
        public string Name
        {
            get { return _name; }
            set
            {
                if (previousName == "") previousName = value;
                else if (previousName != _name) previousName = _name;

                _name = value;
                string newPath = "Data/" + Username + "/" + value;
                Utilities.RenameFolder(FolderPath, newPath);
                FolderPath = newPath;
            }
        }

        public string Username;
        public string FolderPath;
        public List<Reviewer> Reviewers = new List<Reviewer>();
        public List<Activity> Activities = new List<Activity>();

        public Subject(string username, string subjectName)
        {
            _name = username;
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

        internal async void LoadActivities()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, dueDate, status, filename FROM `activities` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Subject", Name);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                DateTime dueDate = reader.GetDateTime("dueDate");
                                string status = reader.GetString("status");
                                string filename = reader.GetString("filename");

                                Activities.Add(new Activity(name, this, filename, dueDate, status));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        internal async void LoadReviewers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, filename FROM `reviewers` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Subject", Name);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                string filename = reader.GetString("filename");
                                Reviewers.Add(new Reviewer(name, this, filename));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async void AddToDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `subject` (username, name) VALUES (@Username, @Name)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Name", Name);

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
                    string query = "UPDATE `subject` SET name = @Name WHERE username = @Username AND name = @OldName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@OldName", previousName);

                        await command.ExecuteNonQueryAsync();
                    }

                    foreach (var reviewer in Reviewers) reviewer.UpdateToDatabase();
                    foreach (var activity in Activities) activity.UpdateToDatabase();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async void DeleteFromDatabase()
        {
            foreach (var reviewer in Reviewers) reviewer.DeleteFromDatabase();
            foreach (var activity in Activities) activity.DeleteFromDatabase();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `subject` WHERE username = @Username AND name = @Name";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Name", Name);

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
