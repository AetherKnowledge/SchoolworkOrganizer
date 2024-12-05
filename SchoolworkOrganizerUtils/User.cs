using MySqlConnector;
using SkiaSharp;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SchoolworkOrganizerUtils
{
    [Serializable]
    public class User
    {

        public static readonly List<User> Users = new List<User>();
        public static User? currentUser = null;

        private static readonly string UserDataPath = "UserData.data";
        public string UserPath;

        public string Email;

        private string _username = "";
        //public string previousUsername = "";

        [JsonPropertyName("username")]
        public string Username
        {
            get { return _username; }
            set
            {
                //if (previousUsername == "") previousUsername = value;
                //else if (previousUsername != _username) previousUsername = _username;

                _username = value;
                string newPath = "Data/" + value;
                if (UserPath != null) Utilities.RenameFolder(UserPath, newPath);
                UserPath = newPath;
            }
        }
        [JsonPropertyName("password")]
        public string Password;
        private byte[]? UserImageData;
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

        public void CheckForFiles()
        {
            foreach (Subject subject in Subjects)
            {
                subject.CheckForFiles();
            }
        }

        public static void Logout()
        {
            currentUser = null;
        }

        private static bool isUpdating = false;
        public async static void LoadUsers(bool hasUpdated = false)
        {
            //if (isUpdating && !hasUpdated) return;

            //try
            //{
            //    using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
            //    {
            //        await connection.OpenAsync();
            //        string query = "SELECT username, password, email, imageData FROM `users`";
            //        using (MySqlCommand command = new MySqlCommand(query, connection))
            //        {
            //            using (MySqlDataReader reader = await command.ExecuteReaderAsync())
            //            {
            //                Users.Clear();
            //                while (await reader.ReadAsync())
            //                {
            //                    string username = reader.GetString("username");
            //                    string password = reader.GetString("password");
            //                    string email = reader.GetString("email");
            //                    byte[]? imageData = reader.IsDBNull(reader.GetOrdinal("imageData")) ? null : (byte[])reader["imageData"];
            //                    SKImage? userImage = imageData != null ? await Utilities.ByteArrayToSKImageAsync(imageData) : null;

            //                    User user = new User(email, username, password, userImage);
            //                    Users.Add(user);
            //                    user.LoadSubjects();
            //                }
            //            }
            //        }


            //    }
            //}
            //catch (MySqlException e)
            //{
            //    Console.WriteLine(e.Message, "Error");
            //}
        }

        private async void LoadSubjects()
        {
            //try
            //{
            //    using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
            //    {
            //        await connection.OpenAsync();
            //        string query = "SELECT name FROM `subjects` WHERE username = @Username";
            //        using (MySqlCommand command = new MySqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Username", Username);
            //            using (MySqlDataReader reader = await command.ExecuteReaderAsync())
            //            {
            //                while (await reader.ReadAsync())
            //                {
            //                    string name = reader.GetString("name");
            //                    Subject subject = new Subject(this, name);
            //                    Subjects.Add(subject);
            //                    subject.LoadActivities();
            //                    subject.LoadReviewers();
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (MySqlException e)
            //{
            //    Console.WriteLine(e.Message, "Error");
            //}
        }

        public async void DeleteFromDatabase()
        {
            //try
            //{
            //    using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
            //    {
            //        await connection.OpenAsync();
            //        string query = "DELETE FROM `users` WHERE username = @Username";
            //        using (MySqlCommand command = new MySqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Username", Username);

            //            await command.ExecuteNonQueryAsync();
            //        }
            //    }

            //    LoadUsers(true);
            //}
            //catch (MySqlException e)
            //{
            //    Console.WriteLine(e.Message, "Error");
            //}
        }

        public JsonObject ToJson()
        {
            JsonObject json = new JsonObject();
            json.Add("username", Username);
            json.Add("password", Password);
            json.Add("email", Email);
            json.Add("imageData", UserImage != null ? Convert.ToBase64String(Utilities.SKImageToByteArray(UserImage)) : null);
            return json;
        }

        public static User ParseJson(JsonObject json)
        {
            string username = json["username"]?.ToString() ?? throw new ArgumentNullException(nameof(username));
            string password = json["password"]?.ToString() ?? throw new ArgumentNullException(nameof(password));
            string email = json["email"]?.ToString() ?? throw new ArgumentNullException(nameof(email));
            string imageDataBase64 = json["imageData"]?.ToString() ?? string.Empty;
            byte[] imageData = Convert.FromBase64String(imageDataBase64);
            SKImage? userImage;

            if (imageData != null) userImage = (Utilities.ByteArrayToSKImage(imageData)) ?? null;
            else userImage = null;

            return new User(email, username, password, userImage);

        }

        //public static async Task<User> ParseJsonAsync(JsonObject json)
        //{
        //    try
        //    {
        //        string username = json["username"]?.ToString() ?? throw new ArgumentNullException(nameof(username));
        //        string password = json["password"]?.ToString() ?? throw new ArgumentNullException(nameof(password));
        //        string email = json["email"]?.ToString() ?? throw new ArgumentNullException(nameof(email));
        //        string imageDataBase64 = json["imageData"]?.ToString() ?? throw new ArgumentNullException("imageData");
        //        byte[] imageData = Convert.FromBase64String(imageDataBase64);
        //        SKImage? userImage;

        //        if (imageData != null) userImage = (await Utilities.ByteArrayToSKImageAsync(imageData)) ?? null;
        //        else userImage = null;

        //        return new User(email, username, password, userImage);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;

        //    }
        //}
    }
}
