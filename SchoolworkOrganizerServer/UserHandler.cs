using SchoolworkOrganizerUtils;
using MySqlConnector;
using SkiaSharp;
using System.Collections.Concurrent;
using System.Xml.Linq;
using System.Text.Json.Nodes;
using SchoolworkOrganizerUtils.MessageTypes;

namespace SchoolworkOrganizerServer
{
    internal class UserHandler
    {
        internal static async void LoadSubjects(User user)
        {
            user.Subjects.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name FROM `subjects` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                Subject subject = new Subject(user, name);
                                user.Subjects.Add(subject);
                                LoadActivities(subject);
                                LoadReviewers(subject);
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

        private static async void LoadActivities(Subject subject)
        {
            subject.Activities.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, dueDate, status, filename FROM `activities` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", subject.User.Username);
                        command.Parameters.AddWithValue("@Subject", subject.SubjectName);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                DateTime dueDate = reader.GetDateTime("dueDate");
                                string status = reader.GetString("status");
                                string filename = reader.GetString("filename");
                                string filePath = subject.FolderPath + "/Activity/" + filename;

                                if (subject.Activities.Count > 0 && subject.Activities.Any(activity => activity.FilePath == filePath))
                                {
                                    Activity activity = subject.Activities.First(activity => activity.Name == name && activity.FilePath == filePath);
                                    activity.DueDate = dueDate;
                                    activity.Status = status;
                                    activity.Name = name;
                                }
                                else
                                {
                                    Activity activity = new Activity(name, subject, filename, dueDate, status);
                                    subject.Activities.Add(activity);
                                }

                            }
                        }
                    }
                }

                subject.CheckForNewActivities();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        internal static async Task<User?> GetUser(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT username, password, email, imageData FROM `users` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string password = reader.GetString("password");
                                string email = reader.GetString("email");
                                byte[]? imageData = reader.IsDBNull(reader.GetOrdinal("imageData")) ? null : (byte[])reader["imageData"];
                                SKImage? userImage = imageData != null ? await Utilities.ByteArrayToSKImageAsync(imageData) : null;

                                User user = new User(email, username, password, userImage);
                                LoadSubjects(user);
                                return user;
                            }
                        }
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }

            return null;
        }

        private static async void LoadReviewers(Subject subject)
        {
            subject.Reviewers.Clear();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name, filename FROM `reviewers` WHERE username = @Username AND subject = @Subject";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", subject.User.Username);
                        command.Parameters.AddWithValue("@Subject", subject.SubjectName);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                string filename = reader.GetString("filename");
                                string filePath = subject.FolderPath + "/Reviewer/" + filename;
                                if (subject.Reviewers.Count > 0 && subject.Reviewers.Any(reviewer => reviewer.FilePath == filePath))
                                {
                                    Reviewer reviewer = subject.Reviewers.First(reviewer => reviewer.Name == name && reviewer.Subject.SubjectName == subject.SubjectName);
                                    reviewer.Name = name;
                                }
                                else
                                {
                                    Reviewer reviewer = new Reviewer(name, subject, filename);
                                    subject.Reviewers.Add(reviewer);
                                }
                            }
                        }
                    }
                }

                subject.CheckForNewReviewers();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "Error");
            }

        }

        public static async void AddToDatabase(UserMessage user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `users` (username, password, email, imageData) VALUES (@Username, @Password, @Email, @ImageData)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@ImageData", user.UserImageData);

                        await command.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public static async Task<bool> UpdateToDatabase(UserMessage user)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `users` SET username = @Username, password = @Password, email = @Email, imageData = @ImageData WHERE username = @OldUsername";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@ImageData", user.UserImageData);
                        command.Parameters.AddWithValue("@OldUsername", user.PreviousUsername);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
                return false;
            }
        }

        public static async Task<bool> DoesUserExist(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT username FROM `users`";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                if (reader.GetString("username") == username) return true;
                            }
                        }

                        await command.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }

            return false;
        }

        public static async Task<User?> AttemptLogin(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM `users`";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                if (reader.GetString("username") == username && reader.GetString("password") == password)
                                {
                                    string email = reader.GetString("email");
                                    byte[]? imageData = reader.IsDBNull(reader.GetOrdinal("imageData")) ? null : (byte[])reader["imageData"];
                                    SKImage? userImage = imageData != null ? await Utilities.ByteArrayToSKImageAsync(imageData) : null;
                                    return new User(email, username, password, userImage, false);
                                }
                            }
                        }

                        await command.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }

            return null;

        }
    }
}
