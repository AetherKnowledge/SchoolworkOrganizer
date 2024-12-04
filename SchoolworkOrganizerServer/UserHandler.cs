using SchoolworkOrganizerUtils;
using MySqlConnector;
using SkiaSharp;
using System.Collections.Concurrent;
using System.Xml.Linq;

namespace SchoolworkOrganizerServer
{
    internal class UserHandler
    {
        internal static readonly List<UserHandler> Users = new List<UserHandler>();
        private User user;
        

        public UserHandler(User user)
        {
            this.user = user;
        }

        public async Task AddToDatabase()
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
                        command.Parameters.AddWithValue("@ImageData", user.UserImage != null ? await Utilities.SKImageToByteArrayAsync(user.UserImage) : DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                await Program.LoadUsers(true);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async Task UpdateToDatabase()
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
                        command.Parameters.AddWithValue("@ImageData", user.UserImage != null ? await Utilities.SKImageToByteArrayAsync(user.UserImage) : DBNull.Value);
                        command.Parameters.AddWithValue("@OldUsername", user.previousUsername);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                await Program.LoadUsers(true);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public async Task DeleteFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Utilities.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `users` WHERE username = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                await Program.LoadUsers(true);
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

    }
}
