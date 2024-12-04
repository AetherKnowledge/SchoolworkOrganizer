using MySqlConnector;
using SkiaSharp;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class User
    {
        
        public static readonly List<User> Users = new List<User>();
        public static User? currentUser = null;

        private static readonly string UserDataPath = "UserData.data";
        private string UserPath;

        public string Email;
        private string _username = "";
        internal string previousUsername = "";

        public string Username {
            get { return _username; }
            set
            {
                if (previousUsername == "") previousUsername = value;
                else if (previousUsername != _username) previousUsername = _username;

                _username = value;
                string newPath = "Data/" + value;
                Utilities.RenameFolder(UserPath, newPath);
                UserPath = newPath;
            }
        }

        public string Password;
        //private byte[]? UserImageData;
        public List<Subject> Subjects = new List<Subject>();

        private SKImage? _userImage;

        
        public SKImage? UserImage
        {
            get { return _userImage; }
            set
            {
                _userImage = value;

                if (!OperatingSystem.IsWindows()) return;
                WinformImage = value != null ? Utilities.ConvertToImage(value) : null;
            }
        }

        public Image? WinformImage { get; private set; }

        public User(string Email, string Username, string Password, SKImage? UserImage)
        {
            this.Email = Email;
            this.Username = Username;
            this.Password = Password;
            this.UserImage = UserImage;
            UserPath = "Data/" + Username;

        }

        public void RemoveSubject(Subject selectedSubject)
        {
            selectedSubject.DeleteFolder();
            selectedSubject.DeleteFromDatabase();
            Subjects.Remove(selectedSubject);
        }

        public static bool DoesUserExist(string username)
        {
            foreach (User user in Users)
            {
                if (user.Username == username)
                {
                    return true;
                }
            }

            return false;
        }
        public void CheckForFiles()
        {
            foreach (Subject subject in Subjects)
            {
                subject.CheckForFiles();
            }
        }

        public static bool Login(string username, string password)
        {
            foreach (User user in Users)
            {
                if (user.Username == username && user.Password == password) 
                {
                    currentUser = user;
                    return true; 
                }
            }

            return false;
        }

        public static void Logout()
        {
            currentUser = null;
        }

        private static bool isUpdating = false;
        public async static void LoadUsers(bool hasUpdated = false)
        {
            if (isUpdating && !hasUpdated) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT username, password, email, imageData FROM `user`";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            Users.Clear();
                            while (await reader.ReadAsync())
                            {
                                string username = reader.GetString("username");
                                string password = reader.GetString("password");
                                string email = reader.GetString("email");
                                byte[]? imageData = reader.IsDBNull(reader.GetOrdinal("imageData")) ? null : (byte[])reader["imageData"];
                                SKImage? userImage = imageData != null ? await Utilities.ByteArrayToSKImageAsync(imageData) : null;

                                User user = new User(email, username, password, userImage);
                                Users.Add(user);
                                user.LoadSubjects();
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

        private async void LoadSubjects()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT name FROM `subject` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        using (MySqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string name = reader.GetString("name");
                                Subject subject = new Subject(Username, name);
                                Subjects.Add(subject);
                                subject.LoadActivities();
                                subject.LoadReviewers();
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
                    string query = "INSERT INTO `user` (username, password, email, imageData) VALUES (@Username, @Password, @Email, @ImageData)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@ImageData", UserImage != null ? await Utilities.SKImageToByteArrayAsync(UserImage) : DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                LoadUsers(true);
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
                    string query = "UPDATE `user` SET username = @Username, password = @Password, email = @Email, imageData = @ImageData WHERE username = @OldUsername";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@ImageData", UserImage != null ? await Utilities.SKImageToByteArrayAsync(UserImage) : DBNull.Value);
                        command.Parameters.AddWithValue("@OldUsername", previousUsername);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                Subjects.All(subject => { subject.UpdateToDatabase(); return true;});
                LoadUsers(true);
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
                    string query = "DELETE FROM `user` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                LoadUsers(true);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

    }
}
