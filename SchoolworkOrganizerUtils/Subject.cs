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
                string newPath = "Data/" + User.Username + "/" + value;
                if (FolderPath != null) Utilities.RenameFolder(FolderPath, newPath);
                FolderPath = newPath;
            }
        }

        public User User;
        public string FolderPath;
        public List<Reviewer> Reviewers = new List<Reviewer>();
        public List<Activity> Activities = new List<Activity>();

        public Subject(User user, string subjectName)
        {
            User = user;
            _name = subjectName;
            Name = subjectName;
            FolderPath = "Data/" + User.Username + "/" + Name;
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
            CheckForActivities();
            CheckForReviewers();
        }

        public void CheckForActivities()
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
                    Activities.Add(activity);
                    activity.AddToDatabase();
                }
            }
        }

        public void CheckForReviewers()
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
                    Reviewers.Add(reviewer);
                    reviewer.AddToDatabase();
                }

            }
            
        }

        //internal async void LoadActivities()
        //{
        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
        //        {
        //            await connection.OpenAsync();
        //            string query = "SELECT name, dueDate, status, filename FROM `activities` WHERE username = @Username AND subject = @Subject";
        //            using (MySqlCommand command = new MySqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Username", User.Username);
        //                command.Parameters.AddWithValue("@Subject", Name);
        //                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
        //                {
        //                    while (await reader.ReadAsync())
        //                    {
        //                        string name = reader.GetString("name");
        //                        DateTime dueDate = reader.GetDateTime("dueDate");
        //                        string status = reader.GetString("status");
        //                        string filename = reader.GetString("filename");
        //                        string filePath = FolderPath + "/Activity/" + filename;

        //                        if (Activities.Count > 0 && Activities.Any(activity => activity.FilePath == filePath))
        //                        {
        //                            Activity activity = Activities.First(activity => activity.Name == name && activity.FilePath == filePath);
        //                            activity.DueDate = dueDate;
        //                            activity.Status = status;
        //                            activity.Name = name;
        //                        }
        //                        else
        //                        {
        //                            Activity activity = new Activity(name, this, filename, dueDate, status);
        //                            Activities.Add(activity);
        //                        }

        //                    }
        //                }
        //            }
        //        }

        //        CheckForActivities();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message, "Error");
        //    }
        //}

        //internal async void LoadReviewers()
        //{
        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
        //        {
        //            await connection.OpenAsync();
        //            string query = "SELECT name, filename FROM `reviewers` WHERE username = @Username AND subject = @Subject";
        //            using (MySqlCommand command = new MySqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@Username", User.Username);
        //                command.Parameters.AddWithValue("@Subject", Name);
        //                using (MySqlDataReader reader = await command.ExecuteReaderAsync())
        //                {
        //                    while (await reader.ReadAsync())
        //                    {
        //                        string name = reader.GetString("name");
        //                        string filename = reader.GetString("filename");
        //                        string filePath = FolderPath + "/Reviewer/" + filename;
        //                        if (Reviewers.Count > 0 && Reviewers.Any(reviewer => reviewer.FilePath == filePath))
        //                        {
        //                            Reviewer reviewer = Reviewers.First(reviewer => reviewer.Name == name && reviewer.Subject.Name == Name);
        //                            reviewer.Name = name;
        //                        }
        //                        else
        //                        {
        //                            Reviewer reviewer = new Reviewer(name, this, filename);
        //                            Reviewers.Add(reviewer);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        CheckForReviewers();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message, "Error");
        //    }
        //}

        public async void AddToDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `subjects` (username, name) VALUES (@Username, @Name)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", User.Username);
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
                    string query = "UPDATE `subjects` SET name = @Name WHERE username = @Username AND name = @OldName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Username", User.Username);
                        command.Parameters.AddWithValue("@OldName", previousName);

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
            foreach (var reviewer in Reviewers) reviewer.DeleteFromDatabase();
            foreach (var activity in Activities) activity.DeleteFromDatabase();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `subjects` WHERE username = @Username AND name = @Name";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", User.Username);
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
