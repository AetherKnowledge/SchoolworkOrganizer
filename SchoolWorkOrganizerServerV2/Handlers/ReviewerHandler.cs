using MySqlConnector;
using SchoolworkOrganizerUtils.MessageTypes;
using SchoolworkOrganizerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolworkOrganizerServer;

namespace SchoolWorkOrganizerServerV2.Handlers
{
    internal class ReviewerHandler
    {
        public static async void AddToDatabase(ReviewerMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `reviewers` (username, name, subjectName, filename, lastUpdated, fileData) VALUES (@Username, @Name, @SubjectName, @FileName, @LastUpdated, @FileData)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@Name", message.Name);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@FileName", message.FileName);
                        command.Parameters.AddWithValue("@LastUpdated", message.LastUpdated);
                        command.Parameters.AddWithValue("@FileData", message.FileData);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public static async void UpdateToDatabase(ReviewerMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `reviewers` SET name = @Name, filename = @FileName WHERE username = @Username AND subjectName = @SubjectName AND name = @PreviousName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@Name", message.Name);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@FileName", message.FileName);
                        command.Parameters.AddWithValue("@PreviousName", message.PreviousName);

                        if (message.WithFile) UpdateFile(message);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public static async void UpdateFile(ReviewerMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `reviewers` SET fileData = @FileData, lastUpdated = @LastUpdated WHERE username = @Username AND subjectName = @SubjectName AND name = @PreviousName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FileData", message.FileData);
                        command.Parameters.AddWithValue("@LastUpdated", message.LastUpdated);
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@PreviousName", message.PreviousName);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message, "Error");
            }
        }

        public static async void DeleteFromDatabase(ReviewerMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `reviewers` WHERE username = @Username AND subjectName = @SubjectName AND name = @Name";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@Name", message.Name);

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
