using MySqlConnector;
using SchoolworkOrganizerUtils.MessageTypes;
using SchoolworkOrganizerUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolworkOrganizerServer;

namespace SchoolWorkOrganizerServer.Handlers
{
    internal class ActivityHandler
    {
        public static async void AddToDatabase(ActivityMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "INSERT INTO `activities` (username, name, subjectName, filename, dueDate, status, lastUpdated, fileData) VALUES (@Username, @Name, @SubjectName, @FileName, @DueDate, @Status, @LastUpdated, @FileData)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@Name", message.Name);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@FileName", message.FileName);
                        command.Parameters.AddWithValue("@DueDate", message.DueDate);
                        command.Parameters.AddWithValue("@Status", message.Status);
                        command.Parameters.AddWithValue("@LastUpdated", message.LastUpdated);
                        command.Parameters.AddWithValue("@FileData", message.FileData);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
            }
        }

        public static async void UpdateToDatabase(ActivityMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `activities` SET name = @Name, filename = @FileName, dueDate = @DueDate, status = @Status, lastUpdated = @LastUpdated WHERE username = @Username AND subjectName = @SubjectName AND name = @PreviousName";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", message.Username);
                        command.Parameters.AddWithValue("@Name", message.Name);
                        command.Parameters.AddWithValue("@SubjectName", message.Subject);
                        command.Parameters.AddWithValue("@FileName", message.FileName);
                        command.Parameters.AddWithValue("@DueDate", message.DueDate);
                        command.Parameters.AddWithValue("@Status", message.Status);
                        command.Parameters.AddWithValue("@LastUpdated", message.LastUpdated);
                        command.Parameters.AddWithValue("@PreviousName", message.PreviousName);

                        if (message.WithFile) UpdateFile(message);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
            }
        }

        public static async void UpdateFile(ActivityMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "UPDATE `activities` SET fileData = @FileData, lastUpdated = @LastUpdated WHERE username = @Username AND subjectName = @SubjectName AND name = @PreviousName";
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
                Console.WriteLine(e.Message);
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
            }
        }

        public static async void DeleteFromDatabase(ActivityMessage message)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Program.SqlConnectionString))
                {
                    await connection.OpenAsync();
                    string query = "DELETE FROM `activities` WHERE username = @Username AND subjectName = @SubjectName AND name = @Name";
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
                Console.WriteLine(e.Message); 
                if (Utilities.Debug) Console.WriteLine(e.StackTrace);
            }
        }
    }
}
