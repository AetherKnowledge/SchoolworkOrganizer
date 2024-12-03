using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;
using Microsoft.Identity.Client;
using MySqlConnector;

namespace SchoolworkOrganizer
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
        public string Username {
            get { return _username; }
            set
            {
                _username = value;
                string newPath = "Data/" + value;
                Utilities.RenameFolder(UserPath, newPath);
                UserPath = newPath;
            }
        }

        public string Password;

        private byte[]? UserImageData;
        public List<Subject> Subjects = new List<Subject>();
        public Image UserImage;

        public User(string Email, string Username, string Password, Image UserImage)
        {
            this.Email = Email;
            this.Username = Username;
            this.Password = Password;
            this.UserImage = UserImage;
            UserPath = "Data/" + Username;

        }

        public static void LoadUsers()
        {
            //if (!File.Exists(UserDataPath) || new FileInfo(UserDataPath).Length == 0)
            //{
            //    return;
            //}

            //using (var stream = new FileStream(UserDataPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    // Deserialize the JSON data to a List<User>
            //    var users = JsonSerializer.Deserialize<List<User>>(stream);

            //    if (users != null)
            //    {
            //        Users.Clear();
            //        Users.AddRange(users);
            //    }
            //}

            //foreach (User user in Users)
            //{
            //    user.ConvertBytesToImage();
            //}
        }

        public static void SaveUsers()
        {
            if (!File.Exists(UserDataPath))
            {
                using (File.Create(UserDataPath)) { }
            }

            foreach (User user in Users)
            {
                user.ConvertImageToBytes();
            }


            using (var stream = new FileStream(UserDataPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                JsonSerializer.Serialize(stream, Users);
            }
        }

        private void ConvertImageToBytes()
        {
            if (UserImage == null) return;
            this.UserImageData = Utilities.ImageToByteArray(UserImage);
        }

        private void ConvertBytesToImage()
        {
            if (UserImageData == null) return;
            this.UserImage = Utilities.ByteArrayToImage(UserImageData);
            UserImageData = null;
        }

        public void RemoveSubject(Subject selectedSubject)
        {
            selectedSubject.DeleteFolder();
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

        public void AddUserToDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO `user` (username, password, email, imageData) VALUES (@Username, @Password, @Email, @ImageData)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@ImageData", UserImageData ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void UpdateUserInDatabase(string oldUsername)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE `user` SET username = @Username, password = @Password, email = @Email, imageData = @ImageData WHERE username = @OldUsername";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@OldUsername", oldUsername);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@ImageData", UserImageData ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void DeleteUserFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM `user` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Username);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

    }
}
